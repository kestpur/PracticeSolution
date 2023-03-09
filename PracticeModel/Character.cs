using PracticeCommon.Enums;

using PracticeCommon.BaseClasses;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PracticeCommon.Helpers;

namespace PracticeCommon
{
    public class Character : Creature
    {
        public override string CreatureType()
        {
            return "Character";
        }

        private CharacterRace characterRace;
        public CharacterRace CharacterRace
        {
            get => characterRace;
            set
            {
                var statClass = StatClass;

                var raceMod = CharacterRaceHelper.RaceStat(characterRace);
                var stat = statClass - raceMod;
                raceMod = CharacterRaceHelper.RaceStat(value);
                stat = stat + raceMod;
                StatClass = stat;

                SetProperty(ref characterRace, value);
            }
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public Character()
        {
            CharacterRace = CharacterRace.Human;
            CharacterClass = CharacterClass.Fighter;
            RollStats();
        }

        public void RollStats()
        {
            Init();

            var raceMod = CharacterRaceHelper.RaceStat(characterRace);
            var stat = StatClass + raceMod;
            StatClass = stat;
        }
    }
}
