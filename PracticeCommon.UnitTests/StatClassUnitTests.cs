using Microsoft.VisualStudio.TestTools.UnitTesting;

using PracticeCommon.Common;

using System;

namespace PracticeCommon.UnitTests
{
    [TestClass]
    public class StatClassUnitTests
    {
        [TestMethod]
        public void StatClassConstructor()
        {
            var stat = new StatClass();

            // stats should all be zero
            Assert.AreEqual(0, stat.Strength);
        }

        [TestMethod]
        public void StatClassInit()
        {
            var stat = new StatClass();
            stat.Init(4, true);

            Console.WriteLine(string.Format("The strength value is {0}.",
                         stat.Strength));

            Assert.AreNotEqual(0, stat.Strength);
            Assert.IsTrue(stat.Strength >= 3);
            Assert.IsTrue(stat.Strength <= 18);
        }

        [TestMethod]
        public void StatClassOperatorAdd()
        {
            var lhs = new StatClass();
            lhs.Init(2, false);

            var rhs = new StatClass();
            rhs.Init(1, false);

            int expected = lhs.Strength + rhs.Strength;

            var total = lhs + rhs;
            Assert.AreEqual(expected, total.Strength);
        }
        public void StatClassModifier()
        {
            var stat = new StatClass();
            stat.Charisma = 2;
            stat.Strength = 19;

            var mod = StatClass.Modifier(stat.Charisma);
            Assert.AreEqual(-4, mod);

            mod = StatClass.Modifier(stat.Strength);
            Assert.AreEqual(4, mod);
        }
    }
}
