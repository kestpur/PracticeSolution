using PracticeCommon.BaseClasses;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeCommon.Monsters
{
    public class Wolf : Beast
    {
        public override string Monster => "Wolf";
        public Wolf()
        {
            Description = "Large Gray Wolf";
        }
    }
}
