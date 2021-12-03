using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace CSharpFeatures.DynamicType
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.SlowestToFastest)]
    public class Bench
    {
        private static readonly Samples Samples = new();

        [Benchmark]
        public string GetNameDynamic()
        {
            return Samples.GetNameDynamic();
        }
        
        [Benchmark]
        public string GetNameActual()
        {
            return Samples.GetNameActual();
        }
        
        [Benchmark]
        public string GetNamesInListDynamic()
        {
            return Samples.GetNamesInListDynamic();
        }
        
        [Benchmark]
        public string GetNamesInListActual()
        {
            return Samples.GetNamesInListActual();
        }
    }
}