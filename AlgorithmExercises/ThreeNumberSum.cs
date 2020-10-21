using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmExercises
{
    class ThreeNumberSum
    {
        public static void QuickTest()
        {
            var array = new int[] { 12, 3, 1, 2, -6, 5, -8, 6 };
            var targetSum = 0;

            var results = Solve(array, targetSum);

            foreach (var result in results)
            {
                var resultInString = $"[{string.Join(",", result)}]";
                var sum = result.Sum();

                var message = sum == targetSum
                    ? $"SUCCESS - {resultInString}"
                    : $"ERROR - {resultInString} : expect {targetSum} but got {sum}";

                Console.WriteLine(message);
            }
        }

        private static List<int[]> Solve(int[] array, int targetSum)
        {
            // O(n^2) time | O(n) space

            var results = new List<int[]>();

            Array.Sort(array);

            for (var i = 0; i < array.Length; i++)
            {
                var currentValue = array[i];

                var leftIndex = i + 1;
                var rightIndex = array.Length - 1;

                while (leftIndex < rightIndex)
                {
                    var leftValue = array[leftIndex];
                    var rightValue = array[rightIndex];

                    var currentSum = currentValue + rightValue + leftValue;

                    if (currentSum == targetSum)
                    {
                        results.Add(new int[] { currentValue, leftValue, rightValue });
                        leftIndex++;
                        rightIndex--;
                    }
                    else if (currentSum > targetSum)
                    {
                        rightIndex--;
                    }
                    else if (currentSum < targetSum)
                    {
                        leftIndex++;
                    }
                }
            }

            return results;
        }
    }
}
