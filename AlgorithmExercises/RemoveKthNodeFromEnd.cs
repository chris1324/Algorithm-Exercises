using System;
using System.Collections.Generic;

namespace AlgorithmExercises
{
    class RemoveKthNodeFromEnd
    {
        public static void QuickTest()
        {
            TestLinkedList test = new TestLinkedList(0);
            test.addMany(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
            int[] expected = { 0, 1, 2, 3, 4, 5, 7, 8, 9 };
            Solve(test, 10);
            Console.WriteLine(compare(test.getNodesInArray(), expected));
        }

        public static bool compare(List<int> arr1, int[] arr2)
        {
            if (arr1.Count != arr2.Length)
            {
                return false;
            }
            for (int i = 0; i < arr1.Count; i++)
            {
                if (arr1[i] != arr2[i])
                {
                    return false;
                }
            }
            return true;
        }

        public class TestLinkedList : LinkedList
        {

            public TestLinkedList(int value) : base(value)
            {
            }

            public void addMany(int[] values)
            {
                LinkedList current = this;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                foreach (int value in values)
                {
                    current.Next = new LinkedList(value);
                    current = current.Next;
                }
            }

            public List<int> getNodesInArray()
            {
                List<int> nodes = new List<int>();
                LinkedList current = this;
                while (current != null)
                {
                    nodes.Add(current.Value);
                    current = current.Next;
                }
                return nodes;
            }
        }

        static void Solve(LinkedList head, int k)
        {
            // O(n) time | O(1) space
            var first = head;
            var second = head;

            for (var i = 0; i < k; i++) second = second.Next;

            if (second == null)
            {
                head.Value = head.Next.Value;
                head.Next = head.Next.Next;
                return;
            }

            while (second.Next != null)
            {
                first = first.Next;
                second = second.Next;
            }

            first.Next = first.Next.Next;
        }

        public class LinkedList
        {
            public int Value;
            public LinkedList Next = null;

            public LinkedList(int value)
            {
                this.Value = value;
            }
        }
    }
}
