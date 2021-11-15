using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleCalculator;
using System;

namespace MSTestProject
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void ShouldBeZeroWhenPassingEmptyString()
        {
            int actual = Calculator.Add("1,2,3");
            int expected = 6;
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void ShouldBeOneWithSingleParmeterOfOne()
        {
            int actual = Calculator.Add("1");
            int expected = 1;
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void ShouldBeThreeWithTwoParamtersAndCommaSeparated()
        {
            int actual = Calculator.Add("1,2");
            int expected = 3;
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void ShouldBeSixWithThreeParametersAndNewLines()
        {
            int actual = Calculator.Add("1\n2,3");
            int expected = 6;
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void ShouldParseDelimterStringSemicolon()
        {
            int actual = Calculator.Add("//;\n1;2");
            int expected = 3;
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void ShouldThrowExceptionNegativesNotAllowed()
        {
            try
            {
                int actual = Calculator.Add("-1,1,-3");
                Assert.Fail("No Excepion Thrown");
            }
            catch (Exception ex)
            {
                string expected = "Negatives not allowed: -1 -3";
                string actual = ex.Message;
                Assert.AreEqual(expected, actual);
            }

        }
    }
}
