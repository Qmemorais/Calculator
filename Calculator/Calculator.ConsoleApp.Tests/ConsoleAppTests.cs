using NUnit.Framework;
using Moq;

namespace Calculator.ConsoleApp.Tests
{
    public class ConsoleAppTests
    {
        Menu menu;
        Mock<IWriteRead> writeRead = new Mock<IWriteRead>();
        Mock<CalculatorLogic.ICalculator> calculator = new Mock<CalculatorLogic.ICalculator>();

        [Test]
        public void MenuAdd_InputEmptyString_ReturnZero()
        {
            //
            var readLine = "";
            var writeLineRes = "Result is: 0";
            var writeLineNextInput = "You can enter other numbers (enter to exit)";
            writeRead.Setup(x => x.Read()).Returns(readLine);
            calculator.Setup(x => x.Add(readLine)).Returns(0);
            menu = new Menu(writeRead.Object, calculator.Object);
            //
            menu.Add();
            //
            writeRead.Verify(x => x.Write(writeLineRes), Times.Once);
            writeRead.Verify(x => x.Write(writeLineNextInput), Times.Once);
        }
    }
}
