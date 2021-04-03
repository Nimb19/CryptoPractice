using System;
using HelpfulLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CryptoFormula.Tests
{
    [TestClass()]
    public class CryptoFormulaTests
    {
        [TestMethod]
        public void АлгоритмЕвклидаTests()
        {
            var алгоритмЕвклидаTest = new Func<int, int, int, bool>(
                (p, x, expected) =>
                    expected == CryptoFormula.АлгоритмЕвклида(p, x, out var exc) && exc == null
            );

            Assert.IsTrue(алгоритмЕвклидаTest(17, 4, 13));
            Assert.IsTrue(алгоритмЕвклидаTest(47, 22, 15));
            Assert.IsTrue(алгоритмЕвклидаTest(43, 12, 18));
            Assert.IsTrue(алгоритмЕвклидаTest(23, 2, 12));

            CryptoFormula.АлгоритмЕвклида(126, 1232, out var exc);
            Assert.IsNotNull(exc);
        }
    }
}