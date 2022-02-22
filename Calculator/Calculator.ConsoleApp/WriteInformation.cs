using System;

namespace Calculator.CalculatorLogic.ConsoleApp
{
    class WriteInformation
    {
        public void Write(string toWrite)
        {
            Console.WriteLine(toWrite);
        }

        public string Read()
        {
            return Console.ReadLine();
        }
    }
}
