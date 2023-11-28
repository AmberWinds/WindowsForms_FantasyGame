using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE6112POE_Part1_v01
{
    [Serializable]
    internal class WarlockTile : EnemyTile
    {
        protected const int hitPoints = 10;
        protected const int attack = 5;
        private Tile[] warlockVision;
        private Position currentPosition;
        private List <CharacterTile> Targets;

        //Constructor
        public WarlockTile(Position warLockPosition, Level enemyLevel) : base (warLockPosition, hitPoints, attack, enemyLevel)
        {
            warlockVision = new Tile[8];
            currentPosition = warLockPosition;
            Targets = new List <CharacterTile> ();
        }
        //Override Display
        public override char Display
        {
            get { if (isDead) { return 'x'; } else { return 'ᐂ'; } } //if Warlock is dead returns a 'x'
        }

        public override bool GetMove(out Tile move)
        {
            move = null;
            return false;
        }

        public override CharacterTile[] GetTargets()
        {
            //Filling the Warlocks Vision Array
            warlockVision[0] = enemyLevel.Tiles[currentPosition.X -1, currentPosition.Y ];      //Warlock UP
            warlockVision[1] = enemyLevel.Tiles[currentPosition.X, currentPosition.Y + 1];      //Warlock RIGHT
            warlockVision[2] = enemyLevel.Tiles[currentPosition.X + 1, currentPosition.Y];      //Warlock DOWN
            warlockVision[3] = enemyLevel.Tiles[currentPosition.X, currentPosition.Y - 1];      //Warlock LEFT
            warlockVision[4] = enemyLevel.Tiles[currentPosition.X-1, currentPosition.Y + 1];    //Warlock UP - RIGHT 
            warlockVision[5] = enemyLevel.Tiles[currentPosition.X - 1, currentPosition.Y - 1];  //Warlock UP - LEFT
            warlockVision[6] = enemyLevel.Tiles[currentPosition.X +1, currentPosition.Y+1];     //Warlock DOWN - RIGHT
            warlockVision[7] = enemyLevel.Tiles[currentPosition.X +1, currentPosition.Y-1];     //Warlock DOWN - LEFT

            for (int i = 0; i < warlockVision.Length; i++)
            {
                if (warlockVision[i] is CharacterTile)
                {
                    Targets.Add((CharacterTile)warlockVision[i]);
                }
            }

            return Targets.ToArray();
        }

    }
}
