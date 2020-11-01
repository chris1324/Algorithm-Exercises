namespace AlgorithmExercises
{
    class BSTConstruction
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

            public BST Insert(int value)
            {
                // Average O(log(n)) time | O(1) space
                // Worst O(n) time | O(1) space

                var currentNode = this;

                while (true)
                {
                    if (value < currentNode.value)
                    {
                        if (currentNode.left != null) currentNode = currentNode.left;
                        else
                        {
                            currentNode.left = new BST(value);
                            break;
                        }
                    }
                    else if (value >= currentNode.value)
                    {
                        if (currentNode.right != null) currentNode = currentNode.right;
                        else
                        {
                            currentNode.right = new BST(value);
                            break;
                        }
                    }
                }

                return this;
            }

            public bool Contains(int value)
            {
                // Average O(log(n)) time | O(1) space
                // Worst O(n) time | O(1) space

                var currentNode = this;

                while (currentNode != null)
                {
                    if (value < currentNode.value)
                    {
                        currentNode = currentNode.left;
                    }
                    else if (value > currentNode.value)
                    {
                        currentNode = currentNode.right;
                    }
                    else
                    {
                        return true;
                    }
                }

                return false;
            }

            public BST Remove(int value, BST parentNode = null)
            {
                // Average O(log(n)) time | O(1) space
                // Worst O(n) time | O(1) space

                var currentNode = this;

                while (currentNode != null)
                {
                    if (value < currentNode.value)
                    {
                        parentNode = currentNode;
                        currentNode = currentNode.left;
                    }
                    else if (value > currentNode.value)
                    {
                        parentNode = currentNode;
                        currentNode = currentNode.right;
                    }
                    else
                    {
                        var hasLeft = currentNode.left != null;
                        var hasRight = currentNode.right != null;

                        if (hasLeft && hasRight)
                        {
                            var minValue = currentNode.right.GetMinValue();
                            currentNode.value = minValue;
                            currentNode.right.Remove(minValue, currentNode);
                        }
                        else if (parentNode == null)
                        {
                            if (hasLeft)
                            {
                                var nodeToReplace = currentNode.left;
                                currentNode.value = nodeToReplace.value;
                                currentNode.left = nodeToReplace.left;
                                currentNode.right = nodeToReplace.right;
                            }
                            else if (hasRight)
                            {
                                var nodeToReplace = currentNode.right;
                                currentNode.value = nodeToReplace.value;
                                currentNode.right = nodeToReplace.right;
                                currentNode.left = nodeToReplace.left;
                            }
                            else
                            {
                                // Single node tree : do nothing
                            }
                        }
                        else if (parentNode.left == currentNode)
                        {
                            parentNode.left = hasLeft ? currentNode.left : currentNode.right;
                        }
                        else if (parentNode.right == currentNode)
                        {
                            parentNode.right = hasLeft ? currentNode.left : currentNode.right;
                        }

                        break;
                    }
                }

                return this;
            }

            private int GetMinValue()
            {
                var currentNode = this;

                while (true)
                {
                    if (currentNode.left != null) currentNode = currentNode.left;
                    else break;
                }

                return currentNode.value;
            }
        }
    }
}
