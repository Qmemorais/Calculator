using NUnit.Framework;
using Calculator;

namespace TestCalculator
{
    public class Tests
    {
        private CalculatorAdd calculatorAdd;
        [SetUp]
        public void Setup()
        {
            calculatorAdd = new();
        }

        [Test]
        public void AddEmptyString_Return_0()
        {
            Assert.AreEqual(Add(), calculatorAdd.Add(""));
        }

        [Test]
        public void AddStringWithOneNumber_ReturnValueOfNumber_Test1()
        {
            Assert.AreEqual(Add(25), calculatorAdd.Add("25"));
        }

        [Test]
        public void AddStringWithOneNumber_ReturnValueOfNumber_Test2()
        {
            Assert.AreEqual(Add(4), calculatorAdd.Add("4"));
        }

        [Test]
        public void AddStringWithTwoNumbers_ReturnSum_Test1()
        {
            Assert.AreEqual(Add(14,3), calculatorAdd.Add("14,3"));
        }

        [Test]
        public void AddStringWithTwoNumbers_ReturnSum_Test2()
        {
            Assert.AreEqual(Add(5,3), calculatorAdd.Add("5,3"));
        }

        [Test]
        public void AddStringWithUnknownNumbers_ReturnSum_Test1()
        {
            Assert.AreEqual(Add(4,2,10), calculatorAdd.Add("4,2,10"));
        }

        [Test]
        public void AddStringWithUnknownNumbers_ReturnSum_Test2()
        {
            Assert.AreEqual(Add(4, 2, 10, 5, 14, 7), calculatorAdd.Add("4,2,10,5,14,7"));
        }

        [Test]
        public void AddStringWithLinesBetweenNumbers_ReturnSum_Test1()
        {
            Assert.AreEqual(Add(1,5,7), calculatorAdd.Add("1\n5,7"));
        }

        [Test]
        public void AddStringWithDelimiter_ReturnSum_Test1()
        {
            Assert.AreEqual(Add(1, 5, 7), calculatorAdd.Add("//;\n1;5;7"));
        }

        [Test]
        public void AddStringWithNegativesNumber_ReturnException_Test1()
        {
            var negativeNumbers = Assert.Throws<NegativeException>(() => calculatorAdd.Add("2,-5,-4")).Value;
            Assert.AreEqual(new int[] { -5,-4 }, negativeNumbers);
        }

        [Test]
        public void AddStringWithBigNumbers_ReturnsumOfSmall_Test1()
        {
            Assert.AreEqual(Add(1,2,3,4,5,6,7,8,9), calculatorAdd.Add("1,1050,2,3,4,5,6,7,8,9"));
        }

        private int Add(params int[] n)
        {
            int sum = 0;
            foreach (int i in n)
                sum += i;
            return sum;
        }
    }
}