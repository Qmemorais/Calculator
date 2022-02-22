using Calculator.CalculatorLogic;
namespace Calculator.ConsoleApp
{
    public class Menu
    {
        private string numbers;
        private readonly IWriteRead writeRead;
        readonly ICalculator calculator;

        public Menu(IWriteRead _writeRead, ICalculator _calculator)
        {
            writeRead = _writeRead;
            calculator = _calculator;
        }

        public Menu()
        {
            writeRead = new WriteInformation();
            calculator = new CalculatorLogic.Calculator();
        }

        public void Info()
        {
            do
            {
                Add();
            }
            while (true);
        }

        public void Add()
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
        }
    }
}
