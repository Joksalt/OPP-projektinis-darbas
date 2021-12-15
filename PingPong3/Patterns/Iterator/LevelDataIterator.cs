using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PingPong3.Patterns.Factory;

namespace PingPong3.Patterns.Iterator
{
    public class LevelDataIterator : IIterator
    {
        List<Wall> walls;
        int pos = 0;

        public LevelDataIterator(List<Wall> walls)
        {
            this.walls = walls;
        }

        //Returns wall's texture
        public object GetNext()
        {
            var wall = this.walls[pos];
            pos++;
            return wall.Texture;
        }

        public bool HasNext()
        {
            return pos < this.walls.Count();
        }
    }
}
