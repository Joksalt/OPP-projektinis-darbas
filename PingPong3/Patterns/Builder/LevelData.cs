using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PingPong3.Patterns.Factory;

namespace PingPong3.Patterns.Builder
{
    public class LevelData
    {
        //string levelName;
        public List<Wall> walls;
        public LevelData()
        {
            walls = new List<Wall>();
        }
        public LevelData(List<Wall> walls)
        {
            this.walls = walls;
        }
        public void SetWalls(List<Wall> walls)
        {
            this.walls = walls;
        }
    }
}
