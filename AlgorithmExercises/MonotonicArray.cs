using System;

namespace AlgorithmExercises
{
    class MonotonicArray
    {
        static bool Solve(int[] array)
        {
            // O(n) time | O(1) space

            var hasIncrease = false;
            var hasDecrease = false;

            for (var i = 0; i < array.Length - 1; i++)
            {
                if (hasIncrease && hasDecrease)
                {
                    break;
                }

                if (array[i] < array[i + 1])
                {
                    hasIncrease = true;
                }
                else if (array[i] > array[i + 1])
                {
                    hasDecrease = true;
                }
            }

            return !(hasIncrease && hasDecrease);
        }
    }
}
