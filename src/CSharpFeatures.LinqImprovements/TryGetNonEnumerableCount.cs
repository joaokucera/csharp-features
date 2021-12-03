using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpFeatures.LinqImprovements
{
    public class TryGetNonEnumerableCount
    {
        public TryGetNonEnumerableCount()
        {
            var firstSet = new[] { "Joao Kucera" };
            var secondSet = new[] { "CSharp InnoGames" };
            var thirdSet = new[] { "Dev Talks" };

            IEnumerable<string> words = firstSet.Concat(secondSet).Concat(thirdSet);
            //var count = words.Count();
            
            // Possible multiple enumerations (it means it will be operated twice)
            //var orderedWords = words.OrderBy(x => x);

            // Without forcing enumeration
            if (words.TryGetNonEnumeratedCount(out var count))
            {
            }
            
            Console.ReadKey();
        }
    }
}