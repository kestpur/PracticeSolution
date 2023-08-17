using Microsoft.VisualStudio.TestTools.UnitTesting;

using Practice.Common.Enums;
using Practice.Common.Extensions;

using System;

namespace PracticeCommon.UnitTests
{
    [TestClass]
    public class PrintEnumExtensionTests
    {
        [TestMethod]
        public void PrintCharacterClassClericTest()
        {
            CharacterClass characterClass = CharacterClass.Cleric;


            Assert.AreEqual("Cleric", characterClass.Print());
        }

        [TestMethod]
        public void PrintCharacterRaceDwarfTest()
        {
            CharacterRace characterRace = CharacterRace.Dwarf;

            Assert.AreEqual("Dwarf", characterRace.Print());
        }
    }
}
