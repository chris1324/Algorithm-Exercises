using System;

namespace AlgorithmExercises
{
    class ValidateBST
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

            public bool Validate(int min, int max)
            {
                // O(n) time | O(d) space - where n is the number of nodes in the BST and d is the depth (height) of the BST
                if (value < min || value >= max)
                {
                    return false;
                }

                if (left != null && !left.Validate(min, value))
                {
                    return false;
                }

                if (right != null && !right.Validate(value, max))
                {
                    return false;
                }

                return true;
            }
        }

        static bool Solve(BST tree)
        {
            return tree.Validate(int.MinValue, int.MaxValue);
        }
    }
}
