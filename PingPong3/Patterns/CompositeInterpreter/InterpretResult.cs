using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong3.Patterns.CompositeInterpreter
{
    public class InterpretResult
    {
        public Number value;
        public Error error;
        public InterpretResult()
        {

        }
        public InterpretResult(Number value, Error error)
        {
            this.value = value;
            this.error = error;
        }
        public Number register(InterpretResult res)
        {
            if(res.error != null)
            {
                error = res.error;
            }
            return res.value;
        }
        public InterpretResult success(Number value)
        {
            this.value = value;
            return this;
        }
        public InterpretResult failure(Error error)
        {
            this.error = error;
            return this;
        }
    }
}
