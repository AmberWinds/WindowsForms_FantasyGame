using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE6112POE_Part1_v01
{
    [Serializable]
    abstract public class Tile
    {
        private Position tilePosition;
        public int positionX { get { return tilePosition.X; } set { tilePosition.X = value; } }
        public int positionY { get { return tilePosition.Y; } set { tilePosition.Y = value; } }

        public Tile(Position tilePosition)
        {
            this.tilePosition = tilePosition;
        }
        public abstract char Display //used to display the output of the Classes onto the Form
        {
            get;
        }
        public Tile changeTile(Tile toChange, Tile newTilePostion) //Set Method that sets input to new tile position
        {
            return toChange = newTilePostion;
        }
    }
}
