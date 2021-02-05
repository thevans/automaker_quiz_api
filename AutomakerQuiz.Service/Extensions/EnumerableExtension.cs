using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutomakerQuiz.Service.Extensions
{
    public static class EnumerableExtension
    {
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> list)
        {
            var r = new Random();
            var shuffledList =
                list.
                    Select(x => new { Number = r.Next(), Item = x }).
                    OrderBy(x => x.Number).
                    Select(x => x.Item); // Assume first @size items is fine

            return shuffledList.ToList();
        }
    }
}
