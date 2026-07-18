using NUnit.Framework;
using CalcLibrary;

namespace CalcLibrary.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        private Calculator _calculator;

        [SetUp]
        public void Setup()
        {
            // Runs before EVERY test method - gives each test a fresh, clean object
            _calculator = new Calculator();
        }

        [TearDown]
        public void Teardown()
        {
            // Runs after EVERY test method - cleanup goes here if needed
            _calculator = null;
        }

        [Test]
        public void Add_TwoPositiveNumbers_ReturnsCorrectSum()
        {
            int result = _calculator.Add(5, 3);
            Assert.That(result, Is.EqualTo(8));
        }

        [TestCase(2, 3, 5)]
        [TestCase(-1, 1, 0)]
        [TestCase(0, 0, 0)]
        [TestCase(-5, -5, -10)]
        [TestCase(100, 200, 300)]
        public void Add_VariousInputs_ReturnsExpectedResult(int a, int b, int expected)
        {
            int result = _calculator.Add(a, b);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [Ignore("Subtraction tests not required for this exercise yet")]
        public void Subtract_TwoNumbers_ReturnsCorrectDifference()
        {
            int result = _calculator.Subtract(10, 4);
            Assert.That(result, Is.EqualTo(6));
        }
    }
}