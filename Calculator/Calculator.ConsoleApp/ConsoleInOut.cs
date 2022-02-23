using System;

namespace Calculator.ConsoleApp
{
    public class ConsoleInOut : IConsoleInOut
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
