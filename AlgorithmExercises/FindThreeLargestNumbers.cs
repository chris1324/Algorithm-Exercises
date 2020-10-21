using System;
using System.Linq;

namespace AlgorithmExercises
{
    class FindThreeLargestNumbers
    {
        public static void QuickTest()
        {
            var input = new int[] { 141, 1, 17, -7, -17, -27, 18, 541, 8, 7, 7 };

            var result = Solve(input);

            Console.WriteLine(string.Join(",", result));
        }

        public static int[] Solve(int[] array)
        {
            // O(n) time | O(1) space

            var results = new int?[3];

            foreach (var number in array)
            {
                UpdateLargest(results, number);
            }

            return results.Select(x => x.Value).ToArray();
        }

        private static void UpdateLargest(int?[] array, int number)
        {
            if (array[2] == null || array[2] < number)
            {
                ShiftndUpdate(array, number, 2);
            }
            else if (array[1] == null || array[1] < number)
            {
                ShiftndUpdate(array, number, 1);
            }
            else if (array[0] == null || array[0] < number)
            {
                ShiftndUpdate(array, number, 0);
            }

        }

        private static void ShiftndUpdate(int?[] array, int number, int index)
        {
            for (var i = 0; i <= index; i++)
            {
                if (i == index)
                {
                    array[i] = number;
                }
                else
                {
                    array[i] = array[i + 1];
                }
            }
        }
    }
}
