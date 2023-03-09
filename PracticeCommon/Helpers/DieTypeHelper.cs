using PracticeCommon.Enums;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeCommon.Helpers
{
    public static class DieTypeHelper
    {
        public static int NumSides(DieType type)
        {
            switch (type)
            {
                case DieType.FOUR: return 4;
                case DieType.SIX: return 6;
                case DieType.EIGHT: return 8;
                case DieType.TEN: return 10;
                case DieType.TWELVE: return 12;
                case DieType.TWENTY: return 20;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public static int RollDie(Random rand, DieType type)
        {
            const int min = 1;
            int max = NumSides(type) + 1;

            int die = rand.Next(min, max);
            return die;
        }
    }
}