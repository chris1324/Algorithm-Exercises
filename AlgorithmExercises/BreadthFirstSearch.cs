using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmExercises
{
    class BreadthFirstSearch
    {
        public class Node
        {
            public string name;
            public List<Node> children = new List<Node>();

            public Node(string name)
            {
                this.name = name;
            }

            public List<string> BreadthFirstSearch(List<string> array)
            {
                // O(v + e) time | O(v) space - where v is the number of vertices and e is the number of edges
                var queue = new Queue<Node>();
                queue.Enqueue(this);

                while (queue.Count > 0)
                {
                    var node = queue.Dequeue();
                    array.Add(node.name);

                    node.children.ForEach(x => queue.Enqueue(x));
                }

                return array;
            }

            public Node AddChild(string name)
            {
                Node child = new Node(name);
                children.Add(child);
                return this;
            }
        }
    }
}
