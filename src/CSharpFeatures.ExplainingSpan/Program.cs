using System;
using BenchmarkDotNet.Running;

namespace CSharpFeatures.ExplainingSpan
{
    public class Program
    {
        private const string DateAsText = "03 12 2021";

        // ref stuct = cannot be created in the heap
        // private ReadOnlySpan<char> dateAsSpan = DateAsText;
        
        static void Main(string[] args)
        {
           var date = DateWithStringAndSubstring();
           Console.WriteLine(date);
            
           // Console.WriteLine(YearAsText());
           
           // only works in RELEASE mode
           // BenchmarkRunner.Run<Bench>();
        }
        
        private static (int day, int month, int year) DateWithStringAndSubstring()
        {
            var dayAsText = DateAsText.Substring(0, 2);
            var monthAsText = DateAsText.Substring(3, 2);
            var yearAsText = DateAsText.Substring(6);
            
            var day = int.Parse(dayAsText);
            var month = int.Parse(monthAsText);
            var year = int.Parse(yearAsText);
            
            // return (3, 12, 2021);
            return (day, month, year);
        }
        
        private static (int day, int month, int year) DateWithStringAndSpan()
        {
            ReadOnlySpan<char> dateAsSpan = DateAsText;
            
            // foreach (var character in dateAsSpan)
            // {
            // array!
            // }

            var dayAsText = dateAsSpan.Slice(0, 2);
            var monthAsText = dateAsSpan.Slice(3, 2);
            var yearAsText = dateAsSpan.Slice(6);
            
            var day = int.Parse(dayAsText);
            var month = int.Parse(monthAsText);
            var year = int.Parse(yearAsText);
            
            // return (3, 12, 2021);
            return (day, month, year);
        }
        
        private static string YearAsText()
        {
            ReadOnlySpan<char> dateAsSpan = DateAsText;
            var yearAsText = dateAsSpan.Slice(6);
            return yearAsText.ToString();
        }
    }
}