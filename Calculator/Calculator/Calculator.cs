using System;
using System.Collections.Generic;
using System.Linq;

namespace Calculator.ProjectCalculator
{
    public class Calculator
    {
        public int Add(string numbers)
        {
            if (numbers.Length == 0)
            {
                return 0;
            }

            List<int> values = Delimetres(numbers);

            return Sum(values);
        }

        private List<int> Delimetres(string stringToSplit)
        {
            string[] valuesString;

            if (stringToSplit.Contains("//"))
            {
                string numbers = stringToSplit.Split(new string[] { "]\n", @"]\n", "\n", @"\n"}, StringSplitOptions.RemoveEmptyEntries).ToList().Last();
                string valuesToSplit = stringToSplit.Split(new string[] { "]\n", @"]\n", "\n", @"\n" }, StringSplitOptions.RemoveEmptyEntries).ToList().First();
                var symbolToSplit = valuesToSplit.Split(new string[] { "//[", "//", "][" }, StringSplitOptions.RemoveEmptyEntries);
                valuesString = numbers.Split(symbolToSplit, StringSplitOptions.RemoveEmptyEntries);
            }
            else
            {
                valuesString = stringToSplit.Split(new string[] { @"\n", "\n", "," }, StringSplitOptions.RemoveEmptyEntries);
            }

            var values = valuesString.Select(x => int.Parse(x)).ToList();

            return values;
        }

        private int Sum(List<int> values)
        {
            if (values.Any(x => x < 0))
            {
                throw new NegativeException("negatives not allowed", values);
            }

            int sum = values
                .Where(x => x > 0 && x < 1000)
                .Sum();

            return sum;
        }
    }
}
