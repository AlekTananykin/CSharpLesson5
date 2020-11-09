using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Тананыкин
 * 
 * Разработать статический класс Message, содержащий следующие статические 
 * методы для обработки текста:
 * а) Вывести только те слова сообщения,  которые содержат не более n букв.
 * б) Удалить из сообщения все слова, которые заканчиваются на заданный 
 * символ.
 * в) Найти самое длинное слово сообщения.
 * г) Сформировать строку с помощью StringBuilder из самых длинных слов 
 * сообщения.
 * д) ***Создать метод, который производит частотный анализ текста. В качестве 
 * параметра в него передается массив слов и текст, в качестве результата метод 
 * возвращает сколько раз каждое из слов массива входит в этот текст. 
 * Здесь требуется использовать класс Dictionary.
 */

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Введите сообщение:");
            //string messageText = Console.ReadLine();

            string filename = Directory.GetCurrentDirectory() + "/../../Program.cs";
            string messageText = File.ReadAllText(filename);


            RemoveSizeWords(messageText);
            RemoveSymbolWords(messageText);

            Console.WriteLine("в)Самое длинное слово сообщения: {0}\n", 
                Message.MaxSizeWord(messageText));

            Console.WriteLine("г)Самые длинные слова: {0}", 
                Message.GetMaxSizeWords(messageText));

            PrintFrequencyAnalyse(messageText);

            Console.WriteLine("\nВведите любой символ для завершения программы. ");
            Console.ReadKey();
        }

        private static void RemoveSizeWords(string messageText)
        {
            Console.WriteLine();
            Console.Write("Введите максимальную длину слова: ");
            int maxWordSize = int.Parse(Console.ReadLine());

            Console.WriteLine("а)Сообщение из слов длиной не более {0} " +
                "символов: {1}",
                maxWordSize, Message.MaxWordSizeMessage(messageText, maxWordSize));
        }

        private static void RemoveSymbolWords(string messageText)
        {
            Console.WriteLine();
            Console.WriteLine("\nб)Удаление из сообщения всех слов заканчивающихся " +
               "на заданный символ. ");
            Console.Write("Введите символ:");
            char ch = Console.ReadKey().KeyChar;
            Console.WriteLine("\nПолученное сообщение:");
            Console.WriteLine(Message.RemoveWordsWithEnd(messageText, ch));
        }

        private static void PrintFrequencyAnalyse(string messageText)
        {
            Console.WriteLine();
            Console.WriteLine("\nд) Частотный анализ текста. ");
            
            Console.WriteLine("Введите слова");
            string words = Console.ReadLine();

            IDictionary<string, int> dictionary = new Dictionary<string, int>();

            Message.FrequencyAnalyze(messageText, words, dictionary);
            foreach (KeyValuePair<string, int> kvp in dictionary)
                Console.WriteLine("{0} встречается {1} раз", kvp.Key, kvp.Value);
        }

    }
}
