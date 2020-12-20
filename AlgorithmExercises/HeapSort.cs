using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace AlgorithmExercises
{
    class HeapSort
    {
        public static void QuickTest()
        {
            var input = new List<int>() { 8, 5, 2, 9, 5, 6, 3 };
            var maxHeap = new MaxHeap(input.ToArray());
            var output = Solve(input.ToArray());

            Console.WriteLine();
            Console.WriteLine(JsonSerializer.Serialize(maxHeap.heap));
            Console.WriteLine(JsonSerializer.Serialize(output));
        }

        public static int[] Solve(int[] array)
        {
            // O(nlog(n)) time | O(1) space
            var maxHeap = new MaxHeap(array);

            for (var endIndex = array.Length - 1; endIndex > 0; endIndex--)
            {
                Swap(0, endIndex, array);
                maxHeap.siftDown(0, endIndex - 1);
            }

            return array;
        }

        private static void Swap(int indexOne, int indexTwo, int[] array)
        {
            var temp = array[indexOne];
            array[indexOne] = array[indexTwo];
            array[indexTwo] = temp;
        }

        public class MaxHeap
        {
            public int[] heap = new int[] { };

            public MaxHeap(int[] array)
            {
                heap = buildHeap(array);
            }

            public int[] buildHeap(int[] array)
            {
                // O(n) time | O(1) space
                heap = array;

                var lastIndex = array.Length - 1;
                var firstParentIndex = GetParentIndex(lastIndex);

                for (var i = firstParentIndex; i >= 0; i--)
                {
                    siftDown(i, lastIndex);
                }

                return array;
            }

            public void siftDown(int currentIdx, int endIdx)
            {
                // O(log(n)) time | O(1) space
                var childOneIndex = GetChildOneIndex(currentIdx);
                var childTwoIndex = GetChildTwoIndex(currentIdx);

                while (childOneIndex <= endIdx)
                {
                    var maxIndex = GetMaxIndex(childOneIndex, childTwoIndex, endIdx, heap);

                    if (heap[currentIdx] < heap[maxIndex])
                    {
                        Swap(currentIdx, maxIndex, heap);

                        currentIdx = maxIndex;
                        childOneIndex = GetChildOneIndex(currentIdx);
                        childTwoIndex = GetChildTwoIndex(currentIdx);
                    }
                    else
                    {
                        return;
                    }
                }
            }

            private static void Swap(int indexOne, int indexTwo, int[] heap)
            {
                var temp = heap[indexOne];
                heap[indexOne] = heap[indexTwo];
                heap[indexTwo] = temp;
            }

            private static int GetParentIndex(int index)
            {
                return (int)Math.Floor((decimal)(index - 1) / 2);
            }

            private static int GetChildOneIndex(int index)
            {
                return index * 2 + 1;
            }

            private static int GetChildTwoIndex(int index)
            {
                return GetChildOneIndex(index) + 1;
            }

            private static int GetMaxIndex(int indexOne, int indexTwo, int endIdx, int[] heap)
            {
                if (indexTwo > endIdx)
                {
                    return indexOne;
                }
                else
                {
                    return heap[indexOne] > heap[indexTwo] ? indexOne : indexTwo;
                }
            }
        }
    }
}
