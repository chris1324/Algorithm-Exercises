using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace AlgorithmExercises
{
    class RiverSizes
    {
        public static void QuickTest()
        {
            int[,] input = {
            {1, 0, 0, 1, 0},
            {1, 0, 1, 0, 0},
            {0, 0, 1, 0, 1},
            {1, 0, 1, 0, 1},
            {1, 0, 1, 1, 0}};

            Console.WriteLine("Test Start");
            var result = Solve(input);
            Console.WriteLine("Test End");

            Console.WriteLine(JsonSerializer.Serialize(result));
        }

        public static List<int> Solve(int[,] matrix)
        {
            // O(n) time | O(n) space
            var riverSize = new List<int>();
            var rowSize = matrix.GetLength(0);
            var colSize = matrix.GetLength(1);

            var visited = new bool[rowSize, colSize];

            for (var row = 0; row < rowSize; row++)
            {
                for (var col = 0; col < colSize; col++)
                {
                    if (visited[row, col]) continue;

                    ExploreNode(row, col, matrix, visited, riverSize);
                }
            }

            return riverSize;
        }

        static void ExploreNode(int row, int col, int[,] matrix, bool[,] visited, List<int> riverSize)
        {
            var currentRiverSize = 0;

            var nodeToExplore = new Queue<(int Row, int Col)>();
            nodeToExplore.Enqueue((row, col));


            while (nodeToExplore.Count > 0)
            {
                (row, col) = nodeToExplore.Dequeue();

                if (visited[row, col]) continue;
                if (matrix[row, col] == 0) continue;

                currentRiverSize++;
                visited[row, col] = true;

                var unvisitedNeighbors = GetUnvisitedNeighbors(row, col, matrix, visited);

                foreach (var neighbor in unvisitedNeighbors)
                {
                    nodeToExplore.Enqueue(neighbor);
                }
            }

            if (currentRiverSize > 0)
            {
                riverSize.Add(currentRiverSize);
            }
        }

        static List<(int Row, int Col)> GetUnvisitedNeighbors(int row, int col, int[,] matrix, bool[,] visited)
        {
            var unvisitedNeighbors = new List<(int Row, int Col)>
            {
                (row - 1, col),
                (row, col - 1),
                (row + 1, col),
                (row, col + 1)
            };

            return unvisitedNeighbors.Where(x => IsValidIndex(x.Row, x.Col, matrix) && !visited[x.Row, x.Col]).ToList();
        }

        static bool IsValidIndex(int row, int col, int[,] matrix)
        {
            var rowSize = matrix.GetLength(0);
            var colSize = matrix.GetLength(1);

            if (row < 0 || row > rowSize - 1) return false;
            if (col < 0 || col > colSize - 1) return false;

            return true;
        }
    }
}
