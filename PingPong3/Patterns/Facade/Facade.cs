using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PingPong3.Patterns.Prototype;

namespace PingPong3.Patterns.Facade
{
    public class Facade
    {
        public void DemoPrototype(Form1 form)
        {
            BallItem ballShallowCopy = (BallItem)form._ball.ShallowCopy();
            BallItem ballDeepCopy = (BallItem)form._ball.DeepCopy();
            Console.WriteLine($"This is original Ball. Hash code - {form._ball.GetHashCode()}");
            Console.WriteLine($"This is a shallow copy of ball. Hash code - {ballShallowCopy.GetHashCode()}");
            Console.WriteLine($"This is a deep copy of ball. Hash code {ballDeepCopy.GetHashCode()}");
        }
    }
}
