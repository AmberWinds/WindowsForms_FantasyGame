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
        private int saveNumberOfLevels;
        private int saveCurrentLevelNum;
        private Level saveLevel;

        public int SaveNumberOfLevels { get { return SaveNumberOfLevels; } set { SaveNumberOfLevels = value} }
        public int SaveCurrentLevelNum {  get { return saveCurrentLevelNum; }  set { SaveCurrentLevelNum = value} }
        public Level SaveLevel { get {  return saveLevel; } }
        
        public SaveGameData( int saveNumofLevel, int saveLevelnum, Level saveLevel)
        {
            
            saveNumberOfLevels = saveNumofLevel;
            saveCurrentLevelNum = saveLevelnum;
            this.saveLevel = saveLevel;
        }

    } 

}
