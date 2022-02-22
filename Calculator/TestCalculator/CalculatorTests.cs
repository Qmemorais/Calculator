using NUnit.Framework;

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
            //
            int sumToEqual = Add(5, 3);
            //
            var result = calculator.Add("5,3");
            //
            Assert.AreEqual(sumToEqual, result);
        }

        [Test]
        public void AddMethod_AddStringWithUnknownNumbers_ReturnCorrectSum()
        {
            //
            int sumToEqual = Add(1, 2, 3);
            //
            var result = calculator.Add("1,2,3");
            //
            Assert.AreEqual(sumToEqual, result);
        }

        [Test]
        public void AddMethod_AddStringWithLinesBetweenNumbers_ReturnCorrectSum()
        {
            //
            int sumToEqual = Add(1, 2, 3);
            //
            var result = calculator.Add("1\n2,3");
            //
            Assert.AreEqual(sumToEqual, result);
        }

        [Test]
        public void AddMethod_AddStringWithDelimiter_ReturnCorrectSum()
        {
            //
            int sumToEqual = Add(1, 2, 3);
            //
            var result = calculator.Add("//;\n1;2;3");
            //
            Assert.AreEqual(sumToEqual,result);
        }

        [Test]
        public void AddMethod_AddStringWithNegativesNumber_ReturnException()
        {
            //

            //

            //
            var negativeNumbers = Assert.Throws<NegativeException>(() => calculator.Add("2,-5,-4")).Value;
            Assert.AreEqual(new int[] { -5,-4 }, negativeNumbers);
        }

        [Test]
        public void AddMethod_AddStringWithBigNumbers_ReturnCorrectSumOfSmall()
        {
            //
            int sumToEqual = Add(2, 2, 2, 2, 2);
            //
            var result = calculator.Add("2,1050,2,2,2,2");
            //
            Assert.AreEqual(sumToEqual,result);
        }

        [Test]
        public void AddMethod_AddStringDelimeterMoreThenOneSymbol_ReturnCorrectSum()
        {
            //
            int sumToEqual = Add(1, 2, 2, 5);
            //
            var result = calculator.Add("//[***]\n1***2***2***5");
            //
            Assert.AreEqual(sumToEqual,result);
        }

        [Test]
        public void AddMethod_AddStringMoreThenOneDelimeter_ReturnCorrectSum()
        {
            //
            int sumToEqual = Add(1, 2, 3, 1, 2);
            //
            var result = calculator.Add("//[*][%][s]\n1*2%3ss1s2s");
            //
            Assert.AreEqual(sumToEqual,result);
        }

        [Test]
        public void AddMethod_AddStringMoreThenOneDelimeterMoreThenOneSymbol_ReturnCorrectSum()
        {
            //
            int sumToEqual = Add(1, 2, 3, 1, 2);
            //
            var result = calculator.Add("//[**][%][ss]\n1**2%3ss1ss2ss");
            //
            Assert.AreEqual(sumToEqual,result);
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