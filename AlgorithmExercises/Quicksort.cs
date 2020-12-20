using System;
using System.Text.Json;

namespace AlgorithmExercises
{
    class Quicksort
    {
        public static void QuickTest()
        {
            int[] input = { 8, 5, 2, 9, 5, 6, 3 };
            Console.WriteLine(JsonSerializer.Serialize(Solve(input)));
        }

        public static int[] Solve(int[] array)
        {
            SolveHelper(array, 0, array.Length - 1);
            return array;
        }

        public static void SolveHelper(int[] array, int startIndex, int endIndex)
        {
            // Best : O(nlog(n)) time | O(log(n)) space
            // Average : O(nlog(n)) time | O(log(n)) space
            // Worst : O(n^2) time | O(log(n)) space
            if (startIndex >= endIndex)
            {
                return;
            }

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

            SolveHelper(array, startIndex, right - 1);
            SolveHelper(array, right + 1, endIndex);
        }

        private static void Swap(int[] array, int indexA, int indexB)
        {
            var indexAValue = array[indexA];
            array[indexA] = array[indexB];
            array[indexB] = indexAValue;
        }
    }
}
