using System;

namespace AlgorithmExercises
{
    class LongestPeak
    {
        public static void QuickTest()
        {
            var input = new int[] { 1, 2, 3, 3, 4, 0, 10, 6, 5, -1, -3, 2, 3 };

            Console.WriteLine(Solve(input));
        }

        static int Solve(int[] array)
        {
            // O(n) time | O(1) space
            var longestPeak = 0;

            for (var i = 1; i < array.Length - 1; i++)
            {
                var currentValue = array[i];
                var previousValue = array[i - 1];
                var nextValue = array[i + 1];

                var isPeak = currentValue > previousValue && currentValue > nextValue;

                if (isPeak)
                {
                    var leftIndex = i - 1;
                    for (; leftIndex > 0; leftIndex--)
                        if (array[leftIndex - 1] >= array[leftIndex]) break;

                    var rightIndex = i + 1;
                    for (; rightIndex < array.Length - 1; rightIndex++)
                        if (array[rightIndex] <= array[rightIndex + 1]) break;

                    var peak = rightIndex - leftIndex + 1;
                    if (peak > longestPeak) longestPeak = peak;

                    i = rightIndex;
                }
            }

            return longestPeak;
        }
    }
}
