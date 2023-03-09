using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeCommon.Comparers
{
    internal class CharComparer : IComparer<char>
    {
        public int Compare(char x, char y)
        {
            if (x < y) return -1;
            if (x > y) return 1;
            return 0;
        }
    }
}
