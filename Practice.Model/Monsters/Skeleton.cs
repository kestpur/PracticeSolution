using Practice.Common.BaseClasses;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Common.Monsters
{
    public class Skeleton : Undead
    {
        public override string Monster => "Skeleton";
        public Skeleton()
        {
            Description = "Walking Pile of Bones";
        }
    }
}
