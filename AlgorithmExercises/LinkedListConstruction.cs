using System;
using System.Collections.Generic;

namespace AlgorithmExercises
{
    class LinkedListConstruction
    {
        public static void QuickTest()
        {
            DoublyLinkedList linkedList = new DoublyLinkedList();
            Node one = new Node(1);
            Node two = new Node(2);
            Node three = new Node(3);
            Node three2 = new Node(3);
            Node three3 = new Node(3);
            Node four = new Node(4);
            Node five = new Node(5);
            Node six = new Node(6);
            bindNodes(one, two);
            bindNodes(two, three);
            bindNodes(three, four);
            bindNodes(four, five);
            linkedList.Head = one;
            linkedList.Tail = five;

            linkedList.SetHead(four);
            Console.WriteLine(compare(getNodeValuesHeadToTail(linkedList),
              new int[] { 4, 1, 2, 3, 5 }));
            Console.WriteLine(compare(getNodeValuesTailToHead(linkedList),
              new int[] { 5, 3, 2, 1, 4 }));

            linkedList.SetTail(six);
            Console.WriteLine(compare(getNodeValuesHeadToTail(linkedList),
              new int[] { 4, 1, 2, 3, 5, 6 }));
            Console.WriteLine(compare(getNodeValuesTailToHead(linkedList),
              new int[] { 6, 5, 3, 2, 1, 4 }));

            linkedList.InsertBefore(six, three);
            Console.WriteLine(compare(getNodeValuesHeadToTail(linkedList),
              new int[] { 4, 1, 2, 5, 3, 6 }));
            Console.WriteLine(compare(getNodeValuesTailToHead(linkedList),
              new int[] { 6, 3, 5, 2, 1, 4 }));

            linkedList.InsertAfter(six, three2);
            Console.WriteLine(compare(getNodeValuesHeadToTail(linkedList),
              new int[] { 4, 1, 2, 5, 3, 6, 3 }));
            Console.WriteLine(compare(getNodeValuesTailToHead(linkedList),
              new int[] { 3, 6, 3, 5, 2, 1, 4 }));

            linkedList.InsertAtPosition(1, three3);
            Console.WriteLine(compare(getNodeValuesHeadToTail(linkedList),
              new int[] { 3, 4, 1, 2, 5, 3, 6, 3 }));
            Console.WriteLine(compare(getNodeValuesTailToHead(linkedList),
              new int[] { 3, 6, 3, 5, 2, 1, 4, 3 }));;

            linkedList.RemoveNodesWithValue(3);
            Console.WriteLine(compare(getNodeValuesHeadToTail(linkedList),
              new int[] { 4, 1, 2, 5, 6 }));
            Console.WriteLine(compare(getNodeValuesTailToHead(linkedList),
              new int[] { 6, 5, 2, 1, 4 }));

            linkedList.Remove(two);
            Console.WriteLine(compare(getNodeValuesHeadToTail(
                  linkedList), new int[] { 4, 1, 5, 6 }));
            Console.WriteLine(compare(getNodeValuesTailToHead(
                  linkedList), new int[] { 6, 5, 1, 4 }));

            Console.WriteLine(linkedList.ContainsNodeWithValue(5));
        }

        private static List<int> getNodeValuesHeadToTail(DoublyLinkedList linkedList)
        {
            List<int> values = new List<int>();
            Node node = linkedList.Head;
            while (node != null)
            {
                values.Add(node.Value);
                node = node.Next;
            }
            return values;
        }

        private static List<int> getNodeValuesTailToHead(DoublyLinkedList linkedList)
        {
            List<int> values = new List<int>();
            Node node = linkedList.Tail;
            while (node != null)
            {
                values.Add(node.Value);
                node = node.Prev;
            }
            return values;
        }

        private static void bindNodes(Node nodeOne, Node nodeTwo)
        {
            nodeOne.Next = nodeTwo;
            nodeTwo.Prev = nodeOne;
        }

        private static bool compare(List<int> array1, int[] array2)
        {
            if (array1.Count != array2.Length)
            {
                return false;
            }
            for (int i = 0; i < array1.Count; i++)
            {
                if (array1[i] != array2[i])
                {
                    return false;
                }
            }
            return true;
        }

        public class DoublyLinkedList
        {
            public Node Head;
            public Node Tail;

            public void SetHead(Node node)
            {
                // O(1) time | O(1) space
                if (Head == null)
                {
                    Head = node;
                    Tail = node;
                }
                else
                {
                    InsertBefore(Head, node);
                }
            }

            public void SetTail(Node node)
            {
                // O(1) time | O(1) space
                if (Tail == null)
                {
                    Head = node;
                    Tail = node;
                }
                else
                {
                    InsertAfter(Tail, node);
                }
            }

            public void InsertBefore(Node node, Node nodeToInsert)
            {
                // O(1) time | O(1) space
                if (nodeToInsert == Head && nodeToInsert == Tail) return;

                Remove(nodeToInsert);
                SetNodeBinding(node.Prev, nodeToInsert, node);
            }

            public void InsertAfter(Node node, Node nodeToInsert)
            {
                // O(1) time | O(1) space
                if (nodeToInsert == Head && nodeToInsert == Tail) return;

                Remove(nodeToInsert);
                SetNodeBinding(node, nodeToInsert, node.Next);
            }

            public void InsertAtPosition(int position, Node nodeToInsert)
            {
                // O(p) time | O(1) space
                if (position == 1)
                {
                    SetHead(nodeToInsert);
                    return;
                }

                var currentPosition = 1;
                var node = Head;

                while (currentPosition != position && node != null)
                {
                    node = node.Next;
                    currentPosition++;
                }

                if (node != null)
                {
                    InsertBefore(node, nodeToInsert);
                }
                else
                {
                    SetTail(nodeToInsert);
                }
            }

            public void RemoveNodesWithValue(int value)
            {
                //O(n) time | O(1) space
                var current = Head;

                while (current != null)
                {
                    var next = current.Next;

                    if (current.Value == value)
                    {
                        Remove(current);
                    }

                    current = next;
                }
            }

            public void Remove(Node node)
            {
                // O(1) time | O(1) space
                if (Head == node) Head = Head.Next;
                if (Tail == node) Tail = Tail.Prev;

                RemoveNodeBinding(node);
            }

            public bool ContainsNodeWithValue(int value)
            {
                // O(n) time | O(1) space
                var current = Head;

                while (current != null)
                {
                    if (current.Value == value) return true;
                    else current = current.Next;
                }

                return false;
            }

            private void RemoveNodeBinding(Node node)
            {
                var previous = node.Prev;
                var next = node.Next;

                if (previous != null) previous.Next = next;
                if (next != null) next.Prev = previous;

                node.Prev = null;
                node.Next = null;
            }

            private void SetNodeBinding(Node previousNode, Node nodeToSet, Node nextNode)
            {
                if (previousNode != null)
                {
                    previousNode.Next = nodeToSet;
                }
                else
                {
                    Head = nodeToSet;
                }

                if (nextNode != null)
                {
                    nextNode.Prev = nodeToSet;
                }
                else
                {
                    Tail = nodeToSet;
                }

                nodeToSet.Prev = previousNode;
                nodeToSet.Next = nextNode;
            }
        }

        public class Node
        {
            public int Value;
            public Node Prev;
            public Node Next;

            public Node(int value)
            {
                this.Value = value;
            }
        }
    }
}
