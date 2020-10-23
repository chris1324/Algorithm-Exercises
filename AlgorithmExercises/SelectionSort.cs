using System;
using System.Text.Json;

namespace AlgorithmExercises
{
    class SelectionSort
    {
        public static void QuickTest()
        {
            var input = new int[] { 8, 5, 2, 9, 5, 6, 3 };

            var result = Solve(input);

            Console.WriteLine(JsonSerializer.Serialize(result));
        }

        public static int[] Solve(int[] array)
        {
            // O(n^2) time | O(1) space

            for (int i = 0; i < array.Length - 1; i++)
            {
                var index = i;
                var smallestValueIndex = i;

                while (index < array.Length)
                {
                    var value = array[index];
                    if (value < array[smallestValueIndex])
                    {
                        smallestValueIndex = index;
                    }

                    index++;
                }

                Swap(array, i, smallestValueIndex);
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
