using System;
using System.Linq;

namespace CSharpFeatures.LinqImprovements
{
    /// <summary>
    /// C# 8 (indexes and range)
    /// </summary>
    public class TakeAcceptRangeAndIndex
    {
        public TakeAcceptRangeAndIndex()
        {
            var words = new[] { "Joao", "Kucera", "CSharp", "InnoGames", "Dev", "Talks" };

            // var slice_OLD = words.Skip(2).Take(2);
            
            // NEW
            var slice_NEW = words.Take(2..4);
            var lastThree = words.Take(^3..);
            
            Console.ReadKey();
        }
    }
}