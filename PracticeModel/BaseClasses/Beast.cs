using PracticeCommon.Enums;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeCommon.BaseClasses
{
    public class Beast : Monster
    {
        public override MonsterType MonsterType => MonsterType.Beast;
        public virtual string Monster => "Beast";
    }
}
