using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE6112POE_Part1_v01
{
    [Serializable]
    public abstract class CharacterTile : Tile
    {
        //variables
        private int attackPower;
        private int hitPoints;
        private int maxHP;
        private Tile[] visionArray;
        private int doubleDamageCount;

        //CONSTRUCTOR
        public CharacterTile(Position pos, int hitPonts, int atkPower) : base(pos)
        {
            hitPoints = hitPonts;
            maxHP = hitPonts;
            attackPower = atkPower;
            visionArray = new Tile[4];
            doubleDamageCount = 3;
        }

        //PROPERTIES
        public Tile[] Vision { get { return visionArray; } set { visionArray = value; } }
        public int AttackPower { get {  return attackPower; }  }
        public int HitPoints { get { return hitPoints; } set {  hitPoints = value; } }
        public int MaxHP {  get { return maxHP; } }
        //Methods
        public void UpdateVision(Level vision, Position currentPosition)
        {
            if (currentPosition != null)
            {
                //tests to see if Character can move
                bool canMoveUp = currentPosition.X > 0;
                bool canMoveDown = currentPosition.X < vision.getHeight - 1;
                bool canMoveRight = currentPosition.Y < vision.getWidth - 1;
                bool canMoveLeft = currentPosition.Y > 0;

                //if Cannot Move, Vision remains Unchanged.
                visionArray[0] = canMoveUp ? vision.Tiles[currentPosition.X - 1, currentPosition.Y] : vision.Tiles[currentPosition.X, currentPosition.Y]; //Up Tile 
                visionArray[1] = canMoveRight ? vision.Tiles[currentPosition.X, currentPosition.Y + 1] : vision.Tiles[currentPosition.X, currentPosition.Y]; //Right Tile 
                visionArray[2] = canMoveDown ? vision.Tiles[currentPosition.X + 1, currentPosition.Y] : vision.Tiles[currentPosition.X + 1, currentPosition.Y]; //Down Tile 
                visionArray[3] = canMoveLeft ? vision.Tiles[currentPosition.X, currentPosition.Y - 1] : vision.Tiles[currentPosition.X, currentPosition.Y]; //Left Tile
            }



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
            if (doubleDamageCount > 0)
            {
                TakeDamage(opponent.attackPower * 2); // Apply double damage
                doubleDamageCount--; // Decrease doubleDamageCount
            }
            else
            {
                TakeDamage(opponent.attackPower); // Normal damage
            }
        }

        public bool isDead //method to check if the character HP is sufficient to continue playing
        {
            get
            {
                if (hitPoints <= 0) { return true; } else { return false; } //Hp is 0 or less, character is dead and unable to continue playing.
            }
        }//end of isDead
        public void SetDoubleDamage(int count)
        {
            doubleDamageCount += count * 3; // Multiplying count by 3 for triple attack buff stacking
        }


    }
}
