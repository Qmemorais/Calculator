using NUnit.Framework;
using Moq;
using Calculator.CalculatorLogic;
using System.Collections.Generic;
using System.Linq;

namespace Calculator.ConsoleApp.Tests
{
    public class ConsoleAppTests
    {
        private Mock<IConsoleInOut> _consoleInOut;
        private Mock<CalculatorLogic.Calculator> _calculator;
        private readonly string _writeLineNextInput = "You can enter other numbers (enter to exit)";
        private ConsoleInterface _consoleInterface;

        [SetUp]
        public void Setup()
        {
            _consoleInOut = new Mock<IConsoleInOut>();
            _calculator = new Mock<CalculatorLogic.Calculator>();
            _consoleInterface = new ConsoleInterface(_consoleInOut.Object, _calculator.Object);
        }

        [TestCase()]
        public void MenuAdd_InputEmptyString_ReturnZero()
        {
            //arrange
            var readLine = "";
            var writeLineRes = "Result is: 0";

            _consoleInOut
                .Setup(x => x.Read())
                .Returns(readLine);
            _calculator
                .Setup(x=>x.Add(readLine))
                .Returns(0);
            //act
            _consoleInterface.CallCalculatorMethodAdd();
            //assert
            _consoleInOut.Verify(x => x.Write(writeLineRes), Times.Once);
            _consoleInOut.Verify(x => x.Write(_writeLineNextInput), Times.Once);
        }

        [Test]
        public void MenuAdd_InputCorrectOneValue_ReturnCorrectValue()
        {
            //arrange
            var readLine = "25";
            var writeLineRes = "Result is: 25";

            _consoleInOut
                .Setup(x => x.Read())
                .Returns(readLine);
            _calculator
                .Setup(x => x.Add(readLine))
                .Returns(25);
            //act
            _consoleInterface.CallCalculatorMethodAdd();
            //assert
            _consoleInOut.Verify(x => x.Write(writeLineRes), Times.Once);
            _consoleInOut.Verify(x => x.Write(_writeLineNextInput), Times.Once);
        }

        [Test]
        public void MenuAdd_InputCorrectTwoValues_ReturnCorrectSum()
        {
            //arrange
            var testValues = new List<int> { 5, 3 };
            var expectedRes = testValues.Sum();
            var readLine = "5,3";
            var writeLineRes = $"Result is: {expectedRes}";

            _consoleInOut
                .Setup(x => x.Read())
                .Returns(readLine);
            _calculator
                .Setup(x => x.Add(readLine))
                .Returns(expectedRes);
            //act
            _consoleInterface.CallCalculatorMethodAdd();
            //assert
            _consoleInOut.Verify(x => x.Write(writeLineRes), Times.Once);
            _consoleInOut.Verify(x => x.Write(_writeLineNextInput), Times.Once);
        }

        [Test]
        public void MenuAdd_InputUnknownValueOfNumbers_ReturnCorrectSum()
        {
            //arrange
            var testValues = new List<int> { 1, 2, 3 };
            var expectedRes = testValues.Sum();
            var readLine = "1,2,3";
            var writeLineRes = $"Result is: {expectedRes}";

            _consoleInOut
                .Setup(x => x.Read())
                .Returns(readLine);
            _calculator
               .Setup(x => x.Add(readLine))
               .Returns(expectedRes);
            //act
            _consoleInterface.CallCalculatorMethodAdd();
            //assert
            _consoleInOut.Verify(x => x.Write(writeLineRes), Times.Once);
            _consoleInOut.Verify(x => x.Write(_writeLineNextInput), Times.Once);
        }

        [Test]
        public void MenuAdd_InputValuesAndSlash_ReturnCorrectSum()
        {
            //arrange
            var testValues = new List<int> { 1, 2, 3 };
            var expectedRes = testValues.Sum();
            var readLine = "1\n2,3";
            var writeLineRes = $"Result is: {expectedRes}";

            _consoleInOut
                .Setup(x => x.Read())
                .Returns(readLine);
            _calculator
              .Setup(x => x.Add(readLine))
              .Returns(expectedRes);
            //act
            _consoleInterface.CallCalculatorMethodAdd();
            //assert
            _consoleInOut.Verify(x => x.Write(writeLineRes), Times.Once);
            _consoleInOut.Verify(x => x.Write(_writeLineNextInput), Times.Once);
        }

