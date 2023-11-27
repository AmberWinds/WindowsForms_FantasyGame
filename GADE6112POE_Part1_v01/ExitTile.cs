using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE6112POE_Part1_v01
{
    public class ExitTile : Tile
    {
        private bool doorLocked;
        public ExitTile(Position exit) : base(exit)
        {

        }

        public bool DoorLocked { get { return doorLocked; } }
        public override char Display //Sets '▒' as an ExitTile and sends data to display as an additional display function
        {
            get { if (DoorLocked) { return '▓'; } else { return '▒'; } }
        }
    }
}
