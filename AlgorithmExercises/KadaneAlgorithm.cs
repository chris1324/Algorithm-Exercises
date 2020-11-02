using System;

namespace AlgorithmExercises
{
    class KadaneAlgorithm
    {
        static int Solve(int[] array)
        {
            var currentMaxSum = array[0];
            var previousSum = array[0];

            for (var i = 1; i < array.Length; i++)
            {
                var sum = Math.Max(previousSum + array[i], array[i]);

                if (sum > currentMaxSum) currentMaxSum = sum;

                previousSum = sum;
            }

            return currentMaxSum;
        }
    }
}
