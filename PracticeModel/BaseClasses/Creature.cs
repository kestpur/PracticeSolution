using Practice.Common.Classes;
using Practice.Common.Enums;
using Practice.Common.Helpers;
using Practice.Common.Interfaces;

using Prism.Mvvm;

using System;
using System.Runtime.Serialization;

namespace Practice.Common.BaseClasses
{
    /// <summary>
    /// this is the base class for all creatures
    /// </summary>
    /// <remarks>
    /// Inherits from BindableBase
    /// </remarks>
    [Serializable]
    public abstract class Creature : BindableBase, IPrintable, ICreature, IModel
    {
        #region notes

        // creatures don't have race
        // monsters have monsterType and characters have characterRace
        // all creatures have a class
        // all creatures have stats
        // all creatures have description
        // all creatures can print themselves - for saving
        // all creatures are serializable - for loading

        #endregion notes

        #region Properties

        private string name;

        [DataMember]
        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        private bool isPlayer = false;

        [DataMember]
        public bool IsPlayer
        {
            get => isPlayer;
            set => isPlayer = value;
        }

        public bool IsNotPlayer => !IsPlayer;

        [DataMember]
        private bool readyToLevel;

        public bool ReadyToLevel
        {
            get => readyToLevel;
            private set => SetProperty(ref readyToLevel, value);
        }

        private CharacterClass characterClass = CharacterClass.Fighter;

        [DataMember]
        public CharacterClass CharacterClass
        {
            get => characterClass;
            set => SetProperty(ref characterClass, value);
        }

        private StatClass statClass;

        [DataMember]
        public StatClass StatClass
        {
            get => statClass;
            set => SetProperty(ref statClass, value);
        }

        private SaveClass saveClass;

        [DataMember]
        public SaveClass SaveClass
        {
            get => saveClass;
            set => SetProperty(ref saveClass, value);
        }

        private string description;

        [DataMember]
        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        private int xp;
        [DataMember]
        public int XP
        {
            get => xp;
            private set => SetProperty(ref xp, value);
        }
        private int level;
        [DataMember]
        public int Level
        {
            get => level;
            private set => SetProperty(ref level, value);
        }
        #endregion Properties

        public void Init(int numDice = 3, bool discardLow = true)
        {
            var stats = new StatClass();
            stats.Init(numDice, discardLow);

            StatClass = stats;
        }

        //TODO: need to handle the picture
        public abstract string CreatureType();

        /// <summary>
        /// Adds XP to the character
        /// </summary>
        /// <param name="xp">xp to add</param>h
        public void AddXP(int xp)
        {
            XP = XP + xp;
            if (!ReadyToLevel)
                ReadyToLevel = CharacterClassHelper.ReadyToLevel(XP, Level);
        }
        /// <summary>
        /// This will level up the character
        /// </summary>
        public void LevelUp()
        {
            ReadyToLevel = false;
            Level = CharacterClassHelper.SetLevel(XP, Level);

            // TODO: this still needs to allow the user to set the additional level ups
        }
        public void Print()
        {
            throw new NotImplementedException();
        }
    }
}