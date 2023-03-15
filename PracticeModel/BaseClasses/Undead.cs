using Practice.Common.Enums;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Common.BaseClasses
{
    /// <summary>
    /// This is the definition of an Undead monster
    /// </summary>
    public class Undead : Monster
    {
        public override MonsterType MonsterType => MonsterType.Undead;
        public virtual string Monster => "Undead";
    }
}
