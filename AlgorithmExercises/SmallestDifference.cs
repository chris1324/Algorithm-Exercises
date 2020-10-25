using System;

namespace AlgorithmExercises
{
    class SmallestDifference
    {
        static int[] Solve(int[] arrayOne, int[] arrayTwo)
        {
            // O(nlog(n) + mlog(m)) time | O(1) space

            Array.Sort(arrayOne);
            Array.Sort(arrayTwo);

            var smallestDifferentPair = new int[] { };
            var smallestDifferent = int.MaxValue;

            var indexOne = 0;
            var indexTwo = 0;

            while (indexOne < arrayOne.Length && indexTwo < arrayTwo.Length)
            {
                var valueOne = arrayOne[indexOne];
                var valueTwo = arrayTwo[indexTwo];

                if (valueOne < valueTwo)
                {
                    indexOne++;
                }
                else if (valueOne > valueTwo)
                {
                    indexTwo++;
                }
                else
                {
                    return new int[] { valueOne, valueTwo };
                }

                var currentDifferent = Math.Abs(valueOne - valueTwo);

                if (currentDifferent < smallestDifferent)
                {
                    smallestDifferent = currentDifferent;
                    smallestDifferentPair = new int[] { valueOne, valueTwo };
                }
            }

            return smallestDifferentPair;
        }
    }
}
