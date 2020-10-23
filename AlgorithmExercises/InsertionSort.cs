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
                var index = i;

                while (index > 0 && array[index - 1] > array[index])
                {
                    Swap(array, index, index - 1);
                    index--;
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
