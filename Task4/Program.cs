using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string filename = Directory.GetCurrentDirectory() +
                    "/pupilsList.txt";

                Pupil[] pupils = PupilAccounter.ReadPupiles(filename);

                Console.WriteLine("Список учеников с оценками");
                PupilAccounter.PrintPupilsEstimations(pupils);

                const int minFootPupilCount = 3;
                Pupil[] footPupil = PupilAccounter.GetFootPupil(
                    pupils, minFootPupilCount);

                Console.WriteLine("\nСписок худших учеников");
                PupilAccounter.PrintPupils(footPupil);

            }
            catch (PupilAccountException ex)
            {
                Console.WriteLine(ex);
                if (null != ex.InnerException)
                    Console.WriteLine(ex.InnerException.Message);
            }
            Console.WriteLine("\nНажмите любую клавишу для завершения программы.");
            Console.ReadKey();
        }
    }
}
