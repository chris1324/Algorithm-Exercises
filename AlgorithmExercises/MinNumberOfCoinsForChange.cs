using System;

namespace AlgorithmExercises
{
    class MinNumberOfCoinsForChange
    {
        static int Solve(int n, int[] denoms)
        {
            // O(nd) time | O(n) space
            var nums = new int[n + 1];
            Array.Fill(nums, int.MaxValue);
            nums[0] = 0;

            foreach (var demon in denoms)
            {
                for (var amount = 1; amount <= n; amount++)
                {
                    if (amount < demon) continue;

                    if (nums[amount - demon] == int.MaxValue) continue;

                    nums[amount] = Math.Min(nums[amount], 1 + nums[amount - demon]);
                }
            }

            return nums[n] == int.MaxValue ? -1 : nums[n];
        }
    }
}
