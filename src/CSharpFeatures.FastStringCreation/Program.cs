using System;
using BenchmarkDotNet.Running;

namespace CSharpFeatures.FastStringCreation
{
    public class Program
    {
        private const string ClearValue = "Password123!";

        static void Main(string[] args)
        {
            // What I want:
            Console.WriteLine("Pas*********");
            
            // var firstChars = MaskNaive();
            // Result:
            // Console.WriteLine(firstChars);
            
            // only works in RELEASE mode
            // BenchmarkRunner.Run<Bench>();
        }
        
        private static string MaskNaive()
        {
            var firstChars = ClearValue.Substring(0, 3);
            var length = ClearValue.Length - 3;

            for (int i = 0; i < length; i++)
            {
                firstChars += '*';
            }

            return firstChars;
        }
    }
}