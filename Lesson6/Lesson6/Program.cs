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
            Menu.delMenu[] delMenu = new Menu.delMenu[] {Task1};
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

    }
}
