using System;
using System.Collections.Generic;
using System.Linq;

namespace Autocomplete
{
    public class RightBorderTask
    {
        /// <returns>
        /// Возвращает индекс правой границы. 
        /// То есть индекс минимального элемента, который не начинается с prefix и большего prefix.
        /// Если такого нет, то возвращает items.Length
        /// </returns>
        /// <remarks>
        /// Функция должна быть НЕ рекурсивной
        /// и работать за O(log(items.Length)*L), где L — ограничение сверху на длину фразы
        /// </remarks>
        public static int GetRightBorderIndex(IReadOnlyList<string> phrases, string prefix, int left, int right)
        {
            while (left != right - 1)
            {
                var m = left + (right - left) / 2;
                if (string.Compare(prefix, phrases[m], StringComparison.OrdinalIgnoreCase) >= 0
                    || phrases[m].StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
                    left = m;
                else right = m;
            }
            return right;
        }
    }
}
/*for (int i = phrases.Count-1; i >= 0; i--)
            {
                if (string.Compare(prefix, phrases[i], StringComparison.OrdinalIgnoreCase) >= 0 
                    || phrases[i].StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
                    return i + 1;
            }
            return 0;

 public static int GetLeftBorderIndex(IReadOnlyList<string> phrases, string prefix, int left, int right)
        {
            if (left == right - 1) return left;
            var m = left + (right - left) / 2;
            if (string.Compare(prefix, phrases[m], StringComparison.OrdinalIgnoreCase) < 0 
                || phrases[m].StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
                return GetLeftBorderIndex(phrases, prefix, left, m);
            return GetLeftBorderIndex(phrases, prefix, m, right);
        }        
 while (left != right - 1)
            {
                var m = left + (right - left) / 2;
                if (string.Compare(prefix, phrases[m], StringComparison.OrdinalIgnoreCase) >= 0
                    || phrases[m].StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
                    right = m + 1;
                else left = m;
            }
            if (phrases[right] == prefix)
                return right + 1;
            return phrases.Count;
 */

