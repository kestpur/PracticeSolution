using Practice.Common.BaseClasses;
using Practice.Common.Enums;
using Practice.Common.Helpers;
using Practice.Common.Classes;

using System;

namespace Practice.Model
{
    public class Character : Creature
    {
        #region Properties

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
                UpdateStatClass(characterRace, value);
                SetProperty(ref characterRace, value);
            }
        }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public Character()
        {
            CharacterRace = CharacterRace.Human;
            CharacterClass = CharacterClass.Fighter;
            RollStats();
        }

        #endregion Constructors

        /// <summary>
        /// Rolls the stats
        /// </summary>
        public void RollStats()
        {
            Init();

            var raceMod = CharacterRaceHelper.RaceStat(characterRace);
            var stat = StatClass + raceMod;
            StatClass = stat;

            SaveClass = CharacterRaceHelper.RaceSaves(characterRace, StatClass);
        }
        private void UpdateStatClass(CharacterRace oldRace, CharacterRace newRace)
        {
            var statClass = StatClass;

            var raceMod = CharacterRaceHelper.RaceStat(oldRace);
            var stat = statClass - raceMod;
            raceMod = CharacterRaceHelper.RaceStat(newRace);
            stat = stat + raceMod;
            StatClass = stat;

            SaveClass = new SaveClass(StatClass);
        }
    }
}