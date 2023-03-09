using PracticeCommon.Enums;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeCommon.Extensions
{
    public static class PrintEnumExtension
    {
        public static string Print(this CharacterRace characterRace)
        {
            switch (characterRace)
            {
                case CharacterRace.Dwarf:
                    return "Dwarf";
                case CharacterRace.Elf:
                    return "Elf";
                case CharacterRace.Human:
                    return "Human";
                case CharacterRace.Half_Orc:
                    return "Half Orc";
                case CharacterRace.Half_Elf:
                    return "Half Elf";
                default:
                    throw new ArgumentOutOfRangeException("characterRace", "Unknown Type");
            }
        }

        public static string Print(this CharacterClass characterClass)
        {
            switch (characterClass)
            {
                case CharacterClass.Cleric:
                    return "Cleric";
                case CharacterClass.Wizard:
                    return "Wizard";
                case CharacterClass.Fighter:
                    return "Figher";
                case CharacterClass.Rogue:
                    return "Rogue";
                default:
                    throw new ArgumentOutOfRangeException("characterClass", "Unknown Class Type");
            }
        }
    }
}
