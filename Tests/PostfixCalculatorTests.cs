using App;
using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    public class PostfixCalculatorTests
    {
        [TestCase("", ExpectedResult = "0")]
        public string T01_CanCalculateEmpty(string postfixExpression)
            => PostfixCalculator.Calculate(postfixExpression);


        [TestCase("3", ExpectedResult = "3")]
        [TestCase("0", ExpectedResult = "0")]
        [TestCase("-2", ExpectedResult = "-2")]
        public string T02_CanCalculateOperand(string postfixExpression)
            => PostfixCalculator.Calculate(postfixExpression);


        [TestCase(null, typeof(FormatException))]
        public void T03_CanNotCalculateNull(string postfixExpression, Type exceptionType) =>
            Assert.Throws(exceptionType, () => PostfixCalculator.Calculate(postfixExpression));


        [TestCase("x", typeof(FormatException))]
        public void T04_CanNotCalculateBadOperand(string postfixExpression, Type exceptionType) =>
            Assert.Throws(exceptionType, () => PostfixCalculator.Calculate(postfixExpression));


        [TestCase("3 2 +", ExpectedResult = "5")]
        [TestCase("33 22 +", ExpectedResult = "55")]
        [TestCase("3 -2 +", ExpectedResult = "1")]
        public string T05_CanCalculateSinglePlusOperation(string postfixExpression)
            => PostfixCalculator.Calculate(postfixExpression);


        [TestCase("3 2 *", ExpectedResult = "6")]
        [TestCase("3 2 -", ExpectedResult = "1")]
        [TestCase("3 5 -", ExpectedResult = "-2")]
        public string T06_CanCalculateSingleOtherOperation(string postfixExpression)
            => PostfixCalculator.Calculate(postfixExpression);


        [TestCase("3 2", typeof(FormatException))]
        [TestCase("3 2 #", typeof(FormatException))]
        public void T07_CanNotCalculateBadOperation(string postfixExpression, Type exceptionType) =>
            Assert.Throws(exceptionType, () => PostfixCalculator.Calculate(postfixExpression));


        [TestCase("3 2 + 7 +", ExpectedResult = "12")]
        public string T08_CanCalculateSamePlusOperation(string postfixExpression)
            => PostfixCalculator.Calculate(postfixExpression);


        [TestCase("3 2 - 7 -", ExpectedResult = "-6")]
        [TestCase("3 5 - 7 -", ExpectedResult = "-9")]
        [TestCase("3 2 * 7 *", ExpectedResult = "42")]
        public string T09_CanCalculateSameOtherOperation(string postfixExpression)
            => PostfixCalculator.Calculate(postfixExpression);


        [TestCase("3 2 + 5 7 + +", ExpectedResult = "17")]
        [TestCase("17 20 - 5 +", ExpectedResult = "2")]
        public string T10_CanCalculateSeveralOperations(string postfixExpression)
            => PostfixCalculator.Calculate(postfixExpression);


        [TestCase("3 2 + 7", typeof(FormatException))]
        [TestCase("3 2 + 5 7 +", typeof(FormatException))]
        public void T11_CanNotCalculateBadSeveralOperations(string postfixExpression, Type exceptionType) =>
            Assert.Throws(exceptionType, () => PostfixCalculator.Calculate(postfixExpression));


        [TestCase("+", typeof(FormatException))]
        [TestCase("2 -", typeof(FormatException))]
        [TestCase("3 + 2 +", typeof(FormatException))]
        public void T12_CanNotCalculateBadBuild(string postfixExpression, Type exceptionType) =>
            Assert.Throws(exceptionType, () => PostfixCalculator.Calculate(postfixExpression));


        [TestCase("i", ExpectedResult = "i")]
        [TestCase("4i", ExpectedResult = "4i")]
        [TestCase("-4i", ExpectedResult = "-4i")]

        [TestCase("3 4i +", ExpectedResult = "3+4i")]
        [TestCase("4i 3 +", ExpectedResult = "3+4i")]
        [TestCase("3 4i -", ExpectedResult = "3-4i")]
        [TestCase("4i 3 -", ExpectedResult = "-3+4i")]
        [TestCase("3i 4i +", ExpectedResult = "7i")]
        [TestCase("3i 4i -", ExpectedResult = "-i")]
        [TestCase("3i 5i -", ExpectedResult = "-2i")]
        [TestCase("2 3i *", ExpectedResult = "6i")]
        [TestCase("2i 3 *", ExpectedResult = "6i")]
        [TestCase("2i 3i *", ExpectedResult = "-6")]

        [TestCase("3 7i + 5 4i + +", ExpectedResult = "8+11i")]
        [TestCase("3 7i + 5 4i + *", ExpectedResult = "-13+47i")]
        [TestCase("7i 3 + 4i 5 + *", ExpectedResult = "-13+47i")]
        public string T13_CanCalculateComplexNumbers(string postfixExpression)
            => PostfixCalculator.Calculate(postfixExpression);
    }
}
