using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong3.Patterns.CompositeInterpreter
{
    public abstract class Node
    {
        public virtual Node add(Node node)
        {
            return null;
        }
        public virtual Node remove(Node node)
        {
            return null;
        }
        public virtual Node get(int i)
        {
            return null;
        }
    }
}
