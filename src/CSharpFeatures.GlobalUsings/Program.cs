using System;

namespace CSharpFeatures.GlobalUsings
{
    public class Program
    {
        static void Main(string[] args)
        {
            var words = new[] {"CSharp", "Rider", "DevTalks", "Programming"};
            var serialized = JsonSerializer.Serialize(words);
            
            Console.WriteLine(serialized);
        }
    }
}
