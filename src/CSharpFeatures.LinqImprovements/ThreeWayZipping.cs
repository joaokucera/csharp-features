using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpFeatures.LinqImprovements
{
    public class ThreeWayZipping
    {
        public ThreeWayZipping()
        {
            var words = new[] { "Joao Kucera", "CSharp InnoGames", "Dev Talks" };
            var numbers = new[] { 20, 30, 40 };
            var others = new[] { true, false, true };

            // It was in LINQ already
            // IEnumerable<(string word, int number)>? zip = words.Zip(numbers);
            
            // NEW
            // IEnumerable<(string word, int number, bool valid)>? zip = words.Zip(numbers, others);
            
            Console.ReadKey();
        }
    }
}