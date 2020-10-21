using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmExercises
{
    class TwoNumberSum
    {
        private static int[] SolveA(int[] array, int targetSum)
        {
            // O(n) time | O(n) space

            var numbers = new HashSet<int>();

            for (var i = 0; i < array.Length; i++)
            {
                var currentValue = array[i];
                var requiredNumber = targetSum - currentValue;

                if (numbers.Contains(requiredNumber))
                {
                    return new int[] { currentValue, requiredNumber };
                }
                else
                {
                    numbers.Add(currentValue);
                }
            }

            return new int[] { };
        }

        private static int[] SolveB(int[] array, int targetSum)
        {
            // O(n) time | O(1) space

            Array.Sort(array);

            var leftIndex = 0;
            var rightIndex = array.Length - 1;

            while (leftIndex < rightIndex)
            {
                var leftValue = array[leftIndex];
                var rightValue = array[rightIndex];
                var currentSum = leftValue + rightValue;

                if (currentSum == targetSum)
                {
                    return new int[] { leftValue, rightValue };
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

            return new int[] { };
        }
    }
}
