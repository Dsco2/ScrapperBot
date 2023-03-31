using API.TempService;
using NUnit.Framework;
using System;

namespace Testing
{
    public class Tests
    {
        [SetUp]
        public void Setup() {}

        [TestCase(5, 7, "+", 12)]
        [TestCase(8, 2, "/", 4)]
        [TestCase(5, 7, "*", 35)]
        [TestCase(7, 5, "-", 2)]
        [TestCase(5, 7, "-", -2)]
        [TestCase(111111111111111, 7, "-", 111111111111104)]
        [Test]
        public void Operation_singleNumber_ReturnResultOperation(long digit1, long digit2, string operation, long expected)
        {
            var result = Service.Operation(digit1, digit2, operation);
            Assert.AreEqual(expected, result);
        }


        [TestCase(12345678901234500000, 12345678901234500000)]
        [TestCase(12345678901234500000, 12345678901234500000)]
        [Test]
        public void Verify_singleNumber_ReturnInputNumber(ulong digit1, ulong expected)
        {
            var result = Service.InputNumber(digit1);
            Assert.AreEqual(expected, result);
        }


        [TestCase(12345)]
        [Test]
        public void Verify_singleNumber_ReturnEqualDisable(long digit1)
        {
            var result = Service.VerifyEqual(digit1);
            Assert.IsTrue(result);
        }


        [TestCase(5, -7, "-", -2)]
        [Test]
        public void Operation_singleNumberNegative_ButtonState(long digit1, long digit2, string operation, long expected)
        {
            var result = Service.Operation(digit1, digit2, operation);
            Assert.AreNotEqual(expected, result);
        }


        [TestCase(5, 0, "/", 0)]
        [Test]
        public void Operation_divisionZero_ReturnErrorZero(long digit1, long digit2, string operation, long expected)
        {
            var result = Service.Operation(digit1, digit2, operation);
            //Assert.Throws<ArgumentException>(() => Service.Operation(digit1, digit2, operation));
            Assert.AreEqual(expected, result);
        }

        [TestCase("-")]
        [Test]
        public void Verify_onlyOperator_ReturnEqualDisable(string operation)
        {
            var result = Service.SendOperatorOnly(operation);
            Assert.IsTrue(result);
        }

        [TestCase(5, 7, 4, "+",  "+")]
        [Test]
        public void Verify_secuentialOperations_ReturnEqualDisable(long digit1, long digit2, long digit3, string operation1, string operation2)
        {
            var result = Service.SendSecuentialOperation(digit1, digit2, digit3, operation1, operation2);
            Assert.IsTrue(result);
        }

    }
}