using System;
using System.Collections.Generic;
using System.Linq;

namespace Calculator.CalculatorLogic
{
    public class Calculator
    {
        private List<int> values = new List<int>();

        public int Add(string numbers)
        {
            if (numbers.Length == 0)
            {
                return 0;
            }

            Delimetres(numbers);

            return Sum();
        }

        private void Delimetres(string stringToSplit)
        {
            string[] valuesString;

            var splitBySymbolsToFindNumbersAndDelimeter = new string[] { "]\n", @"]\n", "\n", @"\n", "," };
            var splitDelimetersBuySimbols = new string[] { "//[", "//", "][" };

            if (stringToSplit.Contains("//"))
            {
                string numbers = stringToSplit
                    .Split(splitBySymbolsToFindNumbersAndDelimeter, StringSplitOptions.RemoveEmptyEntries)
                    .ToList().Last();
                string valuesToSplit = stringToSplit
                    .Split(splitBySymbolsToFindNumbersAndDelimeter, StringSplitOptions.RemoveEmptyEntries)
                    .ToList().First();
                var symbolToSplit = valuesToSplit
                    .Split(splitDelimetersBuySimbols, StringSplitOptions.RemoveEmptyEntries);
                valuesString = numbers
                    .Split(symbolToSplit, StringSplitOptions.RemoveEmptyEntries);
            }
            else
            {
                valuesString = stringToSplit
                    .Split(splitBySymbolsToFindNumbersAndDelimeter, StringSplitOptions.RemoveEmptyEntries);
            }

            values = valuesString
                .Select(x => int.Parse(x))
                .ToList();
        }

        private int Sum()
        {
            if (values.Any(x => x < 0))
            {
                throw new NegativeException("negatives not allowed", values);
            }

            int sum = values
                .Where(x => x < 1000)
                .Sum();

            return sum;
        }
    }
}
