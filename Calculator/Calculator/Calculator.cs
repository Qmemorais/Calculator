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
            numbers = numbers.Replace(@"\n", "\n");
            Delimetres(numbers, out List<int> values);

            return Sum(values);
        }

        private List<int> Delimetres(string stringToSplit, out List<int> values)
        {
            string[] valuesString;

            if (stringToSplit.Contains("//"))
            {
                List<string> symbolToSplit = stringToSplit.Split(new string[] { "//","\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
                string numbers = symbolToSplit.Last();
                symbolToSplit.Remove(symbolToSplit.Last());
                string valuesToSplit = symbolToSplit.First();

                if (valuesToSplit.Contains('[') && valuesToSplit.Contains(']'))
                {
                    string delimeter = "";

                    for (int i = 0; i < valuesToSplit.Length; i++)
                    {
                        if (valuesToSplit[i] == '[' && delimeter == "")
                        {
                            i++;
                            do
                            {
                                delimeter += valuesToSplit[i];
                                i++;
                            } while (i != valuesToSplit.Length - 1
                            && valuesToSplit.IndexOf('[', i) - valuesToSplit.IndexOf(']', i) != 1
                            && i != valuesToSplit.IndexOf(']', i));
                        }
                        symbolToSplit.Add(delimeter);
                        delimeter = "";
                    }
                }

                valuesString = numbers.Split(symbolToSplit.ToArray(), StringSplitOptions.RemoveEmptyEntries);
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
            if (values.Any(x => x < 0))
            {
                throw new NegativeException("negatives not allowed", values);
            }

            int sum = 0;
            sum = values
                .Where(x => x > 0 && x < 1000)
                .Sum();

            return sum;
        }
    }
}
