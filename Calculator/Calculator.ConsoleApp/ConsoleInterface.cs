using Calculator.CalculatorLogic;

namespace Calculator.ConsoleApp
{
    public class ConsoleInterface
    {
        private readonly IConsoleInOut _consoleInOut = new ConsoleInOut();
        private readonly CalculatorLogic.Calculator _calculator = new CalculatorLogic.Calculator();
        private string _numbers;

        public ConsoleInterface(IConsoleInOut writeRead, CalculatorLogic.Calculator calculator)
        {
            _consoleInOut = writeRead;
            _calculator = calculator;
        }

        public ConsoleInterface()
        {

        }

        public void Start()
        {
            _consoleInOut.Write("Enter comma separated numbers (enter to exit):");

            while(true)
            {
                CallCalculatorMethodAdd();
            }
        }

        public void CallCalculatorMethodAdd()
        {
            _numbers = _consoleInOut.Read();
           
            try
            {
                var result = _calculator.Add(_numbers);

                _consoleInOut.Write($"Result is: {result}");
            }
            catch (NegativeException ex)
            {
                _consoleInOut.Write($"negatives not allowed \n{string.Join(", ", ex.Value)}");
            
            }
            _consoleInOut.Write("You can enter other numbers (enter to exit)");
        }
    }
}
