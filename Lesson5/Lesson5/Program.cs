using System;
using MenuLib;
using FC = MenuLib.FastConsole;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

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
        #region Задание 1
        static void Task01()
        {
            //Проверка корректности ввода логина. (от 2х до 10ти символов, содержит только буквы и цифры, цифра не может быть первой.)
            string login;
            do
            {
                login = FC.Input("Введите логин или exit для выхода");
                Console.WriteLine(Login.IsCorrect(login) ? "Логин корректен" : "Логин некорректен");
                Console.WriteLine(Login.IsCorrectReg(login) ? "Логин корректен" : "Логин некорректен");
            } while (login != "exit");
        }
        static class Login
        {
            public static bool IsCorrect(string login)
            {
                if (login.Length >= 2 && login.Length <= 10 && !char.IsDigit(login[0]))
                {
                    foreach (char ch in login)
                        if (!char.IsLetterOrDigit(ch)) return false;
                    return true;
                }
                else
                    return false;
            }
            public static bool IsCorrectReg(string login)
            {
                Regex regex = new Regex(@"^\p{L}[\w]{1,9}$");
                return regex.IsMatch(login);
            }
        }
        #endregion
    }
}
