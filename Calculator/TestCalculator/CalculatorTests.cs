using NUnit.Framework;
using ProjectCalculator;

namespace TestCalculator
{
    public class CalculatorTests
    {
        private Calculator calculator;
        [SetUp]
        public void Setup()
        {
            calculator = new Calculator();
        }

        [Test]
        public void AddMethod_AddEmptyString_ReturnZero()
        {
            Assert.AreEqual(Add(), calculator.Add(""));
        }

        [Test]
        public void AddMethod_AddStringWithOneNumber_ReturnValueOfNumber()
        {
            //

            //

            //
            Assert.AreEqual(Add(25), calculator.Add("25"));
        }

        [Test]
        public void AddMethod_AddStringWithTwoNumbers_ReturnCorrectSum()
        {
            Assert.AreEqual(Add(5,3), calculator.Add("5,3"));
        }

        [Test]
        public void AddMethod_AddStringWithUnknownNumbers_ReturnCorrectSum()
        {
            Assert.AreEqual(Add(1,2,3), calculator.Add("1,2,3"));
        }

        [Test]
        public void AddMethod_AddStringWithLinesBetweenNumbers_ReturnCorrectSum()
        {
            Assert.AreEqual(Add(1,2,3), calculator.Add("1\n2,3"));
        }

        [Test]
        public void AddMethod_AddStringWithDelimiter_ReturnCorrectSum()
        {
            Assert.AreEqual(Add(1, 2,3), calculator.Add("//;\n1;2;3"));
        }

        [Test]
        public void AddMethod_AddStringWithNegativesNumber_ReturnException()
        {
            var negativeNumbers = Assert.Throws<NegativeException>(() => calculator.Add("2,-5,-4")).Value;
            Assert.AreEqual(new int[] { -5,-4 }, negativeNumbers);
        }

        [Test]
        public void AddMethod_AddStringWithBigNumbers_ReturnCorrectSumOfSmall()
        {
            Assert.AreEqual(Add(2,2,2,2,2), calculator.Add("2,1050,2,2,2,2"));
        }

        [Test]
        public void AddMethod_AddStringDelimeterMoreThenOneSymbol_ReturnCorrectSum()
        {
            Assert.AreEqual(Add(1,2,2,5), calculator.Add("//[***]\n1***2***2***5"));
        }

        [Test]
        public void AddMethod_AddStringMoreThenOneDelimeter_ReturnCorrectSum()
        {
            Assert.AreEqual(Add(1,2,3,1,2), calculator.Add("//[*][%][s]\n1*2%3ss1s2s"));
        }

        [Test]
        public void AddMethod_AddStringMoreThenOneDelimeterMoreThenOneSymbol_ReturnCorrectSum()
        {
            Assert.AreEqual(Add(1, 2, 3, 1, 2), calculator.Add("//[**][%][ss]\n1**2%3ss1ss2ss"));
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