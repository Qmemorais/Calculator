using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Calculator.CalculatorLogic.Tests
{
    public class CalculatorTests
    {
        private Calculator calculator;
        [SetUp]
        public void Setup()
        {
            calculator = new Calculator();
        }

        [TestCase("", ExpectedResult = 0)]
        public int Add_AddEmptyString_ReturnZero(string res)
        {
            return calculator.Add(res);
        }

        [TestCase("25", ExpectedResult = 25)]
        public int Add_AddStringWithOneNumber_ReturnValueOfNumber(string res)
        {
            return calculator.Add(res);
        }

        [Test]
        public void AddMethod_AddStringWithTwoNumbers_ReturnCorrectSum()
        {
            //arrange
            var testValues = new List<int> { 5, 3 } ;
            var expectedRes = testValues.Sum();
            //act
            var result = calculator.Add("5,3");
            //assert
            Assert.AreEqual(expectedRes, result);
        }

        [Test]
        public void AddMethod_AddStringWithUnknownNumbers_ReturnCorrectSum()
        {
            //arrange
            var testValues = new List<int> { 1, 2, 3 };
            var expectedRes = testValues.Sum();
            //act
            var result = calculator.Add("1,2,3");
            //assert
            Assert.AreEqual(expectedRes, result);
        }

        [Test]
        public void AddMethod_AddStringWithLinesBetweenNumbers_ReturnCorrectSum()
        {
            //arrange
            var testValues = new List<int> { 1, 2, 3 };
            var expectedRes = testValues.Sum();
            //act
            var result = calculator.Add("1\n2,3");
            //assert
            Assert.AreEqual(expectedRes, result);
        }

        [Test]
        public void AddMethod_AddStringWithDelimiter_ReturnCorrectSum()
        {
            //arrange
            var testValues = new List<int> { 1, 2, 3 };
            var expectedRes = testValues.Sum();
            //act
            var result = calculator.Add("//;\n1;2;3");
            //assert
            Assert.AreEqual(expectedRes,result);
        }

        [Test]
        public void AddMethod_AddStringWithNegativesNumber_ReturnException()
        {
            //assert
            var negativeNumbers = Assert.Throws<NegativeException>(() => calculator.Add("2,-5,-4")).Value;
            Assert.AreEqual(new int[] { -5,-4 }, negativeNumbers);
        }

        [Test]
        public void AddMethod_AddStringWithBigNumbers_ReturnCorrectSumOfSmall()
        {
            //arrange
            var testValues = new List<int> { 2, 2, 2, 2, 2 };
            var expectedRes = testValues.Sum();
            //act
            var result = calculator.Add("2,1050,2,2,2,2");
            //assert
            Assert.AreEqual(expectedRes,result);
        }

        [Test]
        public void AddMethod_AddStringDelimeterMoreThenOneSymbol_ReturnCorrectSum()
        {
            //arrange
            var testValues = new List<int> { 1, 2, 2, 5 };
            var expectedRes = testValues.Sum();
            //act
            var result = calculator.Add("//[***]\n1***2***2***5");
            //assert
            Assert.AreEqual(expectedRes,result);
        }

        [Test]
        public void AddMethod_AddStringMoreThenOneDelimeter_ReturnCorrectSum()
        {
            //arrange
            var testValues = new List<int> { 1, 2, 3, 1, 2 };
            var expectedRes = testValues.Sum();
            //act
            var result = calculator.Add("//[*][%][s]\n1*2%3ss1s2s");
            //assert
            Assert.AreEqual(expectedRes,result);
        }

        [Test]
        public void AddMethod_AddStringMoreThenOneDelimeterMoreThenOneSymbol_ReturnCorrectSum()
        {
            //arrange
            var testValues = new List<int> { 1, 2, 3, 1, 2 };
            var expectedRes = testValues.Sum();
            //act
            var result = calculator.Add("//[**][%][ss]\n1**2%3ss1ss2ss");
            //assert
            Assert.AreEqual(expectedRes,result);
        }
    }
}