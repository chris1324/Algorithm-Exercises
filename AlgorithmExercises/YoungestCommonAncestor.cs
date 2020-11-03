using System;
using System.Collections.Generic;

namespace AlgorithmExercises
{
    class YoungestCommonAncestor
    {
        public static void QuickTest()
        {
            var trees = new Dictionary<char, AncestralTree>();
            var alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            foreach (char a in alphabet)
            {
                trees.Add(a, new AncestralTree(a));
            }

            trees['A'].AddAsAncestor(new AncestralTree[] { trees['B'], trees['C'] });
            trees['B'].AddAsAncestor(new AncestralTree[] { trees['D'], trees['E'] });
            trees['D'].AddAsAncestor(new AncestralTree[] { trees['H'], trees['I'] });
            trees['C'].AddAsAncestor(new AncestralTree[] { trees['F'], trees['G'] });

            var result = Solve(trees['A'], trees['E'], trees['I']);

            Console.WriteLine(result.name);
        }

        public static AncestralTree Solve(
            AncestralTree topAncestor,
            AncestralTree descendantOne,
            AncestralTree descendantTwo)
        {
            // O(d) time | O(1) space where d is the depth of the ancestral tree
            var descendantOneDepth = GetDepth(topAncestor, descendantOne);
            var descendantTwoDepth = GetDepth(topAncestor, descendantTwo);

            var different = Math.Abs(descendantOneDepth - descendantTwoDepth);

            if (descendantOneDepth > descendantTwoDepth)
            {
                for (var i = 0; i < different; i++) descendantOne = descendantOne.ancestor;
            }
            else if (descendantOneDepth < descendantTwoDepth)
            {
                for (var i = 0; i < different; i++) descendantTwo = descendantTwo.ancestor;
            }

            while (descendantOne.name != descendantTwo.name)
            {
                descendantOne = descendantOne.ancestor;
                descendantTwo = descendantTwo.ancestor;
            }

            if (descendantOne.name == descendantTwo.name) return descendantOne;
            else return topAncestor;
        }

        private static int GetDepth(AncestralTree topAncestor, AncestralTree descendant)
        {
            var depth = 0;

            while (topAncestor.name != descendant.name)
            {
                descendant = descendant.ancestor;
                depth++;
            }

            return depth;
        }

        public class AncestralTree
        {
            public char name;
            public AncestralTree ancestor;

            public AncestralTree(char name)
            {
                this.name = name;
                this.ancestor = null;
            }

            // This method is for testing only.
            public void AddAsAncestor(AncestralTree[] descendants)
            {
                foreach (AncestralTree descendant in descendants)
                {
                    descendant.ancestor = this;
                }
            }
        }
    }
}
