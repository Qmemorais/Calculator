namespace Calculator.ConsoleApp
{
    public interface IConsoleInOut
    {
        public void Write(string toWrite);
        public string Read();
    }
}
