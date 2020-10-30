using System;

namespace AlgorithmExercises
{
    class FindClosetValueInBST
    {
        public class BST
        {
            public int value;
            public BST left;
            public BST right;

            public BST(int value)
            {
                this.value = value;
            }

            public int FindClosetValue(int target, int closest)
            {
                // Average : O(log(n)) time | O(log(n)) space
                // Worst : O(n) time | O(n) space
                // Recursive approach
                if (Math.Abs(value - target) < Math.Abs(closest - target))
                {
                    closest = value;
                }

                if (target < value && left != null)
                {
                    return left.FindClosetValue(target, closest);
                }
                else if (target > value && right != null)
                {
                    return right.FindClosetValue(target, closest);
                }
                else
                {
                    return closest;
                }
            }

            public int FindClosetValue(int target)
            {
                // Average : O(log(n)) time | O(1) space
                // Worst : O(n) time | O(1) space
                // Iterative approach
                var currentNode = this;
                var closest = value;

                while (currentNode != null)
                {
                    if (Math.Abs(currentNode.value - target) < Math.Abs(closest - target))
                    {
                        closest = currentNode.value;
                    }

                    if (target < currentNode.value)
                    {
                        currentNode = currentNode.left;
                    }
                    else if (target > currentNode.value)
                    {
                        currentNode = currentNode.right;
                    }
                    else
                    {
                        break;
                    }
                }

                return closest;
            }
        }

        static int Solve(BST tree, int target)
        {
            return tree.FindClosetValue(target, tree.value);
        }
    }
}
