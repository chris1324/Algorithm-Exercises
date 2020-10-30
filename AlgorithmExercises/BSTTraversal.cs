using System;
using System.Collections.Generic;

namespace AlgorithmExercises
{
    class BSTTraversal
    {
        public static List<int> InOrderTraverse(BST tree, List<int> array)
        {
            // O(n) time | O(n) space
            tree.InOrderTraverse(array);

            return array;
        }

        public static List<int> PreOrderTraverse(BST tree, List<int> array)
        {
            // O(n) time | O(n) space
            tree.PreOrderTraverse(array);

            return array;

        }

        public static List<int> PostOrderTraverse(BST tree, List<int> array)
        {
            // O(n) time | O(n) space
            tree.PostOrderTraverse(array);

            return array;
        }

        public class BST
        {
            public int value;
            public BST left;
            public BST right;

            public BST(int value)
            {
                this.value = value;
            }

            public void InOrderTraverse(List<int> array)
            {
                if (left != null) left.InOrderTraverse(array);
                array.Add(value);
                if (right != null) right.InOrderTraverse(array);
            }

            public void PreOrderTraverse(List<int> array)
            {
                array.Add(value);
                if (left != null) left.PreOrderTraverse(array);
                if (right != null) right.PreOrderTraverse(array);
            }

            public void PostOrderTraverse(List<int> array)
            {
                if (left != null) left.PostOrderTraverse(array);
                if (right != null) right.PostOrderTraverse(array);
                array.Add(value);
            }
        }
    }
}
