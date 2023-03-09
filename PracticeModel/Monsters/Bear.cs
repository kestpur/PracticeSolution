using PracticeCommon.BaseClasses;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeCommon.Monsters
{
    public class Bear : Beast
    {
        public override string Monster => "Bear";
        public Bear()
        {
            Description = "Big Brown Bear";
        }
    }
}
