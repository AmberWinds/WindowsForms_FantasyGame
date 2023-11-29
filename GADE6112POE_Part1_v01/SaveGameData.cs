using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GADE6112POE_Part1_v01
{
    [Serializable]
    public class SaveGameData
    {

        public int SaveNumberOfLevels { get; set; }
        public int SaveCurrentLevelNum { get; set; } 
        public Level SaveLevel { get; set; }
        
        public SaveGameData(int numberOfLevels, int currentLevelNum, Level currentLevel)
        { 
            SaveCurrentLevelNum = currentLevelNum;
            SaveNumberOfLevels = numberOfLevels;
            SaveLevel = currentLevel;
        }

    } 

}
