using PracticeCommon.Common;
using PracticeCommon.Enums;

using System;

namespace PracticeCommon.Helpers
{
    /// <summary>
    /// These helper functions help make character modifications
    /// based on the race of the character
    /// </summary>
    public static class CharacterRaceHelper
    {
        public static StatClass RaceStat(CharacterRace characterRace)
        {
            var stat = new StatClass();

            switch (characterRace)
            {
                case CharacterRace.Dwarf:
                    stat.Constitution = 2;
                    stat.Charisma = -2;
                    break;

                case CharacterRace.Elf:
                    stat.Dexterity = 2;
                    stat.Constitution = -2;
                    break;

                case CharacterRace.Human:
                    break;

                case CharacterRace.Half_Orc:
                    stat.Strength = 2;
                    stat.Intelligence = -2;
                    stat.Charisma = -2;
                    break;

                case CharacterRace.Half_Elf:
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }

            return stat;
        }

        /// <summary>
        /// This will setup the SaveClass based on racial characteristics
        /// </summary>
        /// <param name="characterRace">the race of the character</param>
        /// <param name="stats">the stats to use for creating the saves</param>
        /// <returns></returns>
        public static SaveClass RaceSaves(CharacterRace characterRace, StatClass stats)
        {
            var saves = new SaveClass(stats);

            switch (characterRace)
            {
                case CharacterRace.Dwarf:
                    saves.CustomSaves.Add("poison", "+2 save");
                    saves.CustomSaves.Add("spells", "+2 save");
                    break;

                case CharacterRace.Elf:
                    saves.CustomSaves.Add("sleep", "immunity");
                    saves.CustomSaves.Add("enchantment", "+2 save");
                    break;

                case CharacterRace.Human:
                    break;

                case CharacterRace.Half_Orc:
                    break;

                case CharacterRace.Half_Elf:
                    saves.CustomSaves.Add("sleep", "immunity");
                    saves.CustomSaves.Add("enchantment", "+2 save");
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }

            return saves;
        }
    }
}