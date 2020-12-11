using System;
using System.Linq;
using System.Text.Json;

namespace AlgorithmExercises
{
    class ThreeNumberSort
    {
        public static void QuickTest()
        {
            var array = new int[] { 0, 10, 10, 10, 10, 10, 25, 25, 25, 25, 25 };
            var order = new int[] { 25, 10, 0 };

            Console.WriteLine(JsonSerializer.Serialize(Solve(array, order)));
        }

        public static int[] Solve(int[] array, int[] order)
        {
            // O(n) time | O(1) space
            var orderList = order.ToList();

            var nextFirstNumIndex = 0;
            var nextSecondNumIndex = 0;
            var nextThridNumIndex = array.Length - 1;

            while (nextSecondNumIndex <= nextThridNumIndex)
            {
                var num = array[nextSecondNumIndex];

                var isFirst = orderList.IndexOf(num) == 0;
                var isSecond = orderList.IndexOf(num) == 1;

                if (isFirst)
                {
                    Swap(array, nextFirstNumIndex, nextSecondNumIndex);
                    nextFirstNumIndex++;
                    nextSecondNumIndex++;
                }
                else if (isSecond)
                {
                    nextSecondNumIndex++;
                }
                else
                {
                    Swap(array, nextThridNumIndex, nextSecondNumIndex);
                    nextThridNumIndex--;
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
