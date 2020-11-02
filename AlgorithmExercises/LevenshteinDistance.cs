using System;
using System.Text.Json;

namespace AlgorithmExercises
{
    class LevenshteinDistance
    {
        public static void QuickTest()
        {
            Console.WriteLine(SolveB("abc", "yabcx"));
        }

        static int SolveA(string str1, string str2)
        {
            // O(nm) time | O(nm) space
            var edits = new int[str1.Length + 1, str2.Length + 1];

            for (var row = 0; row < edits.GetLength(0); row++) edits[row, 0] = row;
            for (var col = 0; col < edits.GetLength(1); col++) edits[0, col] = col;

            for (var row = 1; row < edits.GetLength(0); row++)
            {
                for (var col = 1; col < edits.GetLength(1); col++)
                {
                    if (str1[row - 1] == str2[col - 1])
                    {
                        edits[row, col] = edits[row - 1, col - 1];
                    }
                    else
                    {
                        edits[row, col] = Math.Min(Math.Min(edits[row - 1, col], edits[row, col - 1]), edits[row - 1, col - 1]) + 1;
                    }
                }
            }

            return edits[edits.GetLength(0) - 1, edits.GetLength(1) - 1];
        }

        static int SolveB(string str1, string str2)
        {
            // O(nm) time | O(min(n,m)) space
            var smallStr = str1.Length <= str2.Length ? str1 : str2;
            var bigStr = str1.Length > str2.Length ? str1 : str2;

            var evenEdit = new int[smallStr.Length + 1];
            var oddEdit = new int[smallStr.Length + 1];

            for (var i = 0; i < evenEdit.Length; i++) evenEdit[i] = i;

            for (var i = 1; i < bigStr.Length + 1; i++)
            {
                int[] currentRow = i % 2 == 0 ? evenEdit : oddEdit;
                int[] previousRow = i % 2 == 0 ? oddEdit : evenEdit;

                currentRow[0] = i;

                for (var j = 1; j < smallStr.Length + 1; j++)
                {
                    if (smallStr[j - 1] == bigStr[i - 1])
                    {
                        currentRow[j] = previousRow[j - 1];
                    }
                    else
                    {
                        currentRow[j] = Math.Min(Math.Min(previousRow[j], previousRow[j - 1]), currentRow[j - 1]) + 1;
                    }
                }
            }

            return (bigStr.Length) % 2 == 0 ? evenEdit[evenEdit.Length - 1] : oddEdit[oddEdit.Length - 1];
        }

        static void Print2DArray(int[,] edits)
        {
            for (var i = 0; i < edits.GetLength(0); i++)
            {
                for (var j = 0; j < edits.GetLength(1); j++) Console.Write(edits[i, j]);
                Console.WriteLine();
            }

            Console.WriteLine();
        }
    }
}
