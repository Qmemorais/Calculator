using System;
using System.Linq;

namespace Calculator
{
    public class NegativeException : ArgumentException
    {
        public int[] Value { get; }
        public NegativeException(string message, params int[] val)
            : base(message)
        {
            Value = val.Where(x => x < 0).ToArray();
        }
    }
}
