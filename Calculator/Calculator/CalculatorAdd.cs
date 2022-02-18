using System;
using System.Collections.Generic;
using System.Linq;

namespace Calculator
{
    public class CalculatorAdd
    {
        public int Add(string numbers)
        {
            if (numbers.IndexOf("//") != -1)
                return Sum(Delimetres(numbers, out string[] values));
            else
                return Sum(numbers.Split(new char[] { ',', '\n' }));
        }

        private string[] Delimetres(string new_str, out string[] values)
        {
            var symbolToSplit = new_str.Substring(2, 1);
            values = new_str.Substring(4).Split(symbolToSplit);
            return values;
        }

        private int Sum(string[] _values)
        {
            var values = new List<int>();
            int sum = 0;
            foreach (var i in _values)
                if (int.TryParse(i, out int res))
                    values.Add(res);
            foreach (var i in values)
                if (i < 0)
                    throw new NegativeException("negatives not allowed", values.ToArray());
                else
                    if (i < 1000)
                    sum += i;
            return sum;
        }
    }

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
