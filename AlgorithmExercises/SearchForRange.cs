using System;
using System.Text.Json;

namespace AlgorithmExercises
{
    class SearchForRange
    {
        public static void QuickTest()
        {
            int[] output = Solve(new int[] { 0, 1, 21, 33, 45, 45, 45, 45, 45, 45, 61, 71, 73 }, 45);

            Console.WriteLine(JsonSerializer.Serialize(output));
        }

        public static int[] Solve(int[] array, int target)
        {
            var rangeStartIndex = -1;
            var rangeEndIndex = -1;

            var leftIndex = 0;
            var rightIndex = array.Length - 1; ;

            var targetPosition = SolveB(array, target, leftIndex, rightIndex);

            if (targetPosition != -1)
            {
                rangeStartIndex = targetPosition;
                rangeEndIndex = targetPosition;

                while (rangeStartIndex - 1 >= 0 && array[rangeStartIndex - 1] == target)
                {
                    rangeStartIndex = SolveB(array, target, 0, rangeStartIndex - 1);
                }

                while (rangeEndIndex + 1 < array.Length && array[rangeEndIndex + 1] == target)
                {
                    rangeEndIndex = SolveHelper(array, target, rangeEndIndex + 1, array.Length);
                }
            }

            return new int[] { rangeStartIndex, rangeEndIndex };
        }

        public static int SolveHelper(int[] array, int target, int left, int right)
        {
            // O(n) time | O(Log(n)) space
            // Using recursive approach
            if (left > right)
            {
                return -1;
            }

            var middle = (left + right) / 2;
            var middleValue = array[middle];

            if (middleValue == target)
            {
                return middle;
            }
            else if (target > middleValue)
            {
                return SolveHelper(array, target, middle + 1, right);
            }
            else
            {
                return SolveHelper(array, target, left, middle - 1);
            }
        }

        public static int SolveB(int[] array, int target, int left, int right)
        {
            // O(n) time | O(1) space
            // Using iterative approach

            while (left <= right)
            {
                var middle = (left + right) / 2;
                var middleValue = array[middle];

                if (middleValue == target)
                {
                    return middle;
                }
                else if (target > middleValue)
                {
                    left = middle + 1;
                }
                else
                {
                    right = middle - 1;
                }
            }

            return -1;
        }
    }
}
