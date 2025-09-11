using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using static GADE6112POE_Part1_v01.Level;

namespace GADE6112POE_Part1_v01
{
    [Serializable]
    public class GameEngine
    {
        //Level 
        private Level currentLevel;             //stores current level
        [NonSerialized]
        private int numberOfLevels;             //number of Levels
        private Random random = new Random();   //used with constants to determine size of the Level.
        private int width;
        private int height;

        //Hero
        private HeroTile currentHero;
        private Position heroStand;

        //private int enemySpawn;   Commenting out as it is Unused at the Moment
        [NonSerialized]
        private GameState gameState = GameState.InProgress;
        private int successfulMoves = 0; // Field to count successful moves
        private int currentLevelNumber = 1; // Added field to track current level number
        private int numPickUp = 1;

        //constants
        private const int maxSize = 20;
        private const int minSize = 10;

        //GameData
        private IFormatter saveFormatter;
        private SaveGameData saveGame;

        //Enums
        public enum GameState   //GameState Enum, communicates the current stage of the game
        {
            InProgress,
            Complete,
            GameOver
        }
        //PROPERTIES
        public Level CurrentLevel { get { return currentLevel; } }

        //CONSTRUCTOR
        public GameEngine(int numLevels)
        {
            numberOfLevels = numLevels;
            width = random.Next(minSize, maxSize);        //every Level is Randomized
            height = random.Next(minSize, maxSize);
            currentLevel = new Level(width, height, NumEnemySpawn(),numPickUp);
        }


        //Method that converts the Enum into a Number
        public int ToInt(Level.Direction direction) //method converts the Direction enum into a number that can be used for the CharacterVision Array
        {
            //Console.WriteLine("Direction"+ direction);         //console output for debugging purposes
            int dirVision = 6;
            if (direction == Direction.Up) { dirVision = 0; }
            else if (direction == Direction.Right) { dirVision = 1; }
            else if (direction == Direction.Down) { dirVision = 2; }
            else if (direction == Direction.Left) { dirVision = 3; }
            else if (direction == Direction.None) { dirVision = 4; }

            return dirVision;       //returns the int value
        }

        //MOVEMENT METHODS
        public void TriggerMovement(Level.Direction move)
        {
            MoveHero(move);
            UpdateVision();
           if (gameState == GameState.GameOver || gameState == GameState.Complete)
           {
                return; // Game is over, do nothing
           }

            // Checks if it's time to move enemies (every 2 successful moves)
            if (successfulMoves >= 2 )
            {
                MoveEnemies();
                UpdateVision();
                
                successfulMoves = 0;
            }
            
        }
        private bool MoveHero(Level.Direction move)
        {
            Position targetPosition;
            Tile targetTile;
            int numVision = ToInt(move); //turns into an integer for the Switch Statement
            //New Switch and case Using Vision Methods
            //sets the Target Position, based on the position of the Hero.          //I don't know why it breaks, I've done eberything, and i still don't know, The problem appears to be coming from the the Vision arrays code but the same Code also Works except when it doesn't and I don't kniw what to do
            switch (numVision)
            {
                case 0: targetTile = currentLevel.Tiles[currentLevel.HeroPosition.X - 1, currentLevel.HeroPosition.Y]; break;
                case 1: targetTile = currentLevel.Tiles[currentLevel.HeroPosition.X, currentLevel.HeroPosition.Y + 1]; break;
                case 2: targetTile = currentLevel.Tiles[currentLevel.HeroPosition.X + 1, currentLevel.HeroPosition.Y]; break;
                case 3: targetTile = currentLevel.Tiles[currentLevel.HeroPosition.X, currentLevel.HeroPosition.Y - 1]; break;
                default: return false;
            }

            Tile heroTile = currentLevel.Tiles[currentLevel.HeroPosition.X, currentLevel.HeroPosition.Y];

            if (targetTile is HealthPickupTile)
            {
                targetPosition = new Position(targetTile.positionX, targetTile.positionY);
                currentLevel.Hero.Heal(5);
                targetTile = (EmptyTile)currentLevel.CreateTile(TileType.Empty, targetPosition);
                currentLevel.Tiles[targetPosition.X, targetPosition.Y] = targetTile;
            }

            if (targetTile is AttackBuffPickupTile)
            {
                targetPosition = new Position(targetTile.positionX, targetTile.positionY);
                currentLevel.Hero.SetDoubleDamage(1);
                targetTile = (EmptyTile)currentLevel.CreateTile(TileType.Empty, targetPosition);
                currentLevel.Tiles[targetPosition.X, targetPosition.Y] = targetTile;
            }                

            if (targetTile is ExitTile)
            {
                if (currentLevelNumber == numberOfLevels)
                {                  
                    gameState = GameState.Complete;
                    return false;
                }
                else
                {
                    UpdateVision();
                    if (currentLevel.Exit.DoorLocked == false)
                    {
                        NextLevel(); return true;
                    }
                    else
                    {
                        return false;
                    }

                }
            }
            else
            {
                if (targetTile is EmptyTile)// && (targetTile.positionX != 0 || targetTile.positionX != height) && (targetTile.positionY != 0 || targetTile.positionX != width))
                {                    
                    currentLevel.SwapTiles(heroTile, targetTile);
                    successfulMoves++;
                    UpdateVision();
                    return true;
                }
                else
                {                    
                    return false;
                }
            }

            

        }//End Of Move Hero         Commented this to make it easier to see where methods begin and end

