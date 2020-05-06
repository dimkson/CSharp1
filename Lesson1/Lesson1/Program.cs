using System;
using MenuClass;
using FC = MenuClass.FastConsole;

namespace Lesson1
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu.delMenu[] delMenus = new Menu.delMenu[] { Task1, Task2, Task3, Task4, Task5 };
            Menu menu = new Menu(delMenus);
            menu.ChooseMenu();
        }

        #region Задание1
        static void Task1()
        {
            //Анкета
            string name, surName;
            name = FC.Input("Введите имя");
            surName = FC.Input("Введите фамилию");
            FC.Input("Введите возраст", out int age);
            FC.Input("Введите рост", out int height);
            FC.Input("Введите вес", out int weight);
            Console.WriteLine("Имя " + name + ", Фамилия " + surName + ", Возраст " + age
                + ", Рост " + height + ", Вес " + weight);
            Console.WriteLine("Имя {0}, Фамилия {1}, Возраст {2}, Рост {3}, Вес {4}", 
                name, surName, age, height, weight);
            Console.WriteLine($"Имя {name}, Фамилия {surName}, Возраст {age}," +
                $" Рост {height}, Вес {weight}");
            FC.Pause();
        }
        #endregion

        #region Задание2
        static void Task2()
        {
            //Расчет индекса массы тела
            FC.Input("Введите рост в метрах", out double h);
            FC.Input("Введите вес", out double m);
            double I = m / (h * h);
            Console.WriteLine($"Индекс массы тела {I:#.###}");
            FC.Pause();
        }
        #endregion

        #region Задание3
        struct Coordinats
        {
            public int x, y;

            public static double Calc(Coordinats c1, Coordinats c2)
            {
                return Math.Sqrt(Math.Pow(c2.x - c1.x, 2) + Math.Pow(c2.y - c1.y, 2));
            }
        }

        static void Task3()
        {
            //Расстояние между двумя точками
            Coordinats c1, c2;
            FC.Input("Введите координату x1", out c1.x);
            FC.Input("Введите координату y1", out c1.y);
            FC.Input("Введите координату x2", out c2.x);
            FC.Input("Введите координату y2", out c2.y);
            Console.WriteLine($"Расстояние между двумя точками равно {Coordinats.Calc(c1, c2):#.##}");
            FC.Pause();
        }
        #endregion

        #region Задание4
        static void Task4()
        {
            //Обмен значениями переменных
            FC.Input("Введите первое число", out int a);
            FC.Input("Введите второе число", out int b);
            a = a + b;
            b = a - b;
            a = a - b;
            Console.WriteLine($"Первое число {a}, второе число {b}");
            FC.Pause();
        }
        #endregion

        #region Задание5
        static void Task5()
        {
            string name, surName, city;
            name = FC.Input("Введите имя");
            surName = FC.Input("Введите фамилию");
            city = FC.Input("Введите город");
            FC.Print($"Имя: {name}, Фамилия: {surName}, Город: {city}", 40, 12);
            FC.Pause();
        }
        #endregion
    }
}
