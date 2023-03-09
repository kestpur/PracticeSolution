using PracticeCommon.BaseClasses;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeCommon.Monsters
{
    public class Wraith : Undead
    {
        public override string Monster => "Wraith";
        public Wraith()
        {
            Description = "skeletal figure draped in tattered rags";
            Init();
        }
    }
}
