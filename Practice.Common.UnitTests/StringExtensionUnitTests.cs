using Microsoft.VisualStudio.TestTools.UnitTesting;

using Practice.Common.Extensions;

using System;


namespace PracticeCommon.UnitTests
{
    [TestClass]
    public class StringExtensionUnitTests
    {
        [TestMethod]
        public void SortEmptyStringTest()
        {
            string str = "";
            string temp = "empty";
            Assert.AreEqual("empty", temp);

            temp = str.Sort();

            Assert.AreEqual("", temp);
        }

        [TestMethod]
        public void SortSingleCharStringTest()
        {
            string str = "a";
            string temp = "empty";
            Assert.AreEqual("empty", temp);

            temp = str.Sort();

            Assert.AreEqual("a", temp);
        }

        [TestMethod]
        public void SortStringWithNumbersTest()
        {
            string str = "a192";
            string temp = str.Sort();

            Assert.AreEqual("129a", temp);
        }
    }
}
