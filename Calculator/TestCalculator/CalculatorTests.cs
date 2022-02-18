using NUnit.Framework;
using Calculator;

namespace TestCalculator
{
    public class CalculatorTests
    {
        private CalculatorAdd calculatorAdd;
        [SetUp]
        public void Setup()
        {
            calculatorAdd = new CalculatorAdd();
        }

        [Test]
        public void AddMethod_AddEmptyString_ReturnZero()
        {
            Assert.AreEqual(Add(), calculatorAdd.Add(""));
        }

        [Test]
        public void AddMethod_AddStringWithOneNumber_ReturnValueOfNumber()
        {
            //

            //

            //
            Assert.AreEqual(Add(25), calculatorAdd.Add("25"));
        }

        [Test]
        public void AddMethod_AddStringWithTwoNumbers_ReturnCorrectSum()
        {
            Assert.AreEqual(Add(5,3), calculatorAdd.Add("5,3"));
        }

        [Test]
        public void AddMethod_AddStringWithUnknownNumbers_ReturnCorrectSum()
        {
            Assert.AreEqual(Add(1,2,3), calculatorAdd.Add("1,2,3"));
        }

        [Test]
        public void AddMethod_AddStringWithLinesBetweenNumbers_ReturnCorrectSum()
        {
            Assert.AreEqual(Add(1,2,3), calculatorAdd.Add("1\n2,3"));
        }

        [Test]
        public void AddMethod_AddStringWithDelimiter_ReturnCorrectSum()
        {
            Assert.AreEqual(Add(1, 2,3), calculatorAdd.Add("//;\n1;2;3"));
        }

        [Test]
        public void AddMethod_AddStringWithNegativesNumber_ReturnException()
        {
            var negativeNumbers = Assert.Throws<NegativeException>(() => calculatorAdd.Add("2,-5,-4")).Value;
            Assert.AreEqual(new int[] { -5,-4 }, negativeNumbers);
        }

        [Test]
        public void AddMethod_AddStringWithBigNumbers_ReturnCorrectSumOfSmall()
        {
            Assert.AreEqual(Add(2,2,2,2,2), calculatorAdd.Add("2,1050,2,2,2,2"));
        }

        [Test]
        public void AddMethod_AddStringDelimeterMoreThenOneSymbol_ReturnCorrectSum()
        {
            Assert.AreEqual(Add(1,2,2,5), calculatorAdd.Add("//[***]\n1***2***2***5"));
        }

        [Test]
        public void AddMethod_AddStringMoreThenOneDelimeter_ReturnCorrectSum()
        {
            Assert.AreEqual(Add(1,2,3,1,2), calculatorAdd.Add("//[*][%][s]\n1*2%3ss1s2s"));
        }

        [Test]
        public void AddMethod_AddStringMoreThenOneDelimeterMoreThenOneSymbol_ReturnCorrectSum()
        {
            Assert.AreEqual(Add(1, 2, 3, 1, 2), calculatorAdd.Add("//[**][%][ss]\n1**2%3ss1ss2ss"));
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