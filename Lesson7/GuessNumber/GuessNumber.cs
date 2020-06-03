using System;

namespace Lesson7
{
    class GuessNumber
    {
        public int RightNumber { get; private set; }
        public int Count { get; private set; }

        public GuessNumber()
        {
            RightNumber = new Random().Next(1, 100);
            Count = 0;
        }
        public bool Guess(int x)
        {
            Count++;
            return x == RightNumber;
        }
        public bool LessMore(int x)
        {
            return x > RightNumber;
        }

        public int MaxCount
        {
            get
            {
                return (int)Math.Log(RightNumber, 2) + 1; 
            }
        }
    }

}
