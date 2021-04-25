using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CryptoFormula.Tests
{
    [TestClass()]
    public class CryptoFormulaTests
    {
        Dictionary<(int Num1, int Num2), int> _testValues = new Dictionary<(int, int), int>()
        {
            { (17, 4), 13 },
            { (47, 22), 15 },
            { (43, 12), 18 },
            { (23, 2), 12 },
            { (13, 43), 10 },
        };

        [TestMethod]
        public void АлгоритмЕвклидаTests()
        {
            var алгоритмЕвклидаTest = new Func<int, int, int, bool>(
                (p, x, expected) =>
                    CryptoFormulaLibrary.CryptoFormula.АлгоритмЕвклида(p, x, out var exc) == expected 
                    && exc == null
            );

            foreach (var value in _testValues)
                Assert.IsTrue(алгоритмЕвклидаTest(value.Key.Num1, value.Key.Num2, value.Value));

            Assert.IsNull(CryptoFormulaLibrary.CryptoFormula.АлгоритмЕвклида(126, 1232, out var exc));
            Assert.IsNotNull(exc);
        }

        [TestMethod]
        public void ФормулаЭйлераTests()
        {
            var формулаЭйлераTest = new Func<int, int, int, bool>(
                (p, x, expected) =>
                    CryptoFormulaLibrary.CryptoFormula.ФормулаЭйлера(p, x, out var divisors, out var exc) == expected 
                    && exc == null 
                    && divisors != null
            );

            foreach (var value in _testValues)
                Assert.IsTrue(формулаЭйлераTest(value.Key.Num1, value.Key.Num2, value.Value));

            Assert.IsNull(CryptoFormulaLibrary.CryptoFormula.ФормулаЭйлера(126, 1232, out var divisors, out var exc));
            Assert.IsNotNull(exc);
        }
    }
}
