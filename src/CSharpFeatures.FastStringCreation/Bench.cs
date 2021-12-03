using System;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace CSharpFeatures.FastStringCreation
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.SlowestToFastest)]
    public class Bench
    {
        private const string ClearValue = "Password123!";
        
        [Benchmark]
        // RESULTS:
        // time: 163.10 ns
        // allocation: 400 B
        public string MaskNaive()
        {
            var firstChars = ClearValue.Substring(0, 3);
            var length = ClearValue.Length - 3;

            for (int i = 0; i < length; i++)
            {
                firstChars += '*';
            }

            return firstChars;
        }
        
        [Benchmark]
        // RESULTS:
        // time: 43.75 ns
        // allocation: 120 B
        public string MaskStringBuilder()
        {
            var stringBuilder = new StringBuilder(ClearValue.Length);

            for (var i = 0; i < 3; i++)
            {
                stringBuilder.Append(ClearValue[i]);
            }
            
            for (var i = 3; i < ClearValue.Length; i++)
            {
                stringBuilder.Append('*');
            }
            // OR => stringBuilder.Append('*', ClearValue.Length);

            return stringBuilder.ToString();
        }

        [Benchmark]
        // RESULTS:
        // time: 41.27 ns
        // allocation: 144 B
        public string MaskNewString()
        {
            var firstChars = ClearValue.Substring(0, 3);
            var length = ClearValue.Length - 3;
            var asterisks = new string('*', length);
            
            return firstChars + asterisks;
        }

        [Benchmark]
        // RESULTS:
        // time: 24.40 ns
        // allocation: 80 B
        public string MaskCharArray()
        {
            var charArray = ClearValue.ToCharArray();

            for (var i = 3; i < charArray.Length; i++)
            {
                charArray[i] = '*';
            }

            return new string(charArray);
        }

        [Benchmark]
        // RESULTS:
        // time: 23.11 ns
        // allocation: 96 B
        public string MaskPadRight()
        {
            return ClearValue[..3].PadRight(ClearValue.Length, '*');
        }

        [Benchmark]
        // RESULTS:
        // time: 14.61 ns
        // allocation: 48 B
        public string StackAllocCreate()
        {
            Span<char> result = stackalloc char[ClearValue.Length];

            for (var i = 0; i < 3; i++)
            {
                result[i] = ClearValue[i];
            }

            result[3..].Fill('*');

            return new string(result);
        }

        [Benchmark]
        // RESULTS:
        // time: 13.55 ns
        // allocation: 48 B
        public string MaskStringCreate()
        {
            return string.Create(ClearValue.Length, ClearValue, (span, value) =>
            {
                var asSpan = value.AsSpan();
                
                for (var i = 0; i < 3; i++)
                {
                    span[i] = asSpan[i];
                }

                span[3..].Fill('*');
            });
        }
    }
}

//|            Method |      Mean |    Error |    StdDev |    Median |  Gen 0 | Allocated |
//|------------------ |----------:|---------:|----------:|----------:|-------:|----------:|
//|         MaskNaive | 163.10 ns | 4.106 ns | 11.976 ns | 157.56 ns | 0.0477 |     400 B |
//|     MaskNewString |  43.75 ns | 2.014 ns |  5.938 ns |  42.45 ns | 0.0143 |     120 B |
//| MaskStringBuilder |  41.27 ns | 1.596 ns |  4.580 ns |  40.15 ns | 0.0172 |     144 B |
//|      MaskPadRight |  24.40 ns | 0.551 ns |  1.299 ns |  23.88 ns | 0.0095 |      80 B |
//|     MaskCharArray |  23.11 ns | 0.467 ns |  0.414 ns |  23.03 ns | 0.0115 |      96 B |
//|  StackAllocCreate |  14.61 ns | 0.200 ns |  0.177 ns |  14.62 ns | 0.0057 |      48 B |
//|  MaskStringCreate |  13.55 ns | 0.073 ns |  0.065 ns |  13.55 ns | 0.0057 |      48 B |