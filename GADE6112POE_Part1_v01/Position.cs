using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE6112POE_Part1_v01
{
    public class Position
    {
        private int xCoord;
        private int yCoord;

        public Position(int x, int y)
        {
            xCoord = x;
            yCoord = y;

            X = x; Y = y;
        }

        public int X { get { return xCoord; }  set { xCoord = value; } }
        public int Y { get { return yCoord; } set { yCoord = value; } }
    }
}
