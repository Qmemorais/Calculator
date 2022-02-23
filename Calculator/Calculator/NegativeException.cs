using System;
using System.Collections.Generic;
using System.Linq;

namespace Calculator.CalculatorLogic
{
    public class NegativeException : ArgumentException
    {
        public IEnumerable<int> Value { get; }

        public NegativeException(string message, IEnumerable<int> val) : base(message)
        {
            Value = val.Where(x => x < 0);
        }
    }
}
