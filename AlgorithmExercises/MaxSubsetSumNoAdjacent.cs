using System;

namespace AlgorithmExercises
{
    class MaxSubsetSumNoAdjacent
    {
        static int Solve(int[] array)
        {
            // O(n) time | O(i) space
            if (array.Length == 0) return 0;
            else if (array.Length == 1) return array[0];

            var first = array[0];
            var second = Math.Max(array[0], array[1]);

            for (var i = 2; i < array.Length; i++)
            {
                var maxSum = Math.Max(second, first + array[i]);
                first = second;
                second = maxSum;
            }

            return second;
        }
    }
}
