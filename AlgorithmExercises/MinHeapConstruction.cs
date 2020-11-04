using System;
using System.Collections.Generic;
using System.Text.Json;

namespace AlgorithmExercises
{
    class MinHeapConstruction
    {
        public static void QuickTest()
        {
            var minHeap = new MinHeap(new List<int>() { 48, 12, 24, 7, 8, -5, 24, 391, 24, 56, 2, 6, 8, 41 });

            Console.WriteLine(JsonSerializer.Serialize(minHeap.heap));

            minHeap.Insert(76);
            Console.WriteLine(isMinHeapPropertySatisfied(minHeap.heap));
            Console.WriteLine(minHeap.Peek() == -5);
            Console.WriteLine(minHeap.Remove() == -5);
            Console.WriteLine(isMinHeapPropertySatisfied(minHeap.heap));
            Console.WriteLine(minHeap.Peek() == 2);
            Console.WriteLine(minHeap.Remove() == 2);
            Console.WriteLine(isMinHeapPropertySatisfied(minHeap.heap));
            Console.WriteLine(minHeap.Peek() == 6);
            minHeap.Insert(87);
            Console.WriteLine(isMinHeapPropertySatisfied(minHeap.heap));
        }

        static bool isMinHeapPropertySatisfied(List<int> array)
        {
            for (int currentIdx = 1; currentIdx < array.Count; currentIdx++)
            {
                int parentIdx = (currentIdx - 1) / 2;
                if (parentIdx < 0)
                {
                    return true;
                }
                if (array[parentIdx] > array[currentIdx])
                {
                    return false;
                }
            }

            return true;
        }

        public class MinHeap
        {
            public List<int> heap = new List<int>();

            public MinHeap(List<int> array)
            {
                heap = buildHeap(array);
            }

            public List<int> buildHeap(List<int> array)
            {
                // O(n) time | O(1) space
                var lastIndex = array.Count - 1;
                var firstParentIndex = GetParentIndex(lastIndex);

                for (var i = firstParentIndex; i >= 0; i--)
                {
                    siftDown(i, lastIndex, array);
                }

                return array;
            }

            public void siftDown(int currentIdx, int endIdx, List<int> heap)
            {
                // O(log(n)) time | O(1) space
                var childOneIndex = GetChildOneIndex(currentIdx);
                var childTwoIndex = GetChildTwoIndex(currentIdx);

                while (childOneIndex <= endIdx)
                {
                    var minIndex = GetMinIndex(childOneIndex, childTwoIndex, heap);

                    if (heap[currentIdx] > heap[minIndex])
                    {
                        Swap(currentIdx, minIndex, heap);

                        currentIdx = minIndex;
                        childOneIndex = GetChildOneIndex(currentIdx);
                        childTwoIndex = GetChildTwoIndex(currentIdx);
                    }
                    else
                    {
                        return;
                    }
                }
            }

            public void siftUp(int currentIdx, List<int> heap)
            {
                // O(log(n)) time | O(1) spaces
                var parentIndex = GetParentIndex(currentIdx);

                while (parentIndex > 0 && heap[parentIndex] > heap[currentIdx])
                {
                    Swap(parentIndex, currentIdx, heap);
                    currentIdx = parentIndex;
                    parentIndex = GetParentIndex(currentIdx);
                }
            }

            public int Peek()
            {
                // O(1) time | O(1) space
                return heap[0];
            }

            public int Remove()
            {
                // O(log(n)) time | O(1) space
                var valueToRemove = heap[0];
                var lastIndex = heap.Count - 1;

                Swap(0, lastIndex, heap);
                heap.RemoveAt(lastIndex);
                siftDown(0, lastIndex, heap);

                return valueToRemove;
            }

            public void Insert(int value)
            {
                // O(log(n)) time | O(1) space
                heap.Add(value);
                siftUp(heap.Count - 1, heap);
            }

            private static void Swap(int indexOne, int indexTwo, List<int> heap)
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

            private static int GetMinIndex(int indexOne, int indexTwo, List<int> heap)
            {
                if (indexOne > heap.Count - 1) throw new IndexOutOfRangeException();

                if (indexTwo > heap.Count - 1)
                {
                    return indexOne;
                }
                else
                {
                    return heap[indexOne] > heap[indexTwo] ? indexTwo : indexOne;
                }
            }
        }
    }
}
