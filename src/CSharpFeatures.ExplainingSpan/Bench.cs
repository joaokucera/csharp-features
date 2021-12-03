using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace CSharpFeatures.ExplainingSpan
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.SlowestToFastest)]
    public class Bench
    {
        private const string DateAsText = "03 12 2021";
        
        [Benchmark]
        // RESULTS:
        // time: 73.67 ns
        // allocation: 96 B
        public (int day, int month, int year) DateWithStringAndSubstring()
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
        
        [Benchmark]
        // RESULTS:
        // time: 42.24 ns
        // allocation: -
        public (int day, int month, int year) DateWithStringAndSpan()
        {
            ReadOnlySpan<char> dateAsSpan = DateAsText;

            var dayAsText = dateAsSpan.Slice(0, 2);
            var monthAsText = dateAsSpan.Slice(3, 2);
            var yearAsText = dateAsSpan.Slice(6);
            
            var day = int.Parse(dayAsText);
            var month = int.Parse(monthAsText);
            var year = int.Parse(yearAsText);
            
            // return (3, 12, 2021);
            return (day, month, year);
        }
    }
}

// |                     Method |     Mean |    Error |   StdDev |  Gen 0 | Allocated |
// |--------------------------- |---------:|---------:|---------:|-------:|----------:|
// | DateWithStringAndSubstring | 73.67 ns | 1.287 ns | 1.204 ns | 0.0114 |      96 B |
// |      DateWithStringAndSpan | 42.24 ns | 0.941 ns | 2.744 ns |      - |         - |