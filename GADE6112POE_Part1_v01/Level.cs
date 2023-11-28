using GADE6112POE_Part1_v01.GADE6112POE_Part1_v01;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE6112POE_Part1_v01
{
    [Serializable]
    public class Level
    {
        //private variables
        private Tile[,] tiles;
        private int width;
        private int height;
        private HeroTile hero;
        private Position heroPosition;
        private ExitTile exit;
        private EnemyTile[] enemies;
        private PickupTile[] pickupTiles;

        //Properties
        public int getWidth { get { return width; } }
        public int getHeight { get { return height; } }
        public Tile[,] Tiles { get { return tiles; } }
        public HeroTile Hero { get { return hero; } }
        public Position HeroPosition { get { return heroPosition; } set { heroPosition = value; } }
        public ExitTile Exit { get { return exit; } }
        public PickupTile[] PickupTiles { get { return pickupTiles; } }
        public EnemyTile[] Enemies { get { return enemies; } }                   //error Resolved: EnemyTile had to be Public


        //Constructor
        public Level(int  width, int height, int numEnemies, int numPickUps, HeroTile heroLevel = null) //error Resolved: Optional Parameters must always be Last
        {
            this.width = width;
            this.height = height;
            tiles = new Tile[width, height];
            InitialiseTiles();

            hero = heroLevel;

            enemies = new EnemyTile[numEnemies];
            for (int i = 0; i < numEnemies; i++)
            {
                Position enemyPosition = GetRandomEmptyPosition();
                CreateEnemyTile(enemyPosition);
                enemies[i] = (EnemyTile)CreateTile(TileType.Enemy, enemyPosition);
                tiles[enemyPosition.X, enemyPosition.Y] = enemies[i];

            }

            pickupTiles = new PickupTile[numPickUps];
            for (int i = 0; i < numPickUps; i++)
            {
                Position pickUpPosition = GetRandomEmptyPosition();
                pickupTiles[i] = (HealthPickupTile)CreateTile(TileType.PickUp, pickUpPosition);
                tiles[pickUpPosition.X, pickUpPosition.Y] = pickupTiles[i];
            }

            //Q4.3
            if (heroLevel == null)   //if hero == null, will set a new HeroTile
            {
                Position newheroPosition = GetRandomEmptyPosition();
                hero = (HeroTile)CreateTile(TileType.Hero, newheroPosition);
                tiles[newheroPosition.X, newheroPosition.Y] = hero;
                heroPosition = newheroPosition;

            }
            else if (heroLevel != null)
            {
                if (heroLevel.HerosPlace.X >= 0 && heroLevel.HerosPlace.X < height && heroLevel.HerosPlace.Y >= 0 && heroLevel.HerosPlace.Y < width)
                {
                    Position newheroPosition = GetRandomEmptyPosition();
                    hero = (HeroTile)CreateTile(TileType.Hero, newheroPosition);
                    tiles[newheroPosition.X, newheroPosition.Y] = hero;
                    heroPosition = newheroPosition;
                }
                else
                {
                    hero = (HeroTile)CreateTile(TileType.Hero, heroLevel.HerosPlace);
                    tiles[heroLevel.HerosPlace.X, heroLevel.HerosPlace.Y] = hero;
                    heroPosition = heroLevel.HerosPlace;
                }

            }

            Position exitPosition = GetRandomEmptyPosition();
            exit = (ExitTile)CreateTile(TileType.Exit, exitPosition);
            tiles[exitPosition.X, exitPosition.Y] = exit;

        }
        //Enums
        public enum TileType        //enum sets Tiles to specific tileTypes in the level, can be distinguished in code.
        {
            Empty,
            Wall,
            Hero,
            Exit,
            Enemy,  // Added Enemy here
            PickUp,
        }
        public enum Direction       //Direction enum, used when a players inputs a direction key to Move.
        {
            Up,
            Right,
            Down,
            Left,
            None,
        }


        //Methods Public
        public Tile CreateTile(TileType tileType, Position position)
        {
            switch (tileType)
            {
                case TileType.Empty: // Use correct case for enum values
                    return new EmptyTile(position);
                case TileType.Wall:
                    return new WallTile(position);
                case TileType.Hero:
                    return new HeroTile(position);
                case TileType.Exit:
                    return new ExitTile(position);
                default:
                    return new EmptyTile(position);
                case TileType.Enemy:  // this case is for creating GruntTile
                    return CreateEnemyTile(position);
                case TileType.PickUp:
                    return new HealthPickupTile(position);
            }
        }//end of Method

        public void SwapTiles(Tile tileMoving, Tile tileTarget)
        {

            //Swap the tiles in the 2D array
            Tile tileTemp;
            Console.WriteLine("\nheroPosition in Swap (Level Class): "+ heroPosition.X + " "+ heroPosition.Y);
            Console.WriteLine("tileMoving in Swap: " + tileMoving.positionX + " " + tileMoving.positionY);
            Console.WriteLine("targetTile in Swap: " + tileTarget.positionX + " " + tileTarget.positionY);

            if (tileMoving.positionX >= 0 && tileMoving.positionX < width && tileMoving.positionY >= 0 && tileMoving.positionY < height)
            {
                if (tileTarget.positionX >= 0 && tileTarget.positionX < width && tileTarget.positionY >= 0 && tileTarget.positionY < height) //tests if TargetTile is Valid Before Swap
                {
                    tileTemp = tiles[tileMoving.positionX, tileMoving.positionY];                                      //Local Variable is being used to Store an Array of tiles [tilex.x , tilex.y]
                    tiles[tileMoving.positionX, tileMoving.positionY] = tiles[tileTarget.positionX, tileTarget.positionY];
                    tiles[tileTarget.positionX, tileTarget.positionY] = tileTemp; //tileTemp

                    //Update the x and y positions of the tiles
                    tileMoving.positionX = tileTarget.positionX;
                    tileMoving.positionY = tileTarget.positionY;

                    tileTarget.positionX = tileMoving.positionY;
                    tileTarget.positionY = tileMoving.positionY;
                }
            }
        }

        public void UpdateExit()
        {
            int deadCount = 0;
            foreach (var enemy in enemies)
            {
                if (enemy.isDead)
                {
                    deadCount++;
                }
            }

            if (deadCount == enemies.Length)
            {
                exit.DoorLocked = false;
            }
        }



        //Methods Private

        private EnemyTile CreateEnemyTile(Position enemyPosition)
        {
            Random random = new Random();
            int spawn = random.Next(101);

            if (spawn <= 50)
            {
                 return new GruntTile(enemyPosition, this);
            }
            else if (spawn > 50 && spawn <= 80)
            {
                return new WarlockTile(enemyPosition, this);
            }
            else
            {
                return new TyrantTile(enemyPosition, this);
            }
        }


        private void InitialiseTiles()
        {
            for (int x = 0; x < width; x++)     //forloop searches through the 2D array and sets Wall and EmptyTiles
            {
                for (int y = 0; y < height; y++)
                {
                    if (x == 0 || x == width - 1 || y == height - 1 || y == 0)
                    {
                        tiles[x, y] = CreateTile(TileType.Wall, new Position(x, y)); // if the tile is on the boundary of the level creates a wall tile
                    }
                    else
                    {
                        tiles[x, y] = CreateTile(TileType.Empty, new Position(x, y)); //otherwise it will create an empty tile
                    }
                }
            }//end for

        }// end of Initialise Tiles Method

        private Position GetRandomEmptyPosition()
        {
            Random random = new Random();
            Position position;
            int xRandom;
            int yRandom;
            do
            {
                xRandom = random.Next(1, width - 1);
                yRandom = random.Next(1, height - 1);
                if (tiles[xRandom, yRandom] is EmptyTile)       //tests if random x and y is an emptyTile,
                {
                    position = new Position(xRandom, yRandom);                  //finds the emptytile sets new Position.                                                            
                    break;                                                      //breaks out of loop
                }
            } while (true);
            return position;
        }

        //To String Methods
        public override string ToString()
        {
            StringBuilder buildString = new StringBuilder(); //Stringbuilder creates the setup for the gameboard
            for (int k = 0; k < width; k++)
            {
                buildString.AppendLine();           //moves EmptyTile to the next line to build the string
                for (int J = 0; J < height; J++)
                {
                    buildString.Append(tiles[k, J].Display);
                }
            }
            return buildString.ToString();
        }

    }//end of Level Class
}
