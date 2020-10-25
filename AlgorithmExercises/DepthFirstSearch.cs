using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmExercises
{
    class DepthFirstSearch
    {
        public class Node
        {
            public string name;
            public List<Node> children = new List<Node>();

            public Node(string name)
            {
                this.name = name;
            }

            public List<string> DepthFirstSearch(List<string> array)
            {
                // O(v + e) time | O (v) space - where v is the number of vertices of the input graph and e is the number of edges of the input graph
                array.Add(this.name);

                foreach (var child in children)
                {
                    child.DepthFirstSearch(array);
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
