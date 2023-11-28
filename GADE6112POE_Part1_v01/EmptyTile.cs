using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE6112POE_Part1_v01
{
    [Serializable]
    public class EmptyTile : Tile // class inherits from tile class
    {
        private char emptyTile = '.';
        public EmptyTile(Position x) : base(x)
        {

        }
        public override char Display { get { return emptyTile; } } //Sets '.' as an EmptyTile and sends data to display as an additional display function
    }
}
