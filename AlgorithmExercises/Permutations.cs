using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace AlgorithmExercises
{
    class Permutations
    {
        public static void QuickTest()
        {
            var input = new List<int> { 1, 2, 3, 4 };

            var results = SolveB(input);

            foreach (var result in results)
            {
                var stringResult = $"[{string.Join(",", result.Select(x => x.ToString()))}]";
                Console.WriteLine(stringResult);
            }
        }

        static List<List<int>> SolveA(List<int> array)
        {
            // O(n * n * n!) time | O(n * n!) space
            var results = new List<List<int>>();
            BuildPermutationA(array, new List<int>(), results);
            return results;
        }

        static void BuildPermutationA(List<int> curArray, List<int> curResult, List<List<int>> results)
        {
            if (curArray.Count == 0 && curResult.Count > 0)
            {
                results.Add(curResult);
            }
            else
            {
                foreach (var curInt in curArray)
                {
                    var nextArray = new List<int>(curArray);
                    var nextResult = new List<int>(curResult);
                    nextArray.Remove(curInt);
                    nextResult.Add(curInt);

                    BuildPermutationA(nextArray, nextResult, results);
                }
            }
        }

        static List<List<int>> SolveB(List<int> array)
        {
            // O(n * n!) time | O(n * n!) space
            var results = new List<List<int>>();
            BuildPermutationB(0, array, results);
            return results;
        }

        static void BuildPermutationB(int currIndex, List<int> array, List<List<int>> results)
        {
            if (currIndex == array.Count && array.Count > 0)
            {
                results.Add(new List<int>(array));
            }
            else
            {
                for (var index = currIndex; index < array.Count; index++)
                {
                    Swap(array, currIndex, index);
                    BuildPermutationB(currIndex + 1, array, results);
                    Swap(array, index, currIndex);
                }
            }
        }

        static void Swap(List<int> array, int index1, int index2)
        {
            var temp = array[index1];
            array[index1] = array[index2];
            array[index2] = temp;
        }
    }
}
