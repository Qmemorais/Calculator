using System;
using System.Collections.Generic;
using System.Linq;

namespace Calculator.CalculatorLogic
{
    public class Calculator
    {
        public int Add(string numbers)
        {
            if (numbers.Length == 0)
            {
                return 0;
            }

            var values = Delimetres(numbers);

            return Sum(values);
        }

        private List<int> Delimetres(string stringToSplit)
        {
            string[] valuesString;

            var splitBySymbolsToFindDelimeter = new string[] { "]\n", @"]\n", "\n", @"\n", "," };
            var splitDelimetersBuySimbols = new string[] { "//[", "//", "][" };

            if (stringToSplit.Contains("//"))
            {
                string numbersWhichWillBeSplitting = stringToSplit
                    .Split(splitBySymbolsToFindDelimeter, StringSplitOptions.RemoveEmptyEntries)
                    .ToList().Last();
                string StringToSplitOnDelimeters = stringToSplit
                    .Split(splitBySymbolsToFindDelimeter, StringSplitOptions.RemoveEmptyEntries)
                    .ToList().First();
                var valuesWhichSplitNumbers = StringToSplitOnDelimeters
                    .Split(splitDelimetersBuySimbols, StringSplitOptions.RemoveEmptyEntries);
                valuesString = numbersWhichWillBeSplitting
                    .Split(valuesWhichSplitNumbers, StringSplitOptions.RemoveEmptyEntries);
            }
            else
            {
                valuesString = stringToSplit
                    .Split(splitBySymbolsToFindDelimeter, StringSplitOptions.RemoveEmptyEntries);
            }

            var values = valuesString
                .Select(x => int.Parse(x))
                .ToList();

            return values;
        }

        private int Sum(List<int> values)
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
