using MenuClass;
using System;
using FC = MenuClass.FastConsole;

namespace Lesson2
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu.delMenu[] delMenus = new Menu.delMenu[] { Task1, Task2, Task3, Task4, Task5, Task6, Task7 };
            Menu menu = new Menu(delMenus);
            menu.ChooseMenu();
        }

        #region Задание1
        static void Task1()
        {
            //Найти минимальное из трех чисел
            FC.Input("Введите первое число", out int first);
            FC.Input("Введите второе число", out int second);
            FC.Input("Введите третье число", out int third);

            if (second < first) first = second;
            if (third < first) first = third;
            Console.WriteLine("Минимальное значение: " + first);
            FC.Pause();
        }
        #endregion
        #region Задание2
        static void Task2()
        {
            //Посчитать количество цифр числа
            FC.Input("Введите число", out int x);
            int s = 0;
            do
            {
                x /= 10;
                s++;
            } while (x != 0);
            Console.WriteLine("Количество цифр: " + s);
            FC.Pause();
        }
        #endregion
        #region Задание3
        static void Task3()
        {
            //Сумма нечетных положительных чисел
            int x, s = 0;
            do
            {
                FC.Input("Введите число или 0 для выхода", out x);
                if (x > 0 && x % 2 != 0) s += x;
            } while (x != 0);
            Console.WriteLine("Сумма введенных нечетных положительных чисел равна " + s);
            FC.Pause();
        }
        #endregion
        #region Задание4
        static void Task4()
        {
            //Логин пароль
            int x = 0;
            do
            {
                string login = FC.Input("Введите логин");
                string password = FC.Input("Введите пароль");
                if (IsValid(login, password))
                {
                    Console.WriteLine("Успех!");
                    FC.Pause();
                    return;
                }
                Console.WriteLine("Неверный логин или пароль");
                x++;
            } while (x != 3);
            Console.WriteLine("Access Denied");
            FC.Pause();
        }
        static bool IsValid(string login, string password)
        {
            return (login == "root" && password == "GeekBrains");
        }
        #endregion
        #region Задание5
        static void Task5()
        {
            //Индекс массы тела
            FC.Input("Введите рост в метрах", out double h);
            FC.Input("Введите вес", out double m);
            double I = m / (h * h);
            if (I < 18.5)
            {
                Console.WriteLine("Ваш вес ниже нормы!");
                Console.WriteLine("Необходимо набрать " + (18.5 * h * h - m) + " кг.");
            }
            else if (I >= 25)
            {
                Console.WriteLine("Ваш вес выше нормы!");
                Console.WriteLine("Необходимо сбросить " + (m - 25 * h * h) + " кг.");
            }
            else
                Console.WriteLine("Ваш вес в норме!");
            FC.Pause();
        }
        #endregion
        #region Задание6
        static void Task6()
        {
            //Подсчет чисел
            DateTime start = DateTime.Now;
            int s, x, good = 0;

            for(int i = 1; i < 100000000; i++)
            {
                x = i;
                s = 0;
                while (x != 0)
                {
                    s += x % 10;
                    x /= 10;
                }
                if (i % s == 0) good++;
            }
            Console.WriteLine("Количество хороших чисел равно " + good);
            Console.WriteLine("Время подсчета " + (DateTime.Now - start));
            FC.Pause();
        }
        #endregion
        #region Задание7
        static void Task7()
        {
            //Рекурсия
            FC.Input("Введите a", out int a);
            FC.Input("Введите b", out int b);
            Console.Write(a);
            RecurPrint(a + 1, b);
            Console.WriteLine();
            Console.WriteLine(RecurSum(a, b));
            FC.Pause();
        }
        static void RecurPrint(int a, int b)
        {
            Console.Write(", " + a);
            if (a < b) RecurPrint(++a, b);
        }
        static int RecurSum(int a, int b)
        {
            if (a > b) return 0;
            return a + RecurSum(++a, b);
        }
        #endregion
    }
}