        private void MoveEnemies()
        {

            Tile move;// Check if the enemy has a valid move
            for (int i = 0; i < currentLevel.Enemies.Length; i++) // Loop through all the enemies
            {
                EnemyTile enemy = currentLevel.Enemies[i];

                if (enemy == null || enemy.isDead == true)// Skip the enemy if it's null or dead
                {
                    continue;
                }
    
                if (enemy.GetMove(out move))
                {
                    if (move is EmptyTile && move.positionX >= 0 && move.positionX < currentLevel.getWidth && move.positionY >= 0 && move.positionY < currentLevel.getHeight)
                    {
                        currentLevel.SwapTiles(enemy, move); // Swap the enemy with the target tile
                    }

                }
            }

        }

        // ATTACK METHODS
        private bool HeroAttack(Level.Direction attack)
        {
            int attackDirec = ToInt(attack);
            currentLevel.Hero.UpdateVision(currentLevel, heroStand);
           
            if (currentLevel.Hero.Vision[attackDirec] is EnemyTile)
            {
                EnemyTile enemyTile = (EnemyTile)currentLevel.Hero.Vision[attackDirec];
                //currentLevel.Hero.Attack(enemyTile);
                if (currentLevel.Hero.DoubleDamageCount > 0)
                {
                    enemyTile.TakeDamage(currentLevel.Hero.AttackPower * 2);
                }
                enemyTile.TakeDamage(currentLevel.Hero.AttackPower);
                return true;
            }
            else
            {
                return false;
            }

        }

        public void TriggerAttack(Level.Direction trigAttack)
        {
            if( gameState == GameState.Complete || gameState == GameState.GameOver)
            {
                return; //Game is over
            }

            UpdateVision();
            int attackDirec = ToInt(trigAttack);

            if (currentLevel.Hero.Vision[attackDirec] is CharacterTile)
            {
                if (HeroAttack(trigAttack))
                {
                    // After a successful hero attack, trigger enemies' attacks
                    EnemiesAttack();
                    currentLevel.UpdateExit();

                    // Check if the hero is dead
                    if (currentLevel.Hero.isDead)
                    {
                        gameState = GameState.GameOver;
                    }
                }
            }
        }

        //ENEMY ATTACK METHODS
        private void EnemiesAttack()
        {
            for (int i = 0; i < currentLevel.Enemies.Length; i++) // Loop through all the enemies
            {
                EnemyTile enemy = currentLevel.Enemies[i];
                if (enemy == null || enemy.isDead) // Skips the enemy if it's null or dead
                {
                    continue;
                }

                CharacterTile[] targets = enemy.GetTargets();   // Gets the targets that the enemy can attack
                if (targets == null)
                {
                    continue;
                }
                else
                {
                    foreach (CharacterTile target in targets)
                    {
                        if (target is HeroTile)
                        {
                            target.TakeDamage(enemy.AttackPower); // Calculates and apply damage to the hero                            


                            if (currentLevel.Hero.HitPoints <= 0) // Checks if the hero's hit points are reduced to 0
                            {
                                gameState = GameState.GameOver;
                            }
                        }
                    }

                }

            } //endfor
        } //end of Enemies Attack


        //Enemy Spawn Method
        public int NumEnemySpawn()
        {
            switch(currentLevelNumber)
            {
                case 1: return 2;
                case 2: return 3;
                case 3: return 3;
                case 4: return 4;
                case 5: return 4;
                case 6: return 5;
                case 7: return 5;
                case 8: return 6;
                case 9: return 6;
                case 10: return 8;
                default: return 0;
            }
        }

