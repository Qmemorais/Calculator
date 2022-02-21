using System;
using Calculator.ProjectCalculator;

namespace Calculator.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter comma separated numbers (enter to exit)");
            Menu();
        }

        public static void Menu()
        {
            ProjectCalculator.Calculator calculator = new ProjectCalculator.Calculator();

            do
            {
                try
                {
                    string numbers = Console.ReadLine();
                    if (numbers.Equals("?")) return;
                    try
                    {
                        var result = calculator.Add(numbers);
                        Console.WriteLine($"Result is: {result}");
                    }
                    catch (NegativeException ex)
                    {
                        Console.WriteLine("negatives not allowed" +
                            $"\n{string.Join(", ", ex.Value)}");
                    }
                    Console.WriteLine("You can enter other numbers (enter to exit)");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("You can enter other numbers (enter to exit)");
                }

            } while (true);
        }
    }
}
