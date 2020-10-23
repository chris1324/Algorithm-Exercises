using System;

namespace AlgorithmExercises
{
    class BubbleSort
    {
        public static int[] Solve(int[] array)
        {
            // O(n^2) time | O(1) space
            var isSorted = false;
            var iterationCount = 0;

            while (!isSorted)
            {
                isSorted = true;

                var lastIndexToCompare = array.Length - 1 - iterationCount;

                for (var j = 0; j < lastIndexToCompare; j++)
                {
                    var currentIndex = j;
                    var nextIndex = currentIndex + 1;
                    if (array[currentIndex] > array[nextIndex])
                    {
                        Swap(array, currentIndex, nextIndex);
                        isSorted = false;
                    }
                }

                iterationCount++;
            }

            return array;
        }

        private static void Swap(int[] array, int indexA, int indexB)
        {
            var indexAValue = array[indexA];
            array[indexA] = array[indexB];
            array[indexB] = indexAValue;
        }
    }
}
