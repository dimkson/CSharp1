﻿using System;
using MenuLib;
using FC = MenuLib.FastConsole;

namespace Lesson4
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

        }
    }
}