        public void UpdateVision()
        {
            if (currentLevel.Hero != null)
            {
                currentLevel.Hero.UpdateVision(currentLevel, currentLevel.HeroPosition);
               
            }
            for(int i = 0; i < currentLevel.Enemies.Length; i++)
            {
                EnemyTile enemy;
                enemy = currentLevel.Enemies[i];
                Position enemyUnit = new Position(enemy.positionX, enemy.positionY);
                enemy.UpdateVision(currentLevel, enemyUnit);
            }
        }

        //GAME STATE METHODS
        public void NextLevel()
        {
            currentLevelNumber++;
            currentHero = currentLevel.Hero;

            if (currentLevelNumber < numberOfLevels)
            {
                while(true)
                {
                    width = random.Next(minSize, maxSize);        //every Level is Randomized
                    height = random.Next(minSize, maxSize);
                    if (height > currentHero.positionX+1 && width > currentHero.positionY+1)
                    {
                        break;
                    }
                }

                currentLevel = new Level(width, height,NumEnemySpawn(), numPickUp, currentHero);        //Creates a new CurrentLevel.
            }
        }


        //ToString Methods
        public override string ToString()       //returns currentLevel to string so it can be displayed
        {
            currentLevel.ToString();

            if (gameState == GameState.Complete)
            {
                return "Congratulations ! You have successfully completed the game."; //When Game ends, Completion Text Will display
            }
            else if (gameState == GameState.InProgress)
            {
                return currentLevel.ToString();         //when game is not finished, the next level will be Displayed
            }
            else if (gameState == GameState.GameOver)
            { 
                return "Game Over!"; // Display "Game Over!" message
            }
            else { return "Invalid GameState"; }
        }

        //UI Stats for Player
        public string HeroStats
        {
            get
            {
                if (currentLevel.Hero != null)
                {
                    int currentHitPoints = currentLevel.Hero.HitPoints;
                    int maxHitPoints = currentLevel.Hero.MaxHP;
                    return $"{currentHitPoints}/{maxHitPoints}";
                }
                return "N/A"; // Handle the case when there is no hero
            }
        }

        public string LevelStats
        {
            get
            {
                return $"{currentLevelNumber}/{numberOfLevels}";
            }
        }

        //GAME DATA METHODS
        public void SaveGame() 
        {
            int numOfLevels = numberOfLevels;
            int currentLevelNum = currentLevelNumber;
            Level level = currentLevel;
            saveGame = new SaveGameData(numOfLevels, currentLevelNum, level);

            BinaryFormatter saveFormatter = new BinaryFormatter();  //format is Binary Numbers
            using (FileStream stream = new FileStream("SaveData.bin", FileMode.Create, FileAccess.Write, FileShare.None)) //saves to file : SaveData.bin
            {
                saveFormatter.Serialize(stream, saveGame);
                MessageBox.Show("Game Saved");  //confirming with player that the game has been saved
            }

        }

        public void LoadGame()
        {

            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                using (FileStream readStream = new FileStream("SaveData.bin", FileMode.Open))
                {
                    saveGame = (SaveGameData)formatter.Deserialize(readStream);
                    currentLevel = saveGame.SaveLevel;
                    numberOfLevels = saveGame.SaveNumberOfLevels;
                    currentLevelNumber = saveGame.SaveCurrentLevelNum;

                    MessageBox.Show("Game Loaded, Press any Arrow Key To Activate"); //Message Box telling player how to Procced
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }


        }
        //Above Code adapted from StackOverFlow User Kuchuk, S.
        //Kuchuk, S. 2011. Sample Data of Seriliazation[Source code]. 
        //https://stackoverflow.com/questions/1749044/c-sharp-object-binary-serialization?rq=3 (Accessed 28 November 2023).

    }
}

 
//OLD CODE
//switch (move) //Switch and Case, depending on which Direction is Chosen
//{
//    case Direction.Up:
//        targetPosition = new Position((heroStand.X - 1), heroStand.Y);
//        break;
//    case Direction.Down:
//        targetPosition = new Position((heroStand.X + 1), heroStand.Y);
//        break;
//    case Direction.Left:
//        targetPosition = new Position(heroStand.X, (heroStand.Y - 1));
//        break;
//    case Direction.Right:
//        targetPosition = new Position(heroStand.X, (heroStand.Y + 1));
//        break;
//    case Direction.None: return false;
//    default: return false;
//}

//targetTile = currentLevel.Tiles[targetPosition.X, targetPosition.Y];
