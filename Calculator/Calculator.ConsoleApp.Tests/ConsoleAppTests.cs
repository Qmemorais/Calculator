using NUnit.Framework;
using Moq;
using Calculator.CalculatorLogic;
using System.Collections.Generic;

namespace Calculator.ConsoleApp.Tests
{
    public class ConsoleAppTests
    {
        Menu menu;
        Mock<IWriteRead> writeRead;
        Mock<CalculatorLogic.ICalculator> calculator;
        private readonly string writeLineNextInput = "You can enter other numbers (enter to exit)";

        [SetUp]
        public void Setup()
        {
            writeRead = new Mock<IWriteRead>();
            calculator = new Mock<CalculatorLogic.ICalculator>();
        }

        [Test]
        public void MenuAdd_InputEmptyString_ReturnZero()
        {
            //
            var readLine = "";
            var writeLineRes = "Result is: " + Add(0);
            writeRead.Setup(x => x.Read()).Returns(readLine);
            calculator.Setup(x => x.Add(readLine)).Returns(0);
            menu = new Menu(writeRead.Object, calculator.Object);
            //
            menu.Add();
            //
            writeRead.Verify(x => x.Write(writeLineRes), Times.Once);
            writeRead.Verify(x => x.Write(writeLineNextInput), Times.Once);
        }

        [Test]
        public void MenuAdd_InputCorrectOneValue_ReturnCorrectValue()
        {
            //
            var readLine = "25";
            var writeLineRes = "Result is: " + Add(25);
            writeRead.Setup(x => x.Read()).Returns(readLine);
            calculator.Setup(x => x.Add(readLine)).Returns(25);
            menu = new Menu(writeRead.Object, calculator.Object);
            //
            menu.Add();
            //
            writeRead.Verify(x => x.Write(writeLineRes), Times.Once);
            writeRead.Verify(x => x.Write(writeLineNextInput), Times.Once);
        }

        [Test]
        public void MenuAdd_InputCorrectTwoValues_ReturnCorrectSum()
        {
            //
            var readLine = "5,3";
            var writeLineRes = "Result is: " + Add(5, 3);
            writeRead.Setup(x => x.Read()).Returns(readLine);
            calculator.Setup(x => x.Add(readLine)).Returns(Add(5, 3));
            menu = new Menu(writeRead.Object, calculator.Object);
            //
            menu.Add();
            //
            writeRead.Verify(x => x.Write(writeLineRes), Times.Once);
            writeRead.Verify(x => x.Write(writeLineNextInput), Times.Once);
        }

        [Test]
        public void MenuAdd_InputUnknownValueOfNumbers_ReturnCorrectSum()
        {
            //
            var readLine = "1,2,3";
            var writeLineRes = "Result is: " + Add(1, 2, 3);
            writeRead.Setup(x => x.Read()).Returns(readLine);
            calculator.Setup(x => x.Add(readLine)).Returns(Add(1, 2, 3));
            menu = new Menu(writeRead.Object, calculator.Object);
            //
            menu.Add();
            //
            writeRead.Verify(x => x.Write(writeLineRes), Times.Once);
            writeRead.Verify(x => x.Write(writeLineNextInput), Times.Once);
        }

        [Test]
        public void MenuAdd_InputValuesAndSlash_ReturnCorrectSum()
        {
            //
            var readLine = "1\n2,3";
            var writeLineRes = "Result is: " + Add(1, 2, 3);
            writeRead.Setup(x => x.Read()).Returns(readLine);
            calculator.Setup(x => x.Add(readLine)).Returns(Add(1, 2, 3));
            menu = new Menu(writeRead.Object, calculator.Object);
            //
            menu.Add();
            //
            writeRead.Verify(x => x.Write(writeLineRes), Times.Once);
            writeRead.Verify(x => x.Write(writeLineNextInput), Times.Once);
        }

        [Test]
        public void MenuAdd_InputOneDelimeter_ReturnCorrectSum()
        {
            //
            var readLine = "//;\n1;2;3";
            var writeLineRes = "Result is: " + Add(1, 2, 3);
            writeRead.Setup(x => x.Read()).Returns(readLine);
            calculator.Setup(x => x.Add(readLine)).Returns(Add(1, 2, 3));
            menu = new Menu(writeRead.Object, calculator.Object);
            //
            menu.Add();
            //
            writeRead.Verify(x => x.Write(writeLineRes), Times.Once);
            writeRead.Verify(x => x.Write(writeLineNextInput), Times.Once);
        }

        [Test]
        public void MenuAdd_InputNegativeValue_ReturnException()
        {
            //
            var readLine = "2,-5,-4";
            var writeLineRes = "Result is: " + Add(2);
            var exception = new NegativeException("negatives not allowed" +
                    $"\n{string.Join(", ", new List<int>() { -5, -4 })}", new List<int>() { -5, -4 });
            writeRead.Setup(x => x.Read()).Returns(readLine);
            calculator.Setup(x => x.Add(readLine))
                .Throws(new NegativeException("", new List<int>() { -5, -4 }));
            menu = new Menu(writeRead.Object, calculator.Object);
            //
            menu.Add();
            //
            writeRead.Verify(x => x.Write(writeLineNextInput), Times.Once);
            writeRead.Verify(x => x.Write(exception.Message), Times.Once);
            writeRead.Verify(x => x.Write(writeLineRes), Times.Never);

        }

        [Test]
        public void MenuAdd_InputValuesMoreThenThousand_ReturnCorrectSum()
        {
            //
            var readLine = "2,1050,2,2,2,2";
            var writeLineRes = "Result is: " + Add(2, 2, 2, 2, 2);
            writeRead.Setup(x => x.Read()).Returns(readLine);
            calculator.Setup(x => x.Add(readLine)).Returns(Add(2, 2, 2, 2, 2));
            menu = new Menu(writeRead.Object, calculator.Object);
            //
            menu.Add();
            //
            writeRead.Verify(x => x.Write(writeLineRes), Times.Once);
            writeRead.Verify(x => x.Write(writeLineNextInput), Times.Once);
        }

        private int Add(params int[] n)
        {
            int sum = 0;
            foreach (int i in n)
            {
                sum += i;
            }
            return sum;
        }

    }
}
