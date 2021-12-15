using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong3.Patterns.CompositeInterpreter
{
    public class Number
    {
        public float value;
        public Number(float value)
        {
            this.value = value;
        }
        public InterpretResult added_to(object other)
        {
            if(other is Number)
                return new InterpretResult(new Number(this.value + (other as Number).value), null);
            return null;
        }
        public InterpretResult subbed_by(object other)
        {
            if (other is Number)
                return new InterpretResult(new Number(this.value - (other as Number).value), null);
            return null;
        }
        public InterpretResult multed_by(object other)
        {
            if (other is Number)
                return new InterpretResult(new Number(this.value * (other as Number).value), null);
            return null;
        }
        public InterpretResult dived_by(object other)
        {
            if (other is Number)
            {
                if((other as Number).value == 0)
                    return new InterpretResult(null, new Error("Runtime error: ", "Division by zero!"));
                return new InterpretResult(new Number(this.value / (other as Number).value), null);
            }
                
            return null;
        }
    }
}
