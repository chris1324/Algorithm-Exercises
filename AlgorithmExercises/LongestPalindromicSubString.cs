using System;

namespace AlgorithmExercises
{
    class LongestPalindromicSubString
    {
        public static void QuickTest()
        {
            var input = "abcdefghfedcbaa";
            var result = Solve(input);

            Console.WriteLine(result);
        }

        static string Solve(string str)
        {
            // O(n^2) time | O(n) space
            var longestPalindromic = new int[] { 0, 0 };

            for (var i = 1; i < str.Length; i++)
            {
                var oddPalindromic = GetPalindromic(str, i - 1, i + 1);
                var evenPalindromic = GetPalindromic(str, i - 1, i);

                if (GetPalindromicLength(oddPalindromic) > GetPalindromicLength(longestPalindromic)) longestPalindromic = oddPalindromic;
                if (GetPalindromicLength(evenPalindromic) > GetPalindromicLength(longestPalindromic)) longestPalindromic = evenPalindromic;
            }

            return str.Substring(longestPalindromic[0], longestPalindromic[1] - longestPalindromic[0] + 1);
        }

        private static int[] GetPalindromic(string str, int leftIndex, int rightIndex)
        {
            var hasPalindromic = false;

            while (leftIndex >= 0 && rightIndex < str.Length)
            {
                if (str[leftIndex] != str[rightIndex]) break;
                leftIndex--;
                rightIndex++;
                hasPalindromic = true;
            }

            return hasPalindromic
                ? new int[] { leftIndex + 1, rightIndex - 1 }
                : new int[] { leftIndex, leftIndex };
        }

        private static int GetPalindromicLength(int[] index)
        {
            var leftindex = index[0];
            var rightIndex = index[1];

            return rightIndex - leftindex + 1;
        }
    }
}
