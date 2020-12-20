namespace AlgorithmExercises
{
    class IndexEqualsValue
    {
        public static int Solve(int[] array)
        {
            var result = SolveAHelper(array, 0, array.Length - 1);

            while (result > 0 && array[result - 1] == result - 1)
            {
                result = SolveAHelper(array, 0, result - 1);
            }

            return result;
        }

        public static int SolveAHelper(int[] array, int left, int right)
        {
            // O(n) time | O(Log(n)) space
            // Using recursive approach
            if (left > right)
            {
                return -1;
            }

            var middle = (left + right) / 2;
            var middleValue = array[middle];

            if (middleValue == middle)
            {
                return middle;
            }
            else if (middleValue > middle)
            {
                return SolveAHelper(array, left, middle - 1);
            }
            else
            {
                return SolveAHelper(array, middle + 1, right);
            }
        }

        public static int SolveBHelper(int[] array, int left, int right)
        {
            // O(n) time | O(1) space
            // Using iterative approach
            while (left <= right)
            {
                var middle = (left + right) / 2;
                var middleValue = array[middle];

                if (middleValue == middle)
                {
                    return middle;
                }
                else if (middleValue > middle)
                {
                    right = middle - 1;
                }
                else
                {
                    left = middle + 1;
                }
            }

            return -1;
        }
    }
}
