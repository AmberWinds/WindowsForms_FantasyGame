using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE6112POE_Part1_v01
{
    public abstract class CharacterTile : Tile
    {
        //variables
        private int attackPower;
        private int hitPoints;
        private int maxHP;
        private Tile[] visionArray;

        //CONSTRUCTOR
        public CharacterTile(Position pos, int hitPonts, int atkPower) : base(pos)
        {
            hitPoints = hitPonts;
            maxHP = hitPonts;
            attackPower = atkPower;
            visionArray = new Tile[4];
        }
        //PROPERTIES
        public Tile[] Vision { get { return visionArray; } set { visionArray = value; } }
        public int AttackPower { get {  return attackPower; }  }
        public int HitPoints { get { return hitPoints; } set {  hitPoints = value; } }
        public int MaxHP {  get { return maxHP; } }
        //Methods
        public void UpdateVision(Level vision, Position currentPosition)
        {
            //bool canMoveUp = currentPosition.X < vision.getHeight -1 && currentPosition.X > 1;
            //bool canMoveDown = currentPosition.X < vision.getHeight - 1 && currentPosition.X > 0;
            //bool canMoveRight = currentPosition.Y < vision.getWidth - 1 && currentPosition.Y > 0;
            //bool canMoveLeft = currentPosition.X < vision.getWidth - 1 && currentPosition.Y > 1;

            //if Cannot Move, Vision remains Unchanged.
            visionArray[0] = vision.Tiles[currentPosition.X - 1, currentPosition.Y]; //Up Tile 
            visionArray[1] = vision.Tiles[currentPosition.X, currentPosition.Y+1]; //Right Tile 
            visionArray[2] = vision.Tiles[currentPosition.X + 1, currentPosition.Y]; //Down Tile 
            visionArray[3] = vision.Tiles[currentPosition.X, currentPosition.Y - 1]; //Left Tile
   
        }//end of Update Vision 

        public void TakeDamage(int damage)
        {
            hitPoints -= damage;
            if (hitPoints <= 0)
            {
                hitPoints = 0;
                //isDead;
            }
        }

        public void Heal(int amount)
        {
            hitPoints += amount;
            if (hitPoints > maxHP)
            {
                hitPoints = maxHP;
            }
        }


        public void Attack(CharacterTile opponent)
        {
            TakeDamage(opponent.attackPower);
        }

        public bool isDead //method to check if the character HP is sufficient to continue playing
        {
            get
            {
                if (hitPoints <= 0) { return true; } else { return false; } //Hp is 0 or less, character is dead and unable to continue playing.
            }
        }//end of isDead


    }
}
