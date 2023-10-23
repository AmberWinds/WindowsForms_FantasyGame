using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE6112POE_Part1_v01
{
    internal class WallTile : Tile
    {
        public WallTile(Position wallPosition) : base(wallPosition) { }
        public override char Display  //Sets '█' as an WallTile and sends data to display as an additional display function
        {
            get { return '█'; }
        }
    }
}
