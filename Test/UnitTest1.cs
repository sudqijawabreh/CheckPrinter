using System;
using checks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestNumbersWithDecimals()
        {
            var result = NumberToWordUtil.NumberToWord("1.241");
            Assert.AreEqual("One And Two Hundred Forty One", result);

            result = NumberToWordUtil.NumberToWord("10.7");
            Assert.AreEqual("Ten And Seven Hundred", result);

            result = NumberToWordUtil.NumberToWord("0.000");
            Assert.AreEqual("", result);

            result = NumberToWordUtil.NumberToWord("15.001");
            Assert.AreEqual("Fifteen And One", result);

            result = NumberToWordUtil.NumberToWord("31.01");
            Assert.AreEqual("Thirty One And Ten", result);

            result = NumberToWordUtil.NumberToWord("78.012");
            Assert.AreEqual("Seventy Eight And Twelve", result);

            result = NumberToWordUtil.NumberToWord("489.016");
            Assert.AreEqual("Four Hundred Eighty Nine And Sixteen", result);

            result = NumberToWordUtil.NumberToWord("1361.02");
            Assert.AreEqual("One Thousand Three Hundred Sixty One And Twenty", result);

            result = NumberToWordUtil.NumberToWord("15415.020");
            Assert.AreEqual("Fifteen Thousand Four Hundred Fifteen And Twenty", result);

            result = NumberToWordUtil.NumberToWord("21007.057");
            Assert.AreEqual("Twenty One Thousand Seven And Fifty Seven", result);

            result = NumberToWordUtil.NumberToWord("362789.157");
            Assert.AreEqual("Three Hundred Sixty Two Thousand Seven Hundred Eighty Nine And One Hundred Fifty Seven", result);

            result = NumberToWordUtil.NumberToWord("1452710.907");
            Assert.AreEqual("One Million Four Hundred Fifty Two Thousand Seven Hundred Ten And Nine Hundred Seven", result);
        }

        [TestMethod]
        public void TestDecimals()
        {
            var result = NumberToWordUtil.NumberToWord("0.241");
            Assert.AreEqual("Two Hundred Forty One", result);

            result = NumberToWordUtil.NumberToWord("0.7");
            Assert.AreEqual("Seven Hundred", result);

            result = NumberToWordUtil.NumberToWord("0.000");
            Assert.AreEqual("", result);

            result = NumberToWordUtil.NumberToWord("0.001");
            Assert.AreEqual("One", result);

            result = NumberToWordUtil.NumberToWord("0.01");
            Assert.AreEqual("Ten", result);

            result = NumberToWordUtil.NumberToWord("0.012");
            Assert.AreEqual("Twelve", result);

            result = NumberToWordUtil.NumberToWord("0.016");
            Assert.AreEqual("Sixteen", result);

            result = NumberToWordUtil.NumberToWord("0.02");
            Assert.AreEqual("Twenty", result);

            result = NumberToWordUtil.NumberToWord("0.020");
            Assert.AreEqual("Twenty", result);

            result = NumberToWordUtil.NumberToWord("0.057");
            Assert.AreEqual("Fifty Seven", result);

            result = NumberToWordUtil.NumberToWord("0.157");
            Assert.AreEqual("One Hundred Fifty Seven", result);

            result = NumberToWordUtil.NumberToWord("0.907");
            Assert.AreEqual("Nine Hundred Seven", result);

            result = NumberToWordUtil.NumberToWord("0.400");
            Assert.AreEqual("Four Hundred", result);

            result = NumberToWordUtil.NumberToWord("0.40");
            Assert.AreEqual("Four Hundred", result);

            result = NumberToWordUtil.NumberToWord("0.4");
            Assert.AreEqual("Four Hundred", result);
        }

        [TestMethod]
        public void TestDigits()
        {
            var result = NumberToWordUtil.NumberToWord("9");
            Assert.AreEqual("Nine", result);

            result = NumberToWordUtil.NumberToWord("2");
            Assert.AreEqual("Two", result);

            result = NumberToWordUtil.NumberToWord("1.0");
            Assert.AreEqual("One", result);

            result = NumberToWordUtil.NumberToWord("7.0");
            Assert.AreEqual("Seven", result);

            result = NumberToWordUtil.NumberToWord("8");
            Assert.AreEqual("Eight", result);

            result = NumberToWordUtil.NumberToWord("6");
            Assert.AreEqual("Six", result);

            result = NumberToWordUtil.NumberToWord("3");
            Assert.AreEqual("Three", result);

            result = NumberToWordUtil.NumberToWord("4");
            Assert.AreEqual("Four", result);

            result = NumberToWordUtil.NumberToWord("0");
            Assert.AreEqual("", result);
        }

        [TestMethod]
        public void TestTens()
        {
            var result = NumberToWordUtil.NumberToWord("10.0");
            Assert.AreEqual("Ten", result);

            result = NumberToWordUtil.NumberToWord("15");
            Assert.AreEqual("Fifteen", result);

            result = NumberToWordUtil.NumberToWord("25");
            Assert.AreEqual("Twenty Five", result);

            result = NumberToWordUtil.NumberToWord("30");
            Assert.AreEqual("Thirty", result);

            result = NumberToWordUtil.NumberToWord("78");
            Assert.AreEqual("Seventy Eight", result);

            result = NumberToWordUtil.NumberToWord("41");
            Assert.AreEqual("Forty One", result);

            result = NumberToWordUtil.NumberToWord("90.0");
            Assert.AreEqual("Ninety", result);

            result = NumberToWordUtil.NumberToWord("900.0");
            Assert.AreEqual("Nine Hundred", result);

            result = NumberToWordUtil.NumberToWord("950.0");
            Assert.AreEqual("Nine Hundred Fifty", result);

            result = NumberToWordUtil.NumberToWord("159.0");
            Assert.AreEqual("One Hundred Fifty Nine", result);
        }

        [TestMethod]
        public void TestHundreds()
        {
            var result = NumberToWordUtil.NumberToWord("100.0");
            Assert.AreEqual("One Hundred", result);

            result = NumberToWordUtil.NumberToWord("200.0");
            Assert.AreEqual("Two Hundred", result);

            result = NumberToWordUtil.NumberToWord("900.0");
            Assert.AreEqual("Nine Hundred", result);

            result = NumberToWordUtil.NumberToWord("950.0");
            Assert.AreEqual("Nine Hundred Fifty", result);

            result = NumberToWordUtil.NumberToWord("159.0");
            Assert.AreEqual("One Hundred Fifty Nine", result);
        }

        [TestMethod]
        public void TestThousands()
        {
            var result = NumberToWordUtil.NumberToWord("1000.0");
            Assert.AreEqual("One Thousand", result);

            result = NumberToWordUtil.NumberToWord("2000.0");
            Assert.AreEqual("Two Thousand", result);

            result = NumberToWordUtil.NumberToWord("9000.0");
            Assert.AreEqual("Nine Thousand", result);

            result = NumberToWordUtil.NumberToWord("9675.0");
            Assert.AreEqual("Nine Thousand Six Hundred Seventy Five", result);

            result = NumberToWordUtil.NumberToWord("9075.0");
            Assert.AreEqual("Nine Thousand Seventy Five", result);

            result = NumberToWordUtil.NumberToWord("9005.0");
            Assert.AreEqual("Nine Thousand Five", result);

            result = NumberToWordUtil.NumberToWord("9011.0");
            Assert.AreEqual("Nine Thousand Eleven", result);
        }
    }
}
