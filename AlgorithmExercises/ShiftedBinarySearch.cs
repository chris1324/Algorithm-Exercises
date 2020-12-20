using System;

namespace AlgorithmExercises
{
    class ShiftedBinarySearch
    {
        public static void QuickTest()
        {
            var inputs = new int[] { 5, 61, 71, 72, 73, 0, 1, 21, 33, 37 };
            var target = 1;

            Console.WriteLine(SolveA(inputs, target));
        }

        public static int SolveA(int[] array, int target)
        {
            // O(log(n)) time | O(log(n)) space
            // Recursive approach
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

            var leftValue = array[left];
            var rightValue = array[right];
            var isLeftSorted = leftValue < middleValue;

            Func<int> exploreLeft = () => SolveAHelper(array, target, left, middle - 1);
            Func<int> exploreRight = () => SolveAHelper(array, target, middle + 1, right);

            if (isLeftSorted)
            {
                // Left sorted
                if (target <= middleValue && target >= leftValue)
                {
                    return exploreLeft();
                }
                else
                {
                    return exploreRight();
                }
            }
            else
            {
                // Right sorted
                if (target >= middleValue && target <= rightValue)
                {
                    return exploreRight();
                }
                else
                {
                    return exploreLeft();
                }
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

                var leftValue = array[left];
                var rightValue = array[right];
                var isLeftSorted = leftValue < middleValue;

                if (isLeftSorted)
                {
                    // Left sorted
                    if (target <= middleValue && target >= leftValue)
                    {
                        right = middle - 1;
                    }
                    else
                    {
                        left = middle + 1;
                    }
                }
                else
                {
                    // Right sorted
                    if (target >= middleValue && target <= rightValue)
                    {
                        left = middle + 1;
                    }
                    else
                    {
                        right = middle - 1;
                    }
                }

            }

            return -1;
        }
    }
}
