using System.Collections.Generic;

namespace AlgorithmExercises
{
    class NodeDepths
    {
        public class BinaryTree
        {
            public int value;
            public BinaryTree left;
            public BinaryTree right;

            public BinaryTree(int value)
            {
                this.value = value;
                left = null;
                right = null;
            }
        }

        private class BinaryTreeLevel
        {
            // Custom class for solution A
            public BinaryTree Node { get; set; }
            public int Level { get; set; }
        }

        public static int SolveA(BinaryTree root)
        {
            // O(n) time | O(h) space - where n is the number of nodes in the Binary Tree and h is the height of the Binary Tree
            // Iterative approach
            var stack = new Stack<BinaryTreeLevel>() { };
            stack.Push(new BinaryTreeLevel { Node = root, Level = 0 });

            var depthSum = 0;

            while (stack.Count > 0)
            {
                var curent = stack.Pop();

                depthSum += curent.Level;

                if (curent.Node.left != null) stack.Push(new BinaryTreeLevel { Node = curent.Node.left, Level = curent.Level + 1 });
                if (curent.Node.right != null) stack.Push(new BinaryTreeLevel { Node = curent.Node.right, Level = curent.Level + 1 });
            }

            return depthSum;
        }

        public static int SolveB(BinaryTree root)
        {
            // O(n) time | O(h) space - where n is the number of nodes in the Binary Tree and h is the height of the Binary Tree
            // Recursive approach
            return GetDepth(root, 0);
        }

        private static int GetDepth(BinaryTree node, int depth)
        {
            var leftChildDepth = 0;
            var rightChildDepth = 0;

            if (node.left != null) leftChildDepth = GetDepth(node.left, depth + 1);
            if (node.right != null) rightChildDepth = GetDepth(node.right, depth + 1);

            return depth + leftChildDepth + rightChildDepth;
        }
    }
}
