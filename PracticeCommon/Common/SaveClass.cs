using Prism.Mvvm;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeCommon.Common
{
    public class SaveClass : BindableBase
    {
        #region Constructors
        public SaveClass() { }
        #endregion
        #region Properties
        private int fortitude;
        public int Fortitude
        {
            get => fortitude;
            set => SetProperty(ref fortitude, value);
        }
        private int reflex;
        public int Reflex
        {
            get => reflex;
            set => SetProperty(ref reflex, value);
        }
        private int will;
        public int Will
        {
            get => will;
            set => SetProperty(ref will, value);
        }
        #endregion
    }
}
