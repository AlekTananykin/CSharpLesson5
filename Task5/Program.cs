using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string filename = Directory.GetCurrentDirectory() +
                    "/gameQuestions.txt";
                Task[] tasks = ReadTask(filename);
                const int countQuestions = 3;
                PlayGame(tasks, countQuestions);
            }
            catch (GameTaskException ex)
            {
                Console.WriteLine(ex);
                if (null != ex.InnerException)
                    Console.WriteLine(ex.InnerException.Message);
            }

            Console.WriteLine(
                "\nНажмите любую клавишу для завершения программы.");
            Console.ReadKey();
        }
        struct Task
        {
            public string _question;
            public bool _answer;
        }

        private static Task[] ReadTask(string path)
        {
            try
            {
                string[] lines = File.ReadAllLines(path, 
                    Encoding.GetEncoding(1251));
                Task[] tasks = new Task[lines.Length];

                for (int i = 0; i < lines.Length; ++i)
                    FillTasks(lines[i], ref tasks[i]);

                return tasks;
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка считывания вопросов из файла", ex);
            }
        }

        private static void FillTasks(string line, ref Task task)
        {
            string[] columns = line.Split(new char[] { '\t' });
            if (2 != columns.Length)
                throw new GameTaskException(
                    "Не верный формат файла с вопросами. ");
            task._question = columns[0];

            bool? answer = ConvertAnswer(columns[1]);
            if (!answer.HasValue)
                throw new GameTaskException("");

            task._answer = answer.Value;
        }

        private static bool? ConvertAnswer(string ans)
        {
            ans = ans.ToLower();
            if ("да" == ans || "yes" == ans)
                return true;
            if ("нет" == ans || "no" == ans)
                return false;

            return null;
        }

        private static bool ReadAnswer()
        {
            while (true)
            {
                string line = Console.ReadLine();
                bool? answer = ConvertAnswer(line);
                if (answer.HasValue)
                    return answer.Value;

                Console.WriteLine("Ответ не понятен. " +
                    "Введите одно из перечисленных слов:" +
                    "да/yes, нет/no:");
            }
        }

        private static void PlayGame(Task[] tasks, int questionsCount)
        {
            if (0 == tasks.Length)
                throw new GameTaskException("Отсутствуют вопросы для игры. ");

            int[] readyQuestions = new int[questionsCount];

            int goodAnswers = 0;
            Random rnd = new Random();

            for (int i = 0; i < questionsCount; ++i)
            {
                int numTask = 0;
                do
                {
                    numTask = rnd.Next(0, tasks.Length - 1);
                }
                while (0 != Array.Find<int>(readyQuestions, 
                    (item) => numTask + 1 == item));
                readyQuestions[i] = numTask + 1;

                Console.WriteLine(tasks[numTask]._question);

                if (ReadAnswer() == tasks[numTask]._answer)
                    ++goodAnswers;
            }
            Console.WriteLine("Вы набрали {0} баллов. ", goodAnswers);
        }
    }
}
