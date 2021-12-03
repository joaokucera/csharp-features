using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpFeatures.LinqImprovements
{
    public class ChunkSample
    {
        public ChunkSample()
        {
            var words = new[] { "Joao", "Kucera", "CSharp", "InnoGames", "Dev", "Talks" };
            
            // "Joao", "CSharp", "Unity"
            // "Dev", "Talks", "InnoGames"
            // IEnumerable<IEnumerable<string>> chunked = ChunkBy(words, 3);

            // NEW
            // var chunked = words.Chunk(3);
            
            Console.ReadKey();
        }

        private static IEnumerable<IEnumerable<T>> ChunkBy<T>(IEnumerable<T> source, int chunkSize)
        {
            return source
                .Select((x, i) => new {Index = i, Value = x})
                .GroupBy(x => x.Index / chunkSize)
                .Select(x => x.Select(v => v.Value));
        }
    }
}