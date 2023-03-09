using PracticeCommon.Comparers;

using System;
using System.Linq;

namespace PracticeCommon.Extensions
{
    public static class StringExtension
    {
        /// <summary>
        /// This sorts the string using each character for comparison
        /// </summary>
        /// <param name="unsorted">the unsorted string</param>
        /// <returns>a sorted string</returns>
        public static string Sort(this string unsorted)
        {
            if (unsorted.Length <= 1) return unsorted;

            var enumerable = unsorted.OrderBy(c => c, new CharComparer());
            string sorted = string.Join("", enumerable);

            return sorted;
        }
    }
}
