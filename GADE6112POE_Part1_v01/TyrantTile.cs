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
                if (tyrantPos.X != vision.positionX && tyrantPos.Y != vision.positionY)
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
            while (targetTile is not WallTile) //Searching through the *X* values therefore searching through the vertical Space
            {
                int i = 1;
                targetTile.positionX += i;
                
                if (targetTile is CharacterTile)
                {
                    Targets.Add ((CharacterTile)targetTile);
                }

                targetTile.positionX-=i;
                if (targetTile is CharacterTile)
                {
                    Targets.Add((CharacterTile)targetTile);
                }

                i++;
            }//end while

            targetTile = enemyLevel.Tiles[tyrantPos.X, tyrantPos.Y];

            while (targetTile is not WallTile) //Searching through the *Y* values therefore searching through the Horizontal Space
            {
                int i = 1;
                targetTile.positionY += i;

                if(targetTile is CharacterTile)
                {
                    Targets.Add((CharacterTile)targetTile);
                }

                targetTile.positionY -= i;
                if (targetTile is CharacterTile)
                {
                    Targets.Add((CharacterTile)targetTile);
                }
                i++;
            }//end while

            return Targets.ToArray();

        }

    }
}
