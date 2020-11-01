using System;
using System.Collections.Generic;

namespace AlgorithmExercises
{
    class MinHeightBST
    {
        public static BST Solve(List<int> array)
        {
            // O(n) time | O(n) space
            return ConstructMinHeightBST(array, 0, array.Count - 1);
        }

        public static BST ConstructMinHeightBST(List<int> array, int startIndex, int endIndex)
        {
            if (startIndex > endIndex)
            {
                return null;
            }

            var middleIndex = (startIndex + endIndex) / 2;
            var value = array[middleIndex];

            var node = new BST(value);
            node.left = ConstructMinHeightBST(array, startIndex, middleIndex - 1);
            node.right = ConstructMinHeightBST(array, middleIndex + 1, endIndex);

            return node;
        }

        public class BST
        {
            public int value;
            public BST left;
            public BST right;

            public BST(int value)
            {
                this.value = value;
                left = null;
                right = null;
            }

            public void insert(int value)
            {
                if (value < this.value)
                {
                    if (left == null)
                    {
                        left = new BST(value);
                    }
                    else
                    {
                        left.insert(value);
                    }
                }
                else
                {
                    if (right == null)
                    {
                        right = new BST(value);
                    }
                    else
                    {
                        right.insert(value);
                    }
                }
            }
        }
    }
}
