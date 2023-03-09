using PracticeCommon.BaseClasses;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeCommon.Monsters
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
