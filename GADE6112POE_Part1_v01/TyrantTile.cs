using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE6112POE_Part1_v01
{
    internal class TyrantTile : EnemyTile
    {
        private const int hitPoints = 15;
        private const int attack = 5;
        private Position tyrantPos;
        private List <CharacterTile> Targets;
        private Tile targetTile;

        //Constructor
        public TyrantTile(Position tyrantPosition, Level enemyLevel) : base (tyrantPosition, hitPoints, attack, enemyLevel)
        {
            tyrantPos = tyrantPosition;
            Targets = new List<CharacterTile> ();
            targetTile = enemyLevel.Tiles[tyrantPosition.X, tyrantPosition.Y];
        }

        public override char Display
        {
            get { if (isDead()) { return 'x'; } else { return '§'; } } //if Warlock is dead returns a 'x'
        }

        public override bool GetMove(out Tile move) //Tyrant must Move towards the Hero Tile.
        {
            foreach (var vision in enemyLevel.Hero.Vision)
            {
                if (vision is EmptyTile)
                {
                    move = vision;
                    return true;
                }
            }

            move = null;
            return false;
        }

        public override CharacterTile[] GetTargets()
        {
            //int controllers for the while Loops
            for (int i = 1; i < enemyLevel.getWidth-1; i++) //Searching through the *X* values therefore searching through the vertical Space
            {
                for (int j = 1; j < enemyLevel.getHeight-1; j++)
                {
                    targetTile = enemyLevel.Tiles[i, j];

                    if (targetTile is CharacterTile)
                    {
                        Targets.Add((CharacterTile)targetTile);
                    }

                }

            }//end while
            
            return Targets.ToArray();

        }

    }
}
