using System;
using System.Collections.Generic;

namespace AlgorithmExercises
{
    class MoveElementToEnd
    {
        static List<int> Solve(List<int> array, int toMove)
        {
            // O(n) time | O(1) space
            var i = 0;
            var j = array.Count - 1;

            while (i < j)
            {
                if (array[j] == toMove)
                {
                    j--;
                    continue;
                }

                if (array[i] == toMove)
                {
                    Swap(array, i, j);
                }

                i++;
            }

            return array;
        }

        private static void Swap(List<int> array, int indexA, int indexB)
        {
            var indexAValue = array[indexA];
            array[indexA] = array[indexB];
            array[indexB] = indexAValue;
        }
    }
}
