using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmExercises
{
    class GroupAnagrams
    {
        static List<List<string>> Solve(List<string> words)
        {
            // O(WN log(N)) time | O(WN) space
            var results = new Dictionary<string, List<string>>();

            foreach (var word in words)
            {
                var sortedWord = string.Concat(word.OrderBy(x => x));

                if (results.ContainsKey(sortedWord))
                {
                    var group = results[sortedWord];
                    group.Add(word);
                }
                else
                {
                    var group = new List<string> { word };
                    results[sortedWord] = group;
                }
            }

            return results.Select(x => x.Value).ToList();
        }
    }
}
