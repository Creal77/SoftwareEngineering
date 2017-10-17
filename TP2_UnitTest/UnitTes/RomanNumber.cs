using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp;

namespace UnitTest
{

    [TestClass]
    public class RomanNumber
    {
        void TestValue(int n, string r)
        {
            Assert.AreEqual(Nombre.ToRoman(n), r);
        }
        [TestMethod]
        public void Test1()
        {
            TestValue(1, "I");
        }
        [TestMethod]
        public void Test6()
        {
            TestValue(6, "VI");
        }
        [TestMethod]

        public void Test15()
        {
            TestValue(15, "XV");
        }
        [TestMethod]
        public void Test26()
        {
            TestValue(26, "XXVI");
        }
        [TestMethod]
        public void Test85()
        {
            TestValue(85, "LXXXV");
        }
        [TestMethod]
        public void Test2158()
        {
            TestValue(2158, "MMCLVIII");
        }
        [TestMethod]
        public void Test9()
        {
            TestValue(9, "IX");
        }
        [TestMethod]
        public void Test369()
        {
            TestValue(369, "CCCLXIX");
        }
        [TestMethod]
        public void Test2751()
        {
            TestValue(2751, "MMDCCLI");
        }
    }
}
