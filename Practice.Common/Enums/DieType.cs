using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Common.Enums
{
    public enum DieType
    {
        [Description("d4")]
        FOUR,
        [Description("d6")]
        SIX,
        [Description("d8")]
        EIGHT,
        [Description("d10")]
        TEN,
        [Description("d12")]
        TWELVE,
        [Description("d20")]
        TWENTY
    }
}
