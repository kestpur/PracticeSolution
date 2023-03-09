using PracticeCommon.Common;
using PracticeCommon.Enums;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeCommon.Helpers
{
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
    }
}
