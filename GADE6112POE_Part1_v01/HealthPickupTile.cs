using GADE6112POE_Part1_v01.GADE6112POE_Part1_v01;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE6112POE_Part1_v01
{
    class HealthPickupTile : PickupTile
    {
        public HealthPickupTile(Position position) : base(position)
        {
        }

        public override void ApplyEffect(CharacterTile target)
        {
            target.Heal(10);
        }

        public override char Display // please help with this error
        {
            get { return '+'; }
        }
    }
}
