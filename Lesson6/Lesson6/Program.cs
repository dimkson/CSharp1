using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MenuLib;
using FC = MenuLib.FastConsole;

namespace Lesson6
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu.delMenu[] delMenu = new Menu.delMenu[] { Task1, Task2 };
            Menu menu = new Menu(delMenu);
            menu.ChooseMenu();
        }
        #region Задание 1
        static void Task1()
        {
            //Создать метод, который будет выводить значения ф-ий от a до b. Для передачи разных ф-ий использовать делегаты.
            Console.WriteLine("Таблица функции A*x^2");
            Task01.Table(Task01.MyMethod1, 10, -2, 2);
            Console.WriteLine("Таблица функции A*sin(x)");
            Task01.Table(Task01.MyMethod2, 10, -2, 2);
            FC.Pause();
        }
        #endregion

        #region Задание 2
        static void Task2()
        {
            Task02.delFun[] delFuns = new Task02.delFun[] { Math.Sin, Math.Cos, Math.Tan, Math.Atan, Task02.MyMethod };
            Task02.delFun fun = Task02.ChooseMenu(delFuns);

            Console.WriteLine("Введите A:");
            Int32.TryParse(Console.ReadLine(), out int a);
            Console.WriteLine("Введите B:");
            Int32.TryParse(Console.ReadLine(), out int b);

            Task02.SaveFun("data.bin", fun , a, b, 2);
            double[] arr = Task02.Load("data.bin", out double min);
            foreach(double db in arr)
            {
                Console.Write(db + " ");
            }
            FC.Pause();
        }
        #endregion

    }
}
