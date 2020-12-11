namespace AlgorithmExercises
{
    class ArrayOfProducts
    {
        static int[] Solve(int[] array)
        {
            // O(n) time | O(n) space
            var results = new int[array.Length];

            var leftTotal = 1;
            var rightTotal = 1;

            for (var i = 0; i < array.Length; i++)
            {
                results[i] = leftTotal;
                leftTotal *= array[i];
            }

            for (var i = array.Length - 1; i >= 0; i--)
            {
                results[i] *= rightTotal;
                rightTotal *= array[i];
            }

            return results;
        }
    }
}
