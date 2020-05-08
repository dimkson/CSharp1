using System;
using MenuLib;
using FC = MenuLib.FastConsole;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lesson5
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu.delMenu[] delMenus = new Menu.delMenu[] { Task01 };
            Menu menu = new Menu(delMenus);
            menu.ChooseMenu();
        }
        static void Task01()
        {
            Console.WriteLine("2");
            FC.Pause();
        }
    }
}
