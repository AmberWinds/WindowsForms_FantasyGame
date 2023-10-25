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
        //CONSTRUCTOR
        public EnemyTile(Position enemyUnit, int hitP, int attackPower) : base(enemyUnit, hitP, attackPower)
        {

        }

        public Position Position { get; internal set; }

        //METHODS
        public abstract bool GetMove(out Tile move);

        public abstract CharacterTile[] GetTargets();


    }
}
