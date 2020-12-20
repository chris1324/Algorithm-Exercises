using System;
using System.Text.Json;

namespace AlgorithmExercises
{
    class Quickselect
    {
        public static int Solve(int[] array, int k)
        {
            var kthIndex = k - 1;
            return SolveHelper(array, 0, array.Length - 1, kthIndex);
        }

        public static int SolveHelper(int[] array, int startIndex, int endIndex, int kthIndex)
        {
            // Best : O(nlog(n)) time | O(log(n)) space
            // Average : O(nlog(n)) time | O(log(n)) space
            // Worst : O(n^2) time | O(log(n)) space
            // Note : space complexity can be improved by using iterative approach
            var pivot = array[startIndex];
            var left = startIndex + 1;
            var right = endIndex;

            while (left <= right)
            {

                var leftValue = array[left];
                var rightValue = array[right];

                var isLeftCorrectOrder = leftValue <= pivot;
                var isRightCorrectOder = rightValue >= pivot;

                if (!isLeftCorrectOrder && !isRightCorrectOder)
                {
                    Swap(array, left, right);
                }
                else if (isLeftCorrectOrder)
                {
                    left++;
                }
                else if (isRightCorrectOder)
                {
                    right--;
                }
            }

            Swap(array, startIndex, right);

            if (right == kthIndex)
            {
                return array[right];
            }
            else if (right > kthIndex)
            {
                return SolveHelper(array, startIndex, left - 1, kthIndex);
            }
            else
            {
                return SolveHelper(array, right + 1, endIndex, kthIndex);
            }
        }

        private static void Swap(int[] array, int indexA, int indexB)
        {
            var indexAValue = array[indexA];
            array[indexA] = array[indexB];
            array[indexB] = indexAValue;
        }
    }
}
