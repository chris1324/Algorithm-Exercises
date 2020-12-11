using System;
using System.Text;

namespace AlgorithmExercises
{
    class RunLengthEncoding
    {
        public static void QuickTest()
        {
            var input = "AAAAAAAAAAAAABBCCCCDD";

            var results = Solve(input);
            Console.WriteLine(results);

            //foreach (var result in results)
            //{
            //    Console.WriteLine($"{result.Count}{result.Alphabet}");
            //}
        }

        public static string Solve(string str)
        {
            // O(n) time | O(n) space
            var strBuilder = new StringBuilder();
            var curLength = 1;

            for (var i = 1; i < str.Length; i++)
            {
                var curAlphabet = str[i].ToString();
                var preAlphabet = str[i - 1].ToString();

                if (curAlphabet != preAlphabet || curLength == 9)
                {
                    strBuilder.Append(curLength);
                    strBuilder.Append(preAlphabet);
                    curLength = 0;
                }

                curLength++;
            }

            strBuilder.Append(curLength);
            strBuilder.Append(str[str.Length - 1]);

            return strBuilder.ToString();
        }
    }
}
