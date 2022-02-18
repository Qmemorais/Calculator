using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectCalculator
{
    public class NegativeException : ArgumentException
    {
        public List<int> Value { get; }
        public NegativeException(string message, List<int> val)
            : base(message)
        {
            Value = val.Where(x => x < 0).ToList();
        }
    }
}
