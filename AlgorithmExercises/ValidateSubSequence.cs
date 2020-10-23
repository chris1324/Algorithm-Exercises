using System;
using System.Collections.Generic;

namespace AlgorithmExercises
{
    class ValidateSubSequence
    {
        public static void QuickTest()
        {
            List<int> array = new List<int> { 5, 1, 22, 25, 6, -1, 8, 10 };
            List<int> sequence = new List<int> { 5, 1, 22, 23, 6, -1, 8, 10 };

            Console.WriteLine(SolveA(array, sequence));
        }

        public static bool SolveA(List<int> array, List<int> sequence)
        {
            // O(n) time | O(1) space
            var seqIndex = 0;

            for (var i = 0; i < array.Count; i++)
            {
                var arrayNum = array[i];
                var seqNum = sequence[seqIndex];

                if (arrayNum == seqNum)
                {
                    seqIndex++;

                    if (seqIndex == sequence.Count)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public static bool SolveB(List<int> array, List<int> sequence)
        {
            // O(n) time | O(1) space
            var arrayIndex = 0;
            var seqIndex = 0;

            while (arrayIndex < array.Count && seqIndex < sequence.Count)
            {
                if (array[arrayIndex] == sequence[seqIndex])
                {
                    seqIndex++;
                }

                arrayIndex++;
            }

            return seqIndex == sequence.Count;
        }
    }
}
