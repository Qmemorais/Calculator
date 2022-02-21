using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectCalculator
{
    public class Calculator
    {
        public int Add(string numbers)
        {
            return Sum(Delimetres(numbers, out List<int> values));
        }

        private List<int> Delimetres(string stringToSplit, out List<int> values)
        {
            if (stringToSplit.Length == 0)
            {
                return values = new List<int>();
            }

            string[] valuesString;

            if (stringToSplit.Contains("//"))
            {
                List<string> symbolToSplit = stringToSplit.Split(new string[] { "//", "[", "]", "\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
                string numbers = symbolToSplit.Last();
                symbolToSplit.Remove(symbolToSplit.Last());
                symbolToSplit.Add(",");
                valuesString = numbers
                .Split(symbolToSplit.ToArray(), StringSplitOptions.RemoveEmptyEntries);
            }
            else
            {
                valuesString = stringToSplit.Split(new string[] { "\n", "," }, StringSplitOptions.RemoveEmptyEntries);
            }

            values = valuesString.Select(x => int.Parse(x)).ToList();

            return values;
        }

        private int Sum(List<int> values)
        {
            int sum = 0;
            sum = values.Where(x => x > 0 && x < 1000).Sum();

            if (values.Any(x => x < 0))
            {
                throw new NegativeException("negatives not allowed", values);
            }

            return sum;
        }
    }
}
