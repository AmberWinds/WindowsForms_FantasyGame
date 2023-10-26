using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE6112POE_Part1_v01
{
    public class HeroTile : CharacterTile
    {
        internal int hitPoints = 40;
        Position heroPlace;
        public HeroTile(Position heroPosition) : base(heroPosition, 40, 5)
        {
            heroPlace = heroPosition;
        }

        public override char Display
        {
            get { if (isDead()) { return 'x'; } else { return '▼'; } } //if hero is dead returns a 'x'
        }

        public Position HerosPlace { get { return heroPlace; } }

        public int maxHitPoints { get; internal set; }
    }
}
