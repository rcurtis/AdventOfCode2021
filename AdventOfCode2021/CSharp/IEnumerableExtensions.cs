using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<IEnumerable<T>> Window<T>(this IEnumerable<T> self, int windowSize)
        {
            var selfToList = self.ToList();
            var length = selfToList.Count - (windowSize - 1);
            for (var i = 0; i < length; i++)
            {
                var range = new Range(i, i + windowSize);
                yield return selfToList.Take(range);
            }
        }
        
        public static IEnumerable<T []> Transpose<T>(this IEnumerable<IEnumerable<T>> source)
        {
            var enumerators = source.Select(e => e.GetEnumerator()).ToArray();
            while (enumerators.All(e => e.MoveNext()))
                yield return enumerators.Select(e => e.Current).ToArray();
        }
    }
}