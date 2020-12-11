using System;

namespace AlgorithmExercises
{
    class SearchInSortedMatrix
    {
        public static void QuickTest()
        {
            var matrix = new int[,]
            {
                {1, 4, 7, 12, 15, 1000},
                {2, 5, 19, 31, 32, 1001},
                {3, 8, 24, 33, 35, 1002},
                {40, 41, 42, 44, 45, 1003},
                {99, 100, 103, 106, 128, 1004}
            };

            var target = 44;
            var results = Solve(matrix, target);

            Console.WriteLine(results[0]);
            Console.WriteLine(results[1]);
        }

        static int[] Solve(int[,] matrix, int target)
        {
            // O(n + m) time | O(1) space
            var rowCount = matrix.GetLength(0);
            var colCount = matrix.GetLength(1);

            var rowIndex = 0;
            var colIndex = colCount - 1;

            while (rowIndex < rowCount && colIndex >= 0)
            {
                var value = matrix[rowIndex, colIndex];

                if (value > target)
                {
                    colIndex--;
                }
                else if (value < target)
                {
                    rowIndex++;
                }
                else
                {
                    return new int[] { rowIndex, colIndex };
                }
            }

            return new int[] { -1, -1 };
        }
    }
}
