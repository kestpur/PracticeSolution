using Practice.Common.BaseClasses;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Common.Monsters
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
