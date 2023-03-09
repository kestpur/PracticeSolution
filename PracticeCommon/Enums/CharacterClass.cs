using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeCommon.Enums
{
    public enum CharacterClass
    {
        [Description("Cleric")]
        Cleric,
        [Description("Wizard")]
        Wizard,
        [Description("Fighter")]
        Fighter,
        [Description("Rogue")]
        Rogue
    }
}
