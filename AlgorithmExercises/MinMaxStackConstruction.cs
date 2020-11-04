using System;
using System.Collections.Generic;

namespace AlgorithmExercises
{
    class MinMaxStackConstruction
    {
        public class MinMaxStack
        {
            private readonly Stack<int> _stack = new Stack<int>();
            private readonly Stack<int> _min = new Stack<int>();
            private readonly Stack<int> _max = new Stack<int>();

            public int Peek()
            {
                // O(i) time | O(1) space
                return _stack.Peek();
            }

            public int Pop()
            {
                // O(i) time | O(1) space
                _min.Pop();
                _max.Pop();

                return _stack.Pop();
            }

            public void Push(int number)
            {
                // O(i) time | O(1) space
                _stack.Push(number);

                var min = Math.Min(GetMin(), number);
                var max = Math.Max(GetMax(), number);

                _min.Push(min);
                _max.Push(max);
            }

            public int GetMin()
            {
                // O(i) time | O(1) space
                return _min.Count > 0 ? _min.Peek() : int.MaxValue;
            }

            public int GetMax()
            {
                // O(i) time | O(1) space
                return _max.Count > 0 ? _max.Peek() : int.MinValue;
            }
        }
    }
}
