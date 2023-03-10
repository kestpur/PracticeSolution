using PracticeCommon.Common;
using PracticeCommon.Enums;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeCommon.Helpers
{
    public static class CharacterClassHelper
    {
        public static StatClass ClassStat(CharacterClass characterClass)
        {
            var stat = new StatClass();
            return stat;
        }

        /// <summary>
        /// Sets the new level based on the 3.5 ruleset
        /// </summary>
        /// <param name="xP">current XP</param>
        /// <param name="level">Current Level</param>
        /// <returns>The new Level</returns>
        public static int SetLevel(int xP, int level)
        {
            return ReadyToLevel(xP, level) ? ++level : level;
        }

        public static bool ReadyToLevel(int xP, int level)
        {
            int nextLevel = level * 1000;
            int currentXp = 0;
            for (int i = level; i >= 2; --i)
            {
                currentXp += (i - 1) * 1000;
            }

            if ( xP - currentXp >= nextLevel) return true;
            return false;
        }
    }
}
