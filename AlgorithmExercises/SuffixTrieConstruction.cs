using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmExercises
{
    class SuffixTrieConstruction
    {
        public static void QuickTest()
        {
            var trie = new SuffixTrie("babc");
        }

        public class TrieNode
        {
            public Dictionary<char, TrieNode> Children = new Dictionary<char, TrieNode>();
        }

        public class SuffixTrie
        {
            public TrieNode root = new TrieNode();
            public char endSymbol = '*';

            public SuffixTrie(string str)
            {
                PopulateSuffixTrieFrom(str);
            }

            public void PopulateSuffixTrieFrom(string str)
            {
                // O(n^2) time | O(n^2) space
                for (var i = 0; i < str.Length; i++)
                {
                    var curNode = root;

                    for (var j = i; j < str.Length; j++)
                    {
                        var letter = str[j];

                        if (curNode.Children.ContainsKey(letter))
                        {
                            curNode = curNode.Children[letter];
                        }
                        else
                        {
                            var node = new TrieNode();
                            curNode.Children.Add(letter, node);
                            curNode = node;
                        }
                    }

                    curNode.Children[endSymbol] = null;
                }
            }

            public bool Contains(string str)
            {
                // O(n) time | O(1) space
                var curNode = root;

                for (var i = 0; i < str.Length; i++)
                {
                    var letter = str[i];

                    if (!curNode.Children.ContainsKey(letter))
                    {
                        return false;
                    }

                    curNode = curNode.Children[letter];
                }

                return curNode.Children.ContainsKey(endSymbol);
            }
        }
    }
}
