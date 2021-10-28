using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong3.Patterns.Prototype
{
    public interface IPrototype
    {
        IPrototype DeepCopy();
        IPrototype ShallowCopy();
    }
}
