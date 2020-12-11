using System;

namespace AlgorithmExercises
{
    class BinaryTreeDiameter
    {
        public class BinaryTree
        {
            public int value;
            public BinaryTree left;
            public BinaryTree right;

            public BinaryTree(int value)
            {
                this.value = value;
            }
        }

        public class TreeInfo
        {
            public int MaxLength { get; set; }
            public int MaxCombinedLength { get; set; }
        }

        public int Solve(BinaryTree tree)
        {
            // O(n) time | O(h) space - where n is the number of nodes and h is the height of the Binary Tree
            return GetTreeInfo(tree).MaxCombinedLength;
        }

        public TreeInfo GetTreeInfo(BinaryTree tree)
        {
            if (tree == null) return new TreeInfo { };

            var leftTreeInfo = GetTreeInfo(tree.left);
            var rightTreeInfo = GetTreeInfo(tree.right);

            var mathLength = Math.Max(leftTreeInfo.MaxLength, rightTreeInfo.MaxLength) + 1;

            var maxCombinedLength = 0;
            maxCombinedLength = Math.Max(leftTreeInfo.MaxCombinedLength, rightTreeInfo.MaxCombinedLength);
            maxCombinedLength = Math.Max(maxCombinedLength, leftTreeInfo.MaxLength + rightTreeInfo.MaxLength);

            return new TreeInfo { MaxLength = mathLength, MaxCombinedLength = maxCombinedLength };
        }
    }
}
