using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GADE6112POE_Part1_v01
{
    public abstract class EnemyTile: CharacterTile
    {
        protected Level enemyLevel;

        //CONSTRUCTOR
        public EnemyTile(Position enemyUnit, int hitPoints, int attackPower, Level enemyLevel) : base(enemyUnit, hitPoints, attackPower)
        {
            this.enemyLevel = enemyLevel;
        }

        public Position Position { get; internal set; }

        //METHODS
        public abstract bool GetMove(out Tile move);

        public abstract CharacterTile[] GetTargets();


    }
}
