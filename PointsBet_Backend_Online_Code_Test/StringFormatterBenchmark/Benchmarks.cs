using System;
using System.Linq;
using BenchmarkDotNet;
using BenchmarkDotNet.Attributes;

namespace StringFormatterBenchmark
{
    [MemoryDiagnoser]
    public class Benchmarks
    {
        [Params(5, 50, 500)] //<-- This is a parameter attribute
        public int N { get; set; }

        private const string QUOTE = "'";
        
        [Benchmark]
        public string ToDelimiterSeparatedQuotedString()
        {
            var items = Enumerable.Range(0, N).Select(i => i.ToString()).ToArray();
            
            return PointsBet_Backend_Online_Code_Test.StringFormatter.ToDelimiterSeparatedQuotedString(items, QUOTE);
        }

        [Benchmark(Baseline = true)]
        public string ToCommaSepatatedList()
        {
            var items = Enumerable.Range(0, N).Select(i => i.ToString()).ToArray();
            
            return PointsBet_Backend_Online_Code_Test.StringFormatter.ToCommaSepatatedList(items, QUOTE);
        }
    }
}
