using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeCommon.Enums
{
    public enum CharacterRace
    {
        [Description("Dwarf")]
        Dwarf,
        [Description("Elf")]
        Elf,
        [Description("Human")]
        Human,
        [Description("Half-Orc")]
        Half_Orc,
        [Description("Half-Elf")]
        Half_Elf
    }
}
