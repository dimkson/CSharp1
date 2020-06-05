namespace Lesson8
{
    class Game
    {
        //Класс описывающий текущий номер вопроса, набранные очки и максимальное значение
        private int count;
        private int current;
        private readonly int maxCount;
        private bool finish;

        public bool Finish
        {
            get { return finish; }
        }
        public int Current
        {
            get { return current; }
        }
        public int Count
        {
            get { return count; }
        }

        public Game(int max)
        {
            maxCount = max;
            count = 0;
            current = 0;
            finish = false;
        }
        public void Increase()
        {
            count++;
            Step();
        }
        public void Step()
        {
            current++;
            if (current == maxCount) finish = true;
        }
    }
}
