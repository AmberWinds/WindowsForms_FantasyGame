using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using static GADE6112POE_Part1_v01.Level;

namespace GADE6112POE_Part1_v01
{
    internal class GameEngine
    {
        private Level currentLevel;             //stores current level
        private int numberOfLevels;             //number of Levels
        private Random random = new Random();   //used with constants to determine size of the Level.
        private int width;
        private int height;
        private int levelnumber = 1;
        private HeroTile currentHero;
        private Position heroStand;
        //private int enemySpawn;   Commenting out as it is Unused at the Moment
        private GameState gameState = GameState.InProgress;
        private int successfulMoves = 0; // Field to count successful moves
        private int currentLevelNumber = 1; // Added field to track current level number
        private int numPickUp = 1;

        //constants
        private const int maxSize = 20;
        private const int minSize = 10;

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
            //heroStats = currentLevel.Hero.HitPoints;
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
           UpdateVision();
           if (gameState == GameState.GameOver || gameState == GameState.Complete)
           {
                return; // Game is over, do nothing
           }

            MoveHero(move);

        // Checks if it's time to move enemies (every 2 successful moves)
            if (successfulMoves >= 2 )
            {
                MoveEnemies();
                successfulMoves = 0;
            }
            
        }
        private bool MoveHero(Level.Direction move)
        {
            heroStand = currentLevel.HeroPosition;
            Tile heroTile = currentLevel.Tiles[currentLevel.HeroPosition.X, currentLevel.HeroPosition.Y];
            Console.WriteLine(" \nHeroPosition from Level Class: " + currentLevel.HeroPosition.X + " " + currentLevel.HeroPosition.Y);
            Tile targetTile;
            Position targetPosition;
            int numVision = ToInt(move);

            //New Switch and case Using Vision Methods
            //sets the Target Position, based on the position of the Hero.          //I don't know why it breaks, I've done eberything, and i still don't know, The problem appears to be coming from the the Vision arrays code but the same Code also Works except when it doesn't and I don't kniw what to do
            switch (numVision)
            {
                case 0: targetTile = currentLevel.Hero.Vision[0]; break;
                case 1: targetTile = currentLevel.Hero.Vision[1]; break;
                case 2: targetTile = currentLevel.Hero.Vision[2]; break;
                case 3: targetTile = currentLevel.Hero.Vision[3]; break;
                case 4: return false;
                    default:    return false;
            }


            //Testing
            Console.WriteLine("\n" + move);
            Console.WriteLine("(MoveHero)Hero Position from heroTile: " + heroTile.positionX + " " + heroTile.positionY);
            Console.WriteLine("(MoveHero)TargetPosition from targetTile: " + targetTile.positionX + " " + targetTile.positionY);

            if (targetTile is HealthPickupTile)
            {
                targetPosition = new Position(targetTile.positionX, targetTile.positionY);
                currentLevel.Hero.Heal(5);
                targetTile = (EmptyTile)currentLevel.CreateTile(TileType.Empty, targetPosition);
                currentLevel.Tiles[targetPosition.X, targetPosition.Y] = targetTile;

            }

            if (targetTile is ExitTile)
            {
                if (levelnumber == numberOfLevels)
                {
                    gameState = GameState.Complete;
                    return false;
                }
                else
                {
                    NextLevel(); return true;
                }
            }
            else
            {
                if (targetTile is EmptyTile)// && (targetTile.positionX != 0 || targetTile.positionX != height) && (targetTile.positionY != 0 || targetTile.positionX != width))
                {
                    currentLevel.SwapTiles(heroTile, targetTile);
                    successfulMoves++;
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

            for (int i = 0; i < currentLevel.Enemies.Length; i++) // Loop through all the enemies
            {
                EnemyTile enemy = currentLevel.Enemies[i];

                if (enemy == null || enemy.isDead() == true)// Skip the enemy if it's null or dead
                {
                    continue;
                }

                Tile move;// Check if the enemy has a valid move
                if (enemy.GetMove(out move))
                {
                    if (move is EmptyTile)
                    {
                        currentLevel.SwapTiles(enemy, move); // Swap the enemy with the target tile
                    }

                }
            }

        }

        //HERO ATTACK METHODS
        private bool HeroAttack(Level.Direction attack)
        {
            currentLevel.Hero.UpdateVision(currentLevel, heroStand);
            int attackDirec = ToInt(attack);
            EnemyTile enemyTile = (EnemyTile)currentLevel.Hero.Vision[attackDirec];
           // Console.WriteLine("HeroAttack Attack Direc: "+ attackDirec+ "Direction: "+ attack);

            enemyTile.TakeDamage(currentLevel.Hero.AttackPower);
            return true;
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

                    // Check if the hero is dead
                    if (currentLevel.Hero.isDead())
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
            {;
                EnemyTile enemy = currentLevel.Enemies[i];
                if (enemy == null || enemy.isDead()) // Skips the enemy if it's null or dead
                {
                    continue;
                }

                CharacterTile[] targets = enemy.GetTargets();   // Gets the targets that the enemy can attack
                if (targets == null)
                {
                    Console.WriteLine("targets is Null");
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
            switch(levelnumber)
            {
                case 1: return 2;
                case 2: return 3;
                case 3: return 4;
                case 4: return 5;
                case 5: return 5;
                case 6: return 6;
                case 7: return 7;
                case 8: return 8;
                case 9: return 9;
                case 10: return 10;
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
            levelnumber++;
            currentHero = currentLevel.Hero;

            if (levelnumber < numberOfLevels)
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
