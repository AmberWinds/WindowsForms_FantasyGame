using System;
using System.Collections.Generic;
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
        private int enemySpawn;
        GameState gameState = GameState.InProgress;

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
            currentLevel = new Level(width, height, NumEnemySpawn());
        }


        //Method that converts the Enum into a Number
        public int ToInt(Level.Direction direction) //method converts the Direction enum into a number that can be used for the CharacterVision Array
        {
            //Console.WriteLine(direction);         //console output for debugging purposes
            int dirVision = 4;
            if (direction == Direction.Up) { dirVision = 0; }
            else if (direction == Direction.Right) { dirVision = 1; }
            else if (direction == Direction.Down) { dirVision = 2; }
            else if (direction == Direction.Left) { dirVision = 3; }
            else if (direction == Direction.None) { dirVision = 4; }

            return dirVision;       //returns the int value
        }

        //MOVEMENT
        public void TriggerMovement(Level.Direction move)
        {
            MoveHero(move);
        }
        private bool MoveHero(Level.Direction move)
        {
            Position heroStand = currentLevel.HeroPosition;
            Tile heroTile = currentLevel.Tiles[currentLevel.HeroPosition.X, currentLevel.HeroPosition.Y];
            Console.WriteLine(" \nHeroPosition from Level Class: " + currentLevel.HeroPosition.X + " " + currentLevel.HeroPosition.Y);
            Tile targetTile;
            Position targetPosition;

            //sets the Target Position, based on the position of the Hero.
            switch (move) //Switch and Case, depending on which Direction is Chosen
            {
                case Direction.Up:
                    targetPosition = new Position((heroStand.X - 1), heroStand.Y);
                    break;
                case Direction.Down:
                    targetPosition = new Position((heroStand.X + 1), heroStand.Y);
                    break;
                case Direction.Left:
                    targetPosition = new Position(heroStand.X, (heroStand.Y - 1));
                    break;
                case Direction.Right:
                    targetPosition = new Position(heroStand.X, (heroStand.Y + 1));
                    break;
                case Direction.None: return false;
                default: return false;
            }

            targetTile = currentLevel.Tiles[targetPosition.X, targetPosition.Y];

            //Testing
            Console.WriteLine("\n"+ move);
            Console.WriteLine("(MoveHero)Hero Position from heroTile: "+ heroTile.positionX+" "+ heroTile.positionY);
            Console.WriteLine("(MoveHero)TargetPosition from targetTile: " + targetTile.positionX + " " + targetTile.positionY);

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
                if (targetTile is EmptyTile && (targetTile.positionX != 0 || targetTile.positionX != height) && (targetTile.positionY != 0 || targetTile.positionX != width))
                {
                    currentLevel.SwapTiles(heroTile, targetTile);
                    currentLevel.Hero.UpdateVision(currentLevel, currentLevel.HeroPosition);
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }//End Of Move Hero         Commented this to make it easier to see.

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

                currentLevel = new Level(width, height,NumEnemySpawn(), currentHero);        //Creates a new CurrentLevel.
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
                return "GAME OVER";         //When the Game is lost, Game Over is Displayed
            }
            else { return "Invalid GameState"; }
        }



    }
}
