using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

/*Тананыкин
 * 
 * Создать программу, которая будет проверять корректность ввода логина. 
 * Корректным логином будет строка от 2 до 10 символов, содержащая только буквы 
 * латинского алфавита или цифры, при этом цифра не может быть первой:
 * а) без использования регулярных выражений;
 * б) **с использованием регулярных выражений.
 */
namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Проверка корректности введённого логина. ");

            Console.WriteLine("Логин должен иметь длину 2-10 символов, и " +
                "содержать буквы только латинског алфавита.\n");
            Console.Write("Введите логин: ");
            string login = Console.ReadLine();

            Console.Write("\nа)Проверка корректности без Regex: ");
            PrintMessage(IsLoginCorrect(login));
            
            Console.Write("\nб)Проверка корректности с Regex: ");
            PrintMessage(IsLoginCorrectRegex(login));

            Console.WriteLine("\nВведите любой символ для завершения программы. ");
            Console.ReadKey();

        }

        private static bool IsLoginCorrect(string login)
        {
            if (login.Length > 10 || login.Length < 2)
                return false;

            char ch = login[0];
            if ((ch < 'a' || ch > 'z') &&
                 (ch < 'A' || ch > 'Z'))
                return false;

            for (int i = 1; i < login.Length; ++i)
            {
                ch = login[i];
                if ((ch < '0' || ch > '9') &&
                    (ch < 'a' || ch > 'z') &&
                    (ch < 'A' || ch > 'Z'))
                    return false;
            }
            return true;
        }

        private static bool IsLoginCorrectRegex(string login)
        {
            Regex expression = new Regex(@"[a-zA-Z]{1}[a-zA-Z0-9]{1,9}");
            return expression.IsMatch(login);
        }

        private static void PrintMessage(bool isLoginCorrect)
        {
            if (isLoginCorrect)
                Console.WriteLine("Логин корректен");
            else
                Console.WriteLine("Логин не корректен");
        }
    }
}
