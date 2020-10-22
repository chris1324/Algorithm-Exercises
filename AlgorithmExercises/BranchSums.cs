using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmExercises
{
    class BranchSums
    {
        public class BinaryTree
        {
            public int value;
            public BinaryTree left;
            public BinaryTree right;

            public BinaryTree(int value)
            {
                this.value = value;
                this.left = null;
                this.right = null;
            }
        }

        public static List<int> Solve(BinaryTree root)
        {
            // O(n) time | O(n) space
            return CalculateBranchSum(root, 0);
        }

        private static List<int> CalculateBranchSum(BinaryTree node, int currentSum)
        {
            currentSum += node.value;

            var results = new List<int> { };
            var isLeaf = node.left == null && node.right == null;

            if (isLeaf)
            {
                results.Add(currentSum);
            }
            else
            {
                if (node.left != null) results = results.Concat(CalculateBranchSum(node.left, currentSum)).ToList();
                if (node.right != null) results = results.Concat(CalculateBranchSum(node.right, currentSum)).ToList();
            }

            return results;
        }
    }
}
