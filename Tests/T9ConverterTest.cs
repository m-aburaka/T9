using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using T9;

namespace T9ConverterTest
{
    [TestClass]
    public class T9ConverterTest
    {
        [TestMethod]
        public void ShouldThrowIfCharaterNotAllowed()
        {
            Assert.ThrowsException<ArgumentException>(() => T9Converter.ToKeys("русский"));
            Assert.ThrowsException<ArgumentException>(() => T9Converter.ToKeys("$%@#$"));
            Assert.ThrowsException<ArgumentException>(() => T9Converter.ToKeys("123"));
        }

        [TestMethod]
        public void ShouldThrowIfOutOfLimit()
        {
            Assert.ThrowsException<ArgumentException>(() => T9Converter.ToKeys(""));

            var input = string.Empty;
            while (input.Length < 1001)
                input += " ";
            Assert.ThrowsException<ArgumentException>(() => T9Converter.ToKeys(input));
        }

        [TestMethod]
        public void ShouldConvert()
        {
            Assert.AreEqual("44 444", T9Converter.ToKeys("hi"));

            Assert.AreEqual("999 33 7777", T9Converter.ToKeys("yes"));

            Assert.AreEqual("333 666 666 0 0 22 2 777", T9Converter.ToKeys("foo  bar"));

            Assert.AreEqual("44 33 555 555 666 0 9 666 777 555 3", T9Converter.ToKeys("hello world"));
        }
    }
}
