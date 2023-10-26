using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE6112POE_Part1_v01
{
    internal class GruntTile : EnemyTile
    {
        //Variables
        Position gruntPosition;
        //CONSTRUCTOR
        public GruntTile(Position gruntUnit) : base(gruntUnit, 10, 1) //Position, Hp, Attack
        {
            gruntPosition = gruntUnit;
        }
        //OVERRIDE DISPLAY  
        public override char Display
        {
            get { if (isDead()) { return 'x'; } else { return 'Ϫ'; } } //if hero is dead returns a 'x'
        }


        //ABSTRACT MEMBER OVERRIDES
        public override bool GetMove(out Tile move)
        {    
            int canMove = 0;           
            for (int i = 0; i <= 3; i++)
            {
                if (Vision[i] is EmptyTile)
                {
                    canMove += 1;
                }
            }
            int randomMove = new Random().Next(0, canMove);
            if (canMove > 0)
            {
                move = Vision[randomMove];
                return true;
            }
            else
            {
                move = null;
                return false;
            }

        }

        public override CharacterTile[] GetTargets()
        {
            CharacterTile[] targets = new CharacterTile[4];
            for (int i = 0; i <= 3; i++)
            {
                if (Vision[i] is HeroTile)
                {
                    targets[i] = (CharacterTile)Vision[i];
                    return targets;
                }
                else
                {
                    continue;
                }
            }
            return targets;
        }


    }
}
