// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using System;
using Connect4;

namespace Connect4UnitTests
{
    [TestFixture]
    public class TestClass
    {
        [Test]
        public void TestMethod()
        {
            // TODO: Add your test code here
            Func<int, int> increment = val => val + 1;
            Func<int, int> decrement = val => val - 1;
            Func<int, int> same = val => val;

            Assert.That(2 == increment(1));

            Assert.That(ReferenceTest(increment, 3) == 4);
        }

        private int ReferenceTest(Func<int, int> method, int input)
        {
            int x = Utillity.Clamp(method(input), 0, 7);
            return x;
        }
    }
}
