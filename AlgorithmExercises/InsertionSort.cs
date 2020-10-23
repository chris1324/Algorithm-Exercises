using System;

namespace AlgorithmExercises
{
    class InsertionSort
    {
        public static int[] Solve(int[] array)
        {
            // O(n^2) time | O(1) space

            for (int i = 1; i < array.Length; i++)
            {
                var isSorted = false;
                var index = 1;
                var previousIndex = i - 1;

                while (previousIndex >= 0 || !isSorted)
                {
                    if (array[previousIndex] > array[index])
                    {
                        Swap(array, index, previousIndex);
                        index--;
                        previousIndex--;
                    }
                    else
                    {
                        isSorted = true;
                    }
                }
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
