using System;
using System.Collections.Generic;

namespace AlgorithmExercises
{
    class BalancedBrackets
    {
        public static void QuickTest()
        {
            string input = "([])(){}(())()()";
            Console.WriteLine(Solve(input));
        }

        static bool Solve(string str)
        {
            // O(n) time | O(n) space
            var maps = new Dictionary<string, string> { { "(", ")" }, { "[", "]" }, { "{", "}" } };
            var openBrackets = "([{";
            var closeBrackets = ")]}";

            var stack = new Stack<string>();

            foreach (var chr in str)
            {
                var bracket = chr.ToString();
                var isOpenBracket = openBrackets.IndexOf(bracket) != -1;
                var isCloseBracket = closeBrackets.IndexOf(bracket) != -1;

                if (isOpenBracket)
                {
                    stack.Push(bracket);
                }
                else if (isCloseBracket)
                {
                    if (stack.Count == 0) return false;

                    var lastBracket = stack.Pop();
                    var isLastBracketOpen = openBrackets.IndexOf(lastBracket) != -1;

                    if (!isLastBracketOpen) return false;

                    var closeBracket = maps[lastBracket];
                    if (closeBracket != bracket) return false;
                }
            }

            return stack.Count == 0;
        }
    }
}
