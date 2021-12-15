using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PingPong3.Patterns.Factory;

namespace PingPong3.Patterns.Iterator
{
    public class LevelDataCollection : IIterableCollection
    {
        public List<Wall> walls;

        public LevelDataCollection()
        {
            this.walls = new List<Wall>();
        }

        public IIterator CreateIterator()
        {
            throw new NotImplementedException();
        }

        public void Add(Wall wall)
        {
            walls.Add(wall);
        }

        public int Count()
        {
            return walls.Count;
        }
    }
}
