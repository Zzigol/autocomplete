using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Autocomplete
{
    internal class AutocompleteTask
    {
        /// <returns>
        /// Возвращает первую фразу словаря, начинающуюся с prefix.
        /// </returns>
        /// <remarks>
        /// Эта функция уже реализована, она заработает, 
        /// как только вы выполните задачу в файле LeftBorderTask
        /// </remarks>
        public static string FindFirstByPrefix(IReadOnlyList<string> phrases, string prefix)
        {
            var index = LeftBorderTask.GetLeftBorderIndex(phrases, prefix, -1, phrases.Count) + 1;
            if (index < phrases.Count && phrases[index].StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
                return phrases[index];
            
            return null;
        }

        /// <returns>
        /// Возвращает первые в лексикографическом порядке count (или меньше, если их меньше count) 
        /// элементов словаря, начинающихся с prefix.
        /// </returns>
        /// <remarks>Эта функция должна работать за O(log(n) + count)</remarks>
        public static string[] GetTopByPrefix(IReadOnlyList<string> phrases, string prefix, int count)
        {
            var list = new List<string>();
            //string[] lines = new string[count];
            var numberPrefix = LeftBorderTask.GetLeftBorderIndex(phrases, prefix, -1, phrases.Count) +1;
            var number = RightBorderTask.GetRightBorderIndex(phrases, prefix, -1, phrases.Count) -
                        LeftBorderTask.GetLeftBorderIndex(phrases, prefix, -1, phrases.Count) - 1;
            if (number > count)
                for (int i = numberPrefix, j=0; i < numberPrefix + count; i++, j++)
                    list.Add(phrases[i]);
                    
            else
                for (int i = numberPrefix, j = 0; i < numberPrefix + number; i++, j++)
                    list.Add(phrases[i]);
            return list.ToArray();
        }

        /// <returns>
        /// Возвращает количество фраз, начинающихся с заданного префикса
        /// </returns>
        public static int GetCountByPrefix(IReadOnlyList<string> phrases, string prefix)
        {
            var number = 0;
            if  (phrases.Contains(prefix))
                    number = RightBorderTask.GetRightBorderIndex(phrases, prefix, -1, phrases.Count) -
                        LeftBorderTask.GetLeftBorderIndex(phrases, prefix, -1, phrases.Count)-1;
            else
            {
                foreach (var phrase in phrases)
                {
                    if (phrase.StartsWith(prefix))
                    {
                        number +=1;
                    }

                }
            }
            
            
            return number;
        }
    }

    [TestFixture]
    public class AutocompleteTests
    {
        [Test]
        public void TopByPrefix_IsEmpty_WhenNoPhrases()
        {
            // ...
            //CollectionAssert.IsEmpty(actualTopWords);
        }

        // ...

        [Test]
        public void CountByPrefix_IsTotalCount_WhenEmptyPrefix()
        {
            // ...
            //Assert.AreEqual(expectedCount, actualCount);
        }

        // ...
    }
}
