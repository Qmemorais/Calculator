using System;

namespace Calculator.ProjectCalculator.ConsoleApp
{
    class Menu
    {
        readonly Calculator calculator = new Calculator();
        public void Add()
        {
            Console.WriteLine("Enter comma separated numbers (enter to exit):");
            do
            {
                try
                {
                    string numbers = Console.ReadLine();
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

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    Console.WriteLine("You can enter other numbers (enter to exit)");
                }
            } while (true);
        }
    }
}
