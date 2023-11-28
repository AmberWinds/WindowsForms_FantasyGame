using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE6112POE_Part1_v01
{
    [Serializable]
    public class HeroTile : CharacterTile
    {
        private int hitPoints = 40;
        private Position heroPlace;
        private int attack = 5;
        public HeroTile(Position heroPosition) : base(heroPosition, 40, 5)
        {
            heroPlace = heroPosition;
        }

        public override char Display
        {
            get { if (isDead) { return 'x'; } else { return '▼'; } } //if hero is dead returns a 'x'
        }

        public Position HerosPlace { get { return heroPlace; } set { heroPlace = value; } }

    }
}
