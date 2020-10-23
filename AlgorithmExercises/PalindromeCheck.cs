using System;
using System.Text;

namespace AlgorithmExercises
{
    class PalindromeCheck
    {
        public static bool SolveA(string str)
        {
            // O(n) time | O(1) space
            // Iterative approach
            var leftIndex = 0;
            var rightIndex = str.Length - 1;

            while (leftIndex < rightIndex)
            {
                if (str[leftIndex] != str[rightIndex]) return false;

                leftIndex++;
                rightIndex--;
            }

            return true;
        }

        public static bool SolveB(string str, int i = 0)
        {
            // O(n) time | O(n) space
            // Recursive approach
            var j = str.Length - 1 - i;

            return i >= j ? true : str[i] == str[j] && SolveB(str, i + 1);
        }
    }
}
