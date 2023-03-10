using Prism.Mvvm;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PracticeCommon.Common
{
    /// <summary>
    /// These are the saves for the character
    /// </summary>
    [Serializable]
    public class SaveClass : BindableBase
    {
        #region Constructors
        public SaveClass() { }
        public SaveClass(StatClass stats)
        {
            Fortitude = StatClass.Modifier(stats.Constitution);
            Reflex = StatClass.Modifier(stats.Dexterity);
            Will = StatClass.Modifier(stats.Wisdom);
        }
        #endregion
        #region Properties
        private int fortitude;
        [DataMember]
        public int Fortitude
        {
            get => fortitude;
            set => SetProperty(ref fortitude, value);
        }
        private int reflex;
        [DataMember]
        public int Reflex
        {
            get => reflex;
            set => SetProperty(ref reflex, value);
        }
        private int will;
        [DataMember]
        public int Will
        {
            get => will;
            set => SetProperty(ref will, value);
        }
        private Dictionary<string,string> customSaves = new Dictionary<string, string>();
        [DataMember]
        public Dictionary<string, string> CustomSaves => customSaves;
        #endregion
    }
}
