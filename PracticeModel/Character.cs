using PracticeCommon.BaseClasses;
using PracticeCommon.Enums;
using PracticeCommon.Helpers;

namespace PracticeCommon
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
                var statClass = StatClass;

                var raceMod = CharacterRaceHelper.RaceStat(characterRace);
                var stat = statClass - raceMod;
                raceMod = CharacterRaceHelper.RaceStat(value);
                stat = stat + raceMod;
                StatClass = stat;

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
    }
}