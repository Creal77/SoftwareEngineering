using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp;

namespace UnitTest
{

    [TestClass]
    public class CompterChiffresTest
    {
        void TestValeur(long n, int vrai_resultat)
        {
            Assert.AreEqual(Nombre.CompterChiffres(n), vrai_resultat);
        }
        [TestMethod]
        public void Test0()
        {
            TestValeur(0, 1);
        }
        [TestMethod]
        public void Test9()
        {
            TestValeur(9, 1);
        }
        [TestMethod]
        public void Test10()
        {
            TestValeur(10, 2);
        }
        [TestMethod, Timeout(1000)]
        public void TestEntierMax()
        {
            TestValeur(Int64.MaxValue, 19);
        }
    }
}
