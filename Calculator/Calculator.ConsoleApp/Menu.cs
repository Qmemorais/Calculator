using Calculator.CalculatorLogic;
namespace Calculator.ConsoleApp
{
    public class Menu
    {
        private string numbers;
        readonly CalculatorLogic.Calculator calculator = new CalculatorLogic.Calculator();
        readonly WriteInformation writeRead = new WriteInformation();
        public void Add()
        {
            writeRead.Write("Enter comma separated numbers (enter to exit):");
            do
            {
                numbers = writeRead.Read();
                try
                {
                    var result = calculator.Add(numbers);
                    writeRead.Write($"Result is: {result}");
                }
                catch (NegativeException ex)
                {
                    writeRead.Write("negatives not allowed" +
                        $"\n{string.Join(", ", ex.Value)}");
                }
                writeRead.Write("You can enter other numbers (enter to exit)");
            } while (true);
        }
    }
}
