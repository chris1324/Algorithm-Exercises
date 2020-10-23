using System;

namespace AlgorithmExercises
{
    class BinarySearch
    {
        public static void QuickTest()
        {
            var input = new int[] { 5, 23, 111 };
            var target = 3;

            Console.WriteLine(SolveA(input, target));
        }

        public static int SolveA(int[] array, int target)
        {
            // O(n) time | O(Log(n)) space
            // Using recursive approach
            return SolveAHelper(array, target, 0, array.Length - 1);
        }

        public static int SolveAHelper(int[] array, int target, int left, int right)
        {
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
                return SolveAHelper(array, target, middle + 1, right);
            }
            else
            {
                return SolveAHelper(array, target, left, middle - 1);
            }
        }

        public static int SolveB(int[] array, int target)
        {
            // O(n) time | O(1) space
            // Using iterative approach
            var left = 0;
            var right = array.Length - 1;

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
