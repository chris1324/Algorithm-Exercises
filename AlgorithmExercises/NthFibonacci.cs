using System;
using System.Collections.Generic;

namespace AlgorithmExercises
{
    class NthFibonacci
    {
        static int SolveA(int n)
        {
            // O(2^n) time | O(n) space
            // Recursive approach
            if (n == 2) return 1;
            else if (n == 1) return 0;
            else return SolveA(n - 1) + SolveA(n - 2);
        }

        static int SolveB(int n)
        {
            // O(n) time | O(n) space
            // Recursive approach
            var memorize = new Dictionary<int, int>();

            memorize.Add(2, 1);
            memorize.Add(1, 0);

            return SolveBHelper(n, memorize);
        }

        static int SolveBHelper(int n, Dictionary<int, int> memorize)
        {
            if (memorize.ContainsKey(n))
            {
                return memorize[n];
            }
            else
            {
                memorize.Add(n, SolveBHelper(n - 1, memorize) + SolveBHelper(n - 2, memorize));
                return memorize[n];
            }
        }

        static int SolveC(int n)
        {
            // O(n) time | O(1) space
            // Iterative approach
            var lastTwo = new int[] { 0, 1 };
            var counter = 3;

            while (counter <= n)
            {
                var nextValue = lastTwo[0] + lastTwo[1];
                lastTwo[0] = lastTwo[1];
                lastTwo[1] = nextValue;

                counter++;
            }

            return n == 1 ? lastTwo[0] : lastTwo[1];
        }
    }
}
