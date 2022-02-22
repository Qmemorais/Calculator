using System;

namespace Calculator.ConsoleApp
{
    public class WriteInformation
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
