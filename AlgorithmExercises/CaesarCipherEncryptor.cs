using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmExercises
{
    class CaesarCipherEncryptor
    {
        public static void QuickTest()
        {
            var input = "xyz";
            var key = 2;

            Console.WriteLine(SolveB(input, key));
        }

        public static string SolveA(string str, int key)
        {
            // O(n) time | O(n) space
            var strBuilder = new StringBuilder(str.Length);

            byte[] strCodes = Encoding.ASCII.GetBytes(str);

            foreach (var strCode in strCodes)
            {
                var newStrCode = IncrementStringA(strCode, key);
                strBuilder.Append(char.ConvertFromUtf32(newStrCode));
            }

            return strBuilder.ToString();
        }

        private static int IncrementStringA(int strCode, int increment)
        {
            var result = strCode + (increment % 26);

            return result <= 122
                ? result
                : (96 + result) % 122;
        }

        public static string SolveB(string str, int key)
        {
            // O(n) time | O(n) space
            var strBuilder = new StringBuilder(str.Length);

            foreach (var chr in str)
            {
                var newChar = IncrementStringB(chr, key);
                strBuilder.Append(newChar);
            }

            return strBuilder.ToString();
        }
        private static char IncrementStringB(char chr, int increment)
        {
            var alphabet = "abcdefghijklmnopqrstuvwxyz";
            var result = alphabet.IndexOf(chr) + (increment % 26);

            return alphabet[result % 26];
        }
    }
}
