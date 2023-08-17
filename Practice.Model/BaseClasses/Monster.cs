using Practice.Common.Enums;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Common.BaseClasses
{
    /// <summary>
    /// This is the definition of a monster
    /// </summary>
    public abstract class Monster : Creature
    {
        public override string CreatureType()
        {
            return "Monster";
        }

        public abstract MonsterType MonsterType { get; }
    }
}
