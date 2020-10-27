using System;
using System.Collections.Generic;

namespace AlgorithmExercises
{
    class ProductSum
    {
        public static int Solve(List<object> array)
        {
            // O(n) time | O(d) space - where n is the total number of elements in the array (including sub-elements), 
            // d is the greatest depth of "special" arrays in the array
            return Solve(array, 1);
        }

        public static int Solve(List<object> array, int level)
        {
            var sum = 0;

            foreach (var item in array)
            {
                if (item is int) sum += (int)item;
                else sum += Solve(item as List<object>, level + 1);
            }

            return sum * level;
        }
    }
}
