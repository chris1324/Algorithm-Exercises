using System;

namespace AlgorithmExercises
{
    class NumberOfWaysToMakeChange
    {
        public static void QuickTest()
        {
            var n = 2;
            var denoms = new int[] { 1, 5 };

            Console.WriteLine(Solve(n, denoms));
        }

        static int Solve(int n, int[] denoms)
        {
            // O(nd) time | O(n) space
            var ways = new int[n + 1];
            ways[0] = 1;

            foreach (var denom in denoms)
            {
                for (int i = 1; i <= n; i++)
                {
                    if (i < denom) continue;

                    ways[i] += ways[i - denom];
                }
            }

            return ways[n];
        }
    }
}
