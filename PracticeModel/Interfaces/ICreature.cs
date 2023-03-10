using PracticeCommon.Enums;

using PracticeCommon.Common;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeCommon.Interfaces
{
    public interface ICreature
    {
        // all creatures have a class
        // all creatures have a race
        // all creatures have stats
        // all creatures have description

        CharacterClass CharacterClass { get; set; }
        StatClass StatClass { get; set; }
        SaveClass SaveClass { get; set; }
        string Description { get; set; }
    }
}
