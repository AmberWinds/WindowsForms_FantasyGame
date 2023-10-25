using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE6112POE_Part1_v01
{
    using System;

    namespace GADE6112POE_Part1_v01
    {
        abstract class PickupTile : Tile
        {
            public PickupTile(Position position) : base(position)
            {
            }

            // Abstract method to apply the effect of the pickup to a target character
            public abstract void ApplyEffect(CharacterTile target);
        }
    }

}
