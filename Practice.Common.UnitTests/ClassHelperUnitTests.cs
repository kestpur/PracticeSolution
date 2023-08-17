using Microsoft.VisualStudio.TestTools.UnitTesting;

using Practice.Common.Helpers;

namespace PracticeCommon.UnitTests
{
    [TestClass]
    public class ClassHelperUnitTests
    {
        [TestMethod]
        public void ClassHelperReadyToLevelFalse()
        {
            int level = 1;
            int xp = 250;

            Assert.IsFalse(CharacterClassHelper.ReadyToLevel(xp, level));
        }
        [TestMethod]
        public void ClassHelperReadyToLevelTrue()
        {
            int level = 14;
            int xp = 105025;

            Assert.IsTrue(CharacterClassHelper.ReadyToLevel(xp, level));
        }


        [TestMethod]
        public void ClassHelperSetLevelSameLevel()
        {
            int level = 1;
            int xp = 250;

            Assert.IsFalse(CharacterClassHelper.ReadyToLevel(xp, level));
            Assert.AreEqual(level, CharacterClassHelper.SetLevel(xp, level));
        }
        [TestMethod]
        public void ClassHelperSetLevelNextLevel()
        {
            int level = 14;
            int xp = 105025;

            Assert.IsTrue(CharacterClassHelper.ReadyToLevel(xp, level));
            Assert.AreEqual(level + 1, CharacterClassHelper.SetLevel(xp, level));
        }
    }
}
