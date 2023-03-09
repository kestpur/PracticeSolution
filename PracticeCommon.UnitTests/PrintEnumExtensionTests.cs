using Microsoft.VisualStudio.TestTools.UnitTesting;

using PracticeCommon.Enums;
using PracticeCommon.Extensions;

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
