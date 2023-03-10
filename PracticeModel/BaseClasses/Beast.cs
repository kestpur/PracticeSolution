using PracticeCommon.Enums;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeCommon.BaseClasses
{
    /// <summary>
    /// This is the definition of a Beast (Animal)
    /// </summary>
    public class Beast : Monster
    {
        public override MonsterType MonsterType => MonsterType.Beast;
        public virtual string Monster => "Beast";
    }
}
