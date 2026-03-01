# PointsBet_Backend_Online_Code_Test

This is the solution for `PointsBet_Backend_Online_Code_Test` completed by Xin Wang.

```
Requirements in the `StringFormatter.cs` file
- Cleaning up code
- Removing redundancy
- Refactoring / simplifying
- Fixing typos
- Any other light-weight optimisation

Corrections and enhancements 
- Correct typo in ToCommaSeparatedList
- rename ToCommaSeparatedList to ToDelimiterSeparatedQuotedString with an additional parameter named delimiter for:
  - clarity on the return type, as ToCommaSeparatedList might suggest the method is returning a collection
  - additional parameter, delimiter, enhances the reusability of this method
  - giving delimiter a comma as the default value prevents the signature change breaking dependencies
- Skipping null check for items due to Nullable reference types enabled
- Short circuit returning empty string when items array contains no item 
- Create new string array to prevent making changes to the values in reference type items, which might be used somewhere else
- Bad data handling filters out any string in the items array being null, empty, or whitespace only
- Prefix and suffix the item with quote only when quote is not null or empty, considered whitespace/s could potentially be the quote value
- Use interpolation instead of String.Format for better readability and compile-time safty as template errors in String.Format can only be noticed during run-time
- Trimming delimiter ensures the separation always to be the delimiter followed by a single whitespace
- string.Join offers better readability and performance compared to a StringBuilder
- Unit tests included with 100% code coverage
- Overall offers at least 100% performance gain and approximately 10% less memory allocation on large string array input

Benchmark Result:

BenchmarkDotNet v0.15.8, Windows 11 (10.0.26200.7840/25H2/2025Update/HudsonValley2)
AMD Ryzen 9 5950X 3.40GHz, 1 CPU, 32 logical and 16 physical cores
.NET SDK 10.0.103
  [Host]     : .NET 10.0.3 (10.0.3, 10.0.326.7603), X64 RyuJIT x86-64-v3
  DefaultJob : .NET 10.0.3 (10.0.3, 10.0.326.7603), X64 RyuJIT x86-64-v3


```
| Method                           | N   | Mean        | Error     | StdDev    | Ratio | Gen0   | Gen1   | Allocated | Alloc Ratio |
|--------------------------------- |---- |------------:|----------:|----------:|------:|-------:|-------:|----------:|------------:|
| **ToDelimiterSeparatedQuotedString** | **5**   |    **208.4 ns** |   **2.29 ns** |   **2.03 ns** |  **0.50** | **0.0434** |      **-** |     **728 B** |        **1.23** |
| ToCommaSepatatedList             | 5   |    417.0 ns |   1.40 ns |   1.31 ns |  1.00 | 0.0353 |      - |     592 B |        1.00 |
|                                  |     |             |           |           |       |        |        |           |             |
| **ToDelimiterSeparatedQuotedString** | **50**  |  **1,510.8 ns** |   **8.80 ns** |   **7.35 ns** |  **0.38** | **0.2251** | **0.0019** |    **3776 B** |        **0.84** |
| ToCommaSepatatedList             | 50  |  3,955.0 ns |  16.56 ns |  14.68 ns |  1.00 | 0.2670 |      - |    4488 B |        1.00 |
|                                  |     |             |           |           |       |        |        |           |             |
| **ToDelimiterSeparatedQuotedString** | **500** | **15,218.8 ns** |  **73.62 ns** |  **65.26 ns** |  **0.39** | **2.4719** | **0.1526** |   **41576 B** |        **0.90** |
| ToCommaSepatatedList             | 500 | 39,092.8 ns | 135.84 ns | 127.06 ns |  1.00 | 2.7466 | 0.0610 |   46072 B |        1.00 |

