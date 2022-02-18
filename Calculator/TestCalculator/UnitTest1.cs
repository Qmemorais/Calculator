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
            Assert.AreEqual(0, calculatorAdd.Add(""));
        }

        [Test]
        public void AddStringWithOneNumber_ReturnValueOfNumber_Test1()
        {
            Assert.AreEqual(25, calculatorAdd.Add("25"));
        }

        [Test]
        public void AddStringWithOneNumber_ReturnValueOfNumber_Test2()
        {
            Assert.AreEqual(-4, calculatorAdd.Add("-4"));
        }
    }
}