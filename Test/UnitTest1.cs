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
            var util = new NumberToWordUtil();
            var result = util.NumberToWord("1.241");
            Assert.AreEqual("One And Two Hundred Forty One", result);

            result = util.NumberToWord("10.7");
            Assert.AreEqual("Ten And Seven Hundred", result);

            result = util.NumberToWord("0.000");
            Assert.AreEqual("", result);

            result = util.NumberToWord("15.001");
            Assert.AreEqual("Fifteen And One", result);

            result = util.NumberToWord("31.01");
            Assert.AreEqual("Thirty One And Ten", result);

            result = util.NumberToWord("78.012");
            Assert.AreEqual("Seventy Eight And Twelve", result);

            result = util.NumberToWord("489.016");
            Assert.AreEqual("Four Hundred Eighty Nine And Sixteen", result);

            result = util.NumberToWord("1361.02");
            Assert.AreEqual("One Thousand Three Hundred Sixty One And Twenty", result);

            result = util.NumberToWord("15415.020");
            Assert.AreEqual("Fifteen Thousand Four Hundred Fifteen And Twenty", result);

            result = util.NumberToWord("21007.057");
            Assert.AreEqual("Twenty One Thousand Seven And Fifty Seven", result);

            result = util.NumberToWord("362789.157");
            Assert.AreEqual("Three Hundred Sixty Two Thousand Seven Hundred Eighty Nine And One Hundred Fifty Seven", result);

            result = util.NumberToWord("1452710.907");
            Assert.AreEqual("One Million Four Hundred Fifty Two Thousand Seven Hundred Ten And Nine Hundred Seven", result);
        }

        [TestMethod]
        public void TestDecimals()
        {
            var util = new NumberToWordUtil();
            var result = util.NumberToWord("0.241");
            Assert.AreEqual("Two Hundred Forty One", result);

            result = util.NumberToWord("0.7");
            Assert.AreEqual("Seven Hundred", result);

            result = util.NumberToWord("0.000");
            Assert.AreEqual("", result);

            result = util.NumberToWord("0.001");
            Assert.AreEqual("One", result);

            result = util.NumberToWord("0.01");
            Assert.AreEqual("Ten", result);

            result = util.NumberToWord("0.012");
            Assert.AreEqual("Twelve", result);

            result = util.NumberToWord("0.016");
            Assert.AreEqual("Sixteen", result);

            result = util.NumberToWord("0.02");
            Assert.AreEqual("Twenty", result);

            result = util.NumberToWord("0.020");
            Assert.AreEqual("Twenty", result);

            result = util.NumberToWord("0.057");
            Assert.AreEqual("Fifty Seven", result);

            result = util.NumberToWord("0.157");
            Assert.AreEqual("One Hundred Fifty Seven", result);

            result = util.NumberToWord("0.907");
            Assert.AreEqual("Nine Hundred Seven", result);

            result = util.NumberToWord("0.400");
            Assert.AreEqual("Four Hundred", result);

            result = util.NumberToWord("0.40");
            Assert.AreEqual("Four Hundred", result);

            result = util.NumberToWord("0.4");
            Assert.AreEqual("Four Hundred", result);
        }

        [TestMethod]
        public void TestDigits()
        {
            var util = new NumberToWordUtil();
            var result = util.NumberToWord("9");
            Assert.AreEqual("Nine", result);

            result = util.NumberToWord("2");
            Assert.AreEqual("Two", result);

            result = util.NumberToWord("1.0");
            Assert.AreEqual("One", result);

            result = util.NumberToWord("7.0");
            Assert.AreEqual("Seven", result);

            result = util.NumberToWord("8");
            Assert.AreEqual("Eight", result);

            result = util.NumberToWord("6");
            Assert.AreEqual("Six", result);

            result = util.NumberToWord("3");
            Assert.AreEqual("Three", result);

            result = util.NumberToWord("4");
            Assert.AreEqual("Four", result);

            result = util.NumberToWord("0");
            Assert.AreEqual("", result);
        }

        [TestMethod]
        public void TestTens()
        {
            var util = new NumberToWordUtil();
            var result = util.NumberToWord("10.0");
            Assert.AreEqual("Ten", result);

            result = util.NumberToWord("15");
            Assert.AreEqual("Fifteen", result);

            result = util.NumberToWord("25");
            Assert.AreEqual("Twenty Five", result);

            result = util.NumberToWord("30");
            Assert.AreEqual("Thirty", result);

            result = util.NumberToWord("78");
            Assert.AreEqual("Seventy Eight", result);

            result = util.NumberToWord("41");
            Assert.AreEqual("Forty One", result);

            result = util.NumberToWord("90.0");
            Assert.AreEqual("Ninety", result);

            result = util.NumberToWord("900.0");
            Assert.AreEqual("Nine Hundred", result);

            result = util.NumberToWord("950.0");
            Assert.AreEqual("Nine Hundred Fifty", result);

            result = util.NumberToWord("159.0");
            Assert.AreEqual("One Hundred Fifty Nine", result);
        }

        [TestMethod]
        public void TestHundreds()
        {
            var util = new NumberToWordUtil();
            var result = util.NumberToWord("100.0");
            Assert.AreEqual("One Hundred", result);

            result = util.NumberToWord("200.0");
            Assert.AreEqual("Two Hundred", result);

            result = util.NumberToWord("900.0");
            Assert.AreEqual("Nine Hundred", result);

            result = util.NumberToWord("950.0");
            Assert.AreEqual("Nine Hundred Fifty", result);

            result = util.NumberToWord("159.0");
            Assert.AreEqual("One Hundred Fifty Nine", result);
        }

        [TestMethod]
        public void TestThousands()
        {
            var util = new NumberToWordUtil();
            var result = util.NumberToWord("1000.0");
            Assert.AreEqual("One Thousand", result);

            result = util.NumberToWord("2000.0");
            Assert.AreEqual("Two Thousand", result);

            result = util.NumberToWord("9000.0");
            Assert.AreEqual("Nine Thousand", result);

            result = util.NumberToWord("9675.0");
            Assert.AreEqual("Nine Thousand Six Hundred Seventy Five", result);

            result = util.NumberToWord("9075.0");
            Assert.AreEqual("Nine Thousand Seventy Five", result);

            result = util.NumberToWord("9005.0");
            Assert.AreEqual("Nine Thousand Five", result);

            result = util.NumberToWord("9011.0");
            Assert.AreEqual("Nine Thousand Eleven", result);
        }
    }
}
