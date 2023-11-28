using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE6112POE_Part1_v01
{
    [Serializable]
    public class GameSaveData
    {
        public int NumberOfLevels { get; }
        public int CurrentLevelNumber { get; }
        public Level CurrentLevel { get; }

        public GameSaveData(int numberOfLevels, int currentLevelNumber, Level currentLevel)
        {
            NumberOfLevels = numberOfLevels;
            CurrentLevelNumber = currentLevelNumber;
            CurrentLevel = currentLevel;
        }
    }

}
