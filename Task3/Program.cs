using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Тананыкин
 * 
 * Для двух строк написать метод, определяющий, является ли одна строка перестановкой другой.
 * Например:
 * badc являются перестановкой abcd.

 */

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Для двух строк написать метод, " +
                "определяющий, является ли одна строка перестановкой другой.");

            Console.Write("Введите первую строку:");
            string str1 = Console.ReadLine();

            Console.Write("Введите вторую строку:");
            string str2 = Console.ReadLine();

            if (ArePermutated(str1, str2))
                Console.WriteLine(
                    "Строка {0} является перестановкой строки {1}", str1, str2);
            else
                Console.WriteLine(
                    "Строка {0} является перестановкой строки {1}", str1, str2);

            Console.WriteLine("\nВведите любой символ для завершения программы. ");
            Console.ReadKey();
        }

        private static string ConvertTosortedString(string text)
        {
            char[] textArr = text.ToCharArray();
            Array.Sort(textArr);
            return new string(textArr);
        }

        private static bool ArePermutated(string str1, string str2)
        {
            str1 = ConvertTosortedString(str1);
            str2 = ConvertTosortedString(str2);
            return str1 == str2;
        }
    }
}
