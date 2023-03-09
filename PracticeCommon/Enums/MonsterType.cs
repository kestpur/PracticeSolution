using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeCommon.Enums
{
    public enum MonsterType
    {
        [Description("Aberration")]
        Aberration,
        [Description("Beast")]
        Beast,
        [Description("Celestial")]
        Celestial,
        [Description("Construct")]
        Construct,
        [Description("Dragon")]
        Dragon,
        [Description("Elemental")]
        Elemental,
        [Description("Fey")]
        Fey,
        [Description("Fiend")]
        Fiend,
        [Description("Giant")]
        Giant,
        [Description("Humanoid")]
        Humanoid,
        [Description("Monstrosity")]
        Monstrosity,
        [Description("Ooze")]
        Ooze,
        [Description("Plant")]
        Plant,
        [Description("Undead")]
        Undead
    }
}
