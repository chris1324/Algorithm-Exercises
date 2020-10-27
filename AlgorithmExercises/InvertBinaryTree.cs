using System;

namespace AlgorithmExercises
{
    class InvertBinaryTree
    {
        public static void Solve(BinaryTree tree)
        {
            // O(n) time | O(d) space - where n is the number of nodes and d is th depth (height)
            tree.InvertTree();
        }

        public class BinaryTree
        {
            public int value;
            public BinaryTree left;
            public BinaryTree right;

            public BinaryTree(int value)
            {
                this.value = value;
            }

            public void InvertTree()
            {
                var leftBinaryTree = left;
                left = right;
                right = leftBinaryTree;

                if (left != null) left.InvertTree();
                if (right != null) right.InvertTree();
            }
        }
    }
}
