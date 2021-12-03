using System;
using System.Linq;

namespace CSharpFeatures.LinqImprovements
{
    /// <summary>
    /// C# 8 (indexes)
    /// </summary>
    public class ElementAtAcceptsIndex
    {
        public ElementAtAcceptsIndex()
        {
            var words = new[] { "Joao", "Kucera", "CSharp", "InnoGames", "Dev", "Talks" };
                                // 0
                                                                                        // 0
            //var word = words.ElementAt(3);
            
            // NEW
            var wordFromTheEnd = words.ElementAt(^3);
            
            Console.ReadKey();
        }
    }
}