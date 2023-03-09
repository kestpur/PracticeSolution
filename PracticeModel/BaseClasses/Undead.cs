using PracticeCommon.Enums;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeCommon.BaseClasses
{
    public class Undead : Monster
    {
        public override MonsterType MonsterType => MonsterType.Undead;
        public virtual string Monster => "Undead";
    }
}
