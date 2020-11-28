using App;
using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    public class ExtensionsTests
    {
        [TestCase("", new char[0], ExpectedResult = new string[0])]
        [TestCase("", new[] { ' ' }, ExpectedResult = new string[0])]
        [TestCase("abc", new char[0], ExpectedResult = new[] { "abc" })]
        [TestCase("abc", new[] { ' ' }, ExpectedResult = new[] { "abc" })]
        [TestCase("abc def", new[] { ' ' }, ExpectedResult = new[] { "abc", " ", "def" })]
        [TestCase("abc ", new[] { ' ' }, ExpectedResult = new[] { "abc", " " })]
        [TestCase(" abc", new[] { ' ' }, ExpectedResult = new[] { " ", "abc" })]
        [TestCase(" ", new[] { ' ' } , ExpectedResult = new[] { " " })]
        [TestCase("  ", new[] { ' ' }, ExpectedResult = new[] { " ", " " })]
        [TestCase("abc def ghi", new[] { ' ' }, ExpectedResult = new[] { "abc", " ", "def", " ", "ghi" })]
        [TestCase(" abc def ghi ", new[] { ' ' }, ExpectedResult = new[] { " ", "abc", " ", "def", " ", "ghi", " " })]
        [TestCase("-abc-def-ghi-", new[] { '-' }, ExpectedResult = new[] { "-", "abc", "-", "def", "-", "ghi", "-" })]
        [TestCase(" abc-def ghi-", new[] { ' ', '-' }, ExpectedResult = new[] { " ", "abc", "-", "def", " ", "ghi", "-" })]
        [TestCase("-abc def-ghi ", new[] { ' ', '-' }, ExpectedResult = new[] { "-", "abc", " ", "def", "-", "ghi", " " })]
        public string[] SplitWithSeparators_Succeeds(string str, char[] separators) =>
            str.SplitWithSeparators(separators);


        [TestCase("", null, typeof(ArgumentNullException))]
        [TestCase(null, new char[0], typeof(ArgumentNullException))]
        public void SplitWithSeparators_Fails(string str, char[] separators, Type exceptionType) =>
            Assert.Throws(exceptionType, () => str.SplitWithSeparators(separators));
    }
}
