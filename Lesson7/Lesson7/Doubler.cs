using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson7
{
    class Doubler
    {
        public int Current { get; private set; }
        public int Max { get; private set; }
        public int Count { get; private set; }
        public int MinimumStep { get; private set; }
        Stack<int> stack = new Stack<int>();

        public Doubler()
        {
            Current = 1;
            Count = 0;
            Max = new Random().Next(10, 100);
            MinimumStep = MinStep();
        }

        public int MinStep()
        {
            int max = Max;
            int step = 0;

            while (max != 1)
            {
                if (max % 2 != 0)
                {
                    max--;
                    step++;
                }
                else
                {
                    max /= 2;
                    step++;
                }
            }
            return step;
        }

        public void Plus()
        {
            stack.Push(Current);
            Current++;
            Count++;
        }
        public void Multi()
        {
            stack.Push(Current);
            Current *= 2;
            Count++;
        }
        public void Reset()
        {
            stack.Clear();
            Current = 1;
            Count = 0;
        }
        public void Cancel()
        {
            if (stack.Count != 0)
            {
                Current = stack.Pop();
                Count--;
            }
        }

    }
}
