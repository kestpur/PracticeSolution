using PracticeCommon.Enums;
using PracticeCommon.Interfaces;

using PracticeCommon.Common;

using Prism.Mvvm;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PracticeCommon.BaseClasses
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
        #endregion
        #region Properties

        private string name;
        [DataMember]
        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
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
        #endregion

        public void Init(int numDice = 3, bool discardLow = true)
        {
            var stats = new StatClass();
            stats.Init(numDice, discardLow);

            StatClass = stats;
        }

        //TODO: need to handle the picture
        public abstract string CreatureType();
        public void Print()
        {
            throw new NotImplementedException();
        }
    }
}