        [Test]
        public void MenuAdd_InputOneDelimeter_ReturnCorrectSum()
        {
            //arrange
            var testValues = new List<int> { 1, 2, 3 };
            var expectedRes = testValues.Sum();
            var readLine = "//;\n1;2;3";
            var writeLineRes = $"Result is: {expectedRes}";

            _consoleInOut
                .Setup(x => x.Read())
                .Returns(readLine);
            _calculator
              .Setup(x => x.Add(readLine))
              .Returns(expectedRes);
            //act
            _consoleInterface.CallCalculatorMethodAdd();
            //assert
            _consoleInOut.Verify(x => x.Write(writeLineRes), Times.Once);
            _consoleInOut.Verify(x => x.Write(_writeLineNextInput), Times.Once);
        }

        [Test]
        public void MenuAdd_InputNegativeValue_ReturnExceptionMessageAndValues()
        {
            //arrange
            var readLine = "2,-5,-4";
            var exception = new NegativeException($"negatives not allowed \n{string.Join(", ", new List<int> { -5, -4 })}", new List<int>() { -5, -4 });

            _consoleInOut
                .Setup(x => x.Read())
                .Returns(readLine);
            _calculator
             .Setup(x => x.Add(readLine))
             .Throws(new NegativeException("", new List<int>() { -5, -4 }));
            //act
            _consoleInterface.CallCalculatorMethodAdd();
            //assert
            _consoleInOut.Verify(x => x.Write(_writeLineNextInput), Times.Once);
            _consoleInOut.Verify(x => x.Write(exception.Message), Times.Once);
        }

        [Test]
        public void MenuAdd_InputValuesMoreThenThousand_ReturnCorrectSum()
        {
            //arrange
            var testValues = new List<int> { 2, 2, 2, 2, 2 };
            var expectedRes = testValues.Sum();
            var readLine = "2,1050,2,2,2,2";
            var writeLineRes = $"Result is: {expectedRes}";

            _consoleInOut
                .Setup(x => x.Read())
                .Returns(readLine);
            _calculator
              .Setup(x => x.Add(readLine))
              .Returns(expectedRes);
            //act
            _consoleInterface.CallCalculatorMethodAdd();
            //assert
            _consoleInOut.Verify(x => x.Write(writeLineRes), Times.Once);
            _consoleInOut.Verify(x => x.Write(_writeLineNextInput), Times.Once);
        }

        [Test]
        public void MenuAdd_InputDelimeterMoreThenOneSymbol_ReturnCorrectSum()
        {
            //arrange
            var testValues = new List<int> { 1, 2, 2, 5 };
            var expectedRes = testValues.Sum();
            var readLine = "//[***]\n1***2***2***5";
            var writeLineRes = $"Result is: {expectedRes}";

            _consoleInOut
                .Setup(x => x.Read())
                .Returns(readLine);
            _calculator
              .Setup(x => x.Add(readLine))
              .Returns(expectedRes);
            //act
            _consoleInterface.CallCalculatorMethodAdd();
            //assert
            _consoleInOut.Verify(x => x.Write(writeLineRes), Times.Once);
            _consoleInOut.Verify(x => x.Write(_writeLineNextInput), Times.Once);
        }

        [Test]
        public void MenuAdd_InputMoreThenOneDelimeter_ReturnCorrectSum()
        {
            //arrange
            var testValues = new List<int> { 1, 2, 3, 1, 2 };
            var expectedRes = testValues.Sum();
            var readLine = "//[*][%][s]\n1*2%3ss1s2s";
            var writeLineRes = $"Result is: {expectedRes}";

            _consoleInOut
                .Setup(x => x.Read())
                .Returns(readLine);
            _calculator
              .Setup(x => x.Add(readLine))
              .Returns(expectedRes);
            //act
            _consoleInterface.CallCalculatorMethodAdd();
            //assert
            _consoleInOut.Verify(x => x.Write(writeLineRes), Times.Once);
            _consoleInOut.Verify(x => x.Write(_writeLineNextInput), Times.Once);
        }

        [Test]
        public void MenuAdd_InputMoreThenOneDelimeterMoreThenOneSymbol_ReturnCorrectSum()
        {
            //arrange
            var testValues = new List<int> { 1, 2, 3, 1, 2 };
            var expectedRes = testValues.Sum();
            var readLine = "//[**][%][ss]\n1**2%3ss1ss2ss";
            var writeLineRes = $"Result is: {expectedRes}";

            _consoleInOut
                .Setup(x => x.Read())
                .Returns(readLine);
            _calculator
              .Setup(x => x.Add(readLine))
                .Returns(expectedRes);
            //act
            _consoleInterface.CallCalculatorMethodAdd();
            //assert
            _consoleInOut.Verify(x => x.Write(writeLineRes), Times.Once);
            _consoleInOut.Verify(x => x.Write(_writeLineNextInput), Times.Once);
        }
    }
}
