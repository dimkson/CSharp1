using System;

namespace MenuLib
{
    public class Menu
    {
        //Класс создает консольное меню на основе массива делегатов и запускает выбранный метод.
        public delegate void delMenu();
        private delMenu[] delMenus;

        public Menu(delMenu[] delegates)
        {
            //Конструктор принимает массив делегатов
            delMenus = delegates;
        }

        public void ChooseMenu()
        {
            //Создаем меню и запускаем выбранный метод
            int num;
            do
            {
                num = 1 ;
                Console.WriteLine($"Для выбора задания введите номер задания от 1 до {delMenus.Length}");
                foreach (delMenu del in delMenus)
                {
                    Console.WriteLine(num++ + " - " + del.Method.Name);
                }
                Console.WriteLine("Для выхода из меню нажмите 0");
                try
                {
                    bool b;
                    do
                    {
                        b = int.TryParse(Console.ReadLine(), out num);
                        if (!b) Console.WriteLine("Ошибка ввода данных, введите целое число!");
                    } while (!b);
                    delMenus[num - 1]();
                    Console.Clear();
                }
                catch (IndexOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                }
            } while (num != 0);
        }
    }

    public static class FastConsole
    {
        //Класс содержит методы для ускорения работы с консолью.
        public static void Input(string str, out int num)
        {
            Console.WriteLine(str);
            bool b;
            do
            {
                b = int.TryParse(Console.ReadLine(), out num);
                if(!b) Console.WriteLine("Ошибка ввода данных, введите целое число!");
            } while (!b);
        }
        public static void Input(string str, out double num)
        {
            Console.WriteLine(str);
            bool b;
            do
            {
                b = double.TryParse(Console.ReadLine(), out num);
                if (!b) Console.WriteLine("Ошибка ввода данных, введите вещественное число!");
            } while (!b);
        }
        public static string Input(string str)
        {
            Console.WriteLine(str);
            return Console.ReadLine();
        }
        public static void Pause()
        {
            Console.ReadLine();
        }
        public static void Print(string str, int x, int y)
        {
            Console.Clear();
            Console.SetCursorPosition(x, y);
            Console.WriteLine(str);
        }
    }
}
