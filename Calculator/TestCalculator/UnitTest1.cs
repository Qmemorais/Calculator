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
    }
}