using App;
using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    public class PostfixBuilderTests
    {
        [TestCase("", ExpectedResult = "")]
        public string T01_CanBuildEmpty(string infixExpression) =>
            PostfixBuilder.BuildPostfixExpression(infixExpression);


        //[TestCase("3", ExpectedResult = "3")]
        //[TestCase("0", ExpectedResult = "0")]
        //public string T02_CanBuildOperand(string infixExpression) =>
        //    PostfixBuilder.BuildPostfixExpression(infixExpression);


        //[TestCase(null, typeof(FormatException))]
        //public void T03_CanNotBuildNull(string infixExpression, Type exceptionType) =>
        //    Assert.Throws(exceptionType, () => PostfixBuilder.BuildPostfixExpression(infixExpression));


        //[TestCase("3+2", ExpectedResult = "3 2 +")]
        //[TestCase("33+22", ExpectedResult = "33 22 +")]
        //public string T04_CanBuildSinglePlusOperation(string infixExpression) =>
        //    PostfixBuilder.BuildPostfixExpression(infixExpression);


        //[TestCase("3*2", ExpectedResult = "3 2 *")]
        //[TestCase("3-2", ExpectedResult = "3 2 -")]
        //public string T05_CanBuildSingleDifferentOperation(string infixExpression) =>
        //    PostfixBuilder.BuildPostfixExpression(infixExpression);


        //[TestCase("3+2+7", ExpectedResult = "3 2 + 7 +")]
        //public string T06_CanBuildSamePlusOperation(string infixExpression) =>
        //    PostfixBuilder.BuildPostfixExpression(infixExpression);


        //[TestCase("3-2-7", ExpectedResult = "3 2 - 7 -")]
        //[TestCase("3*2*7", ExpectedResult = "3 2 * 7 *")]
        //public string T07_CanBuildSameDifferentOperation(string infixExpression) =>
        //    PostfixBuilder.BuildPostfixExpression(infixExpression);


        //[TestCase("3+2-7", ExpectedResult = "3 2 + 7 -")]
        //[TestCase("3-2+7", ExpectedResult = "3 2 - 7 +")]
        //public string T08_CanBuildSinglePriority(string infixExpression) =>
        //    PostfixBuilder.BuildPostfixExpression(infixExpression);


        //[TestCase("3+2*7", ExpectedResult = "3 2 7 * +")]
        //[TestCase("3*2+7", ExpectedResult = "3 2 * 7 +")]
        //[TestCase("57+21*35+44", ExpectedResult = "57 21 35 * + 44 +")]
        //[TestCase("57*21+35*44", ExpectedResult = "57 21 * 35 44 * +")]
        //public string T09_CanBuildSeveralPriorities(string infixExpression) =>
        //    PostfixBuilder.BuildPostfixExpression(infixExpression);


        //[TestCase("(5+4)", ExpectedResult = "5 4 +")]
        //[TestCase("3*(5+4)", ExpectedResult = "3 5 4 + *")]
        //[TestCase("(5+4)*3", ExpectedResult = "5 4 + 3 *")]
        //[TestCase("(7+2)*(3+5)", ExpectedResult = "7 2 + 3 5 + *")]
        //[TestCase("1+(7*(2+3*5+9))-2", ExpectedResult = "1 7 2 3 5 * + 9 + * + 2 -")]
        //[TestCase("(5)", ExpectedResult = "5")]
        //public string T10_CanBuildBrackets(string infixExpression) =>
        //    PostfixBuilder.BuildPostfixExpression(infixExpression);


        //[TestCase("(", typeof(FormatException))]
        //[TestCase(")", typeof(FormatException))]
        //[TestCase(")(", typeof(FormatException))]
        //[TestCase("()", typeof(FormatException))]
        //[TestCase("1+2)", typeof(FormatException))]
        //[TestCase("(1+2", typeof(FormatException))]
        //[TestCase("(5))", typeof(FormatException))]
        //[TestCase("((5)", typeof(FormatException))]
        //public void T11_CanNotBuildBadBrackets(string infixExpression, Type exceptionType) =>
        //    Assert.Throws(exceptionType, () => PostfixBuilder.BuildPostfixExpression(infixExpression));


        //[TestCase("-2", ExpectedResult = "0 2 -")]
        //[TestCase("7*(-2+3)", ExpectedResult = "7 0 2 - 3 + *")]
        //public string T12_CanBuildUnaryMinus(string infixExpression) =>
        //    PostfixBuilder.BuildPostfixExpression(infixExpression);
    }
}
