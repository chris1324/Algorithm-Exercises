using System;

namespace AlgorithmExercises
{
    class SingleCycleCheck
    {
        static bool Solve(int[] array)
        {
            // O(n) time | O(1) space
            var numberOfJump = 0;
            var currentIndex = 0;

            while (numberOfJump < array.Length)
            {
                if (numberOfJump > 0 && currentIndex == 0) return false;

                numberOfJump++;
                currentIndex = GetNextIndex(currentIndex, array);
            }

            return currentIndex == 0;
        }

        private static int GetNextIndex(int currentIndex, int[] array)
        {
            var jump = array[currentIndex];
            var nextIndex = (currentIndex + jump) % array.Length;

            return nextIndex < 0 ? nextIndex + array.Length : nextIndex;
        }
    }
}
