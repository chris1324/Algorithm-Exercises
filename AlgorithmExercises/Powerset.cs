using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace AlgorithmExercises
{
    class Powerset
    {
        public static void QuickTest()
        {
            var input = new List<int> { 1, 2, 3, 4 };

            var results = SolveA(input);

            foreach (var result in results)
            {
                var stringResult = $"[{string.Join(",", result.Select(x => x.ToString()))}]";
                Console.WriteLine(stringResult);
            }
        }

        static List<List<int>> SolveA(List<int> array)
        {
            // Iterative approach
            // O(2^n * n!) time | O(2^n * n) space
            var results = new List<List<int>>();
            results.Add(new List<int>());

            foreach (var curInt in array)
            {
                var curResults = new List<List<int>>();

                foreach (var result in results)
                {
                    var curResult = new List<int>(result);
                    curResult.Add(curInt);
                    curResults.Add(curResult);
                }

                foreach (var curResult in curResults) results.Add(curResult);
            }
            return results;
        }
    }
}
