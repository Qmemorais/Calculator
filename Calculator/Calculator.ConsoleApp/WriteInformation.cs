using System;

namespace Calculator.ProjectCalculator.ConsoleApp
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
