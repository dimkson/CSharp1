using System;
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
            //Найти количество пар эл-ов, в которых хотя бы одно из чисел делится на 3.
            Random rnd = new Random();
            int[] arr = new int[20];
            for(int i = 0; i < 20; i++)
                arr[i] = rnd.Next(-10000, 10000);
            Console.WriteLine("Исходные данные:");
            foreach(int i in arr)
                Console.Write(i + " ");
            Console.WriteLine("\n");
            int count = 0;
            for (int i = 0; i < 19; i++)
            {
                if(arr[i]%3==0 || arr[i + 1] % 3 == 0)
                {
                    count++;
                    Console.WriteLine("Пара эл-ов: " + arr[i] + " " + arr[i + 1]);
                }
            }
            Console.WriteLine("\nКоличество пар: " + count);
            FC.Pause();
        }
    }
}
