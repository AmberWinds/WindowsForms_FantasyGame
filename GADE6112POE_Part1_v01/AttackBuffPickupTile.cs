using GADE6112POE_Part1_v01.GADE6112POE_Part1_v01;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE6112POE_Part1_v01
{
    public class AttackBuffPickupTile : PickupTile
    {
        public AttackBuffPickupTile(Position pos) : base(pos)
        {
        }

        public override void ApplyEffect(CharacterTile character)
        {
            character.SetDoubleDamage(1); // Increase double damage count by 3 (each count signifies 3 attacks)
        }

        public override string Display
        {
            get { return "*"; }
        }
    }
}
