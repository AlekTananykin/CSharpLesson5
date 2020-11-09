using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class PupilAccounter
    {
        public static Pupil[] GetFootPupil(Pupil[] pupils, int minFootPupilCount)
        {
            int footPupilCount = 0;
            if (pupils.Length <= minFootPupilCount)
            {
                footPupilCount = pupils.Length;
            }
            else
            {
                Array.Sort(pupils, new PupilComparer());
                int borderEstimation = 
                    pupils[minFootPupilCount - 1].AverageEstimate;

                for (footPupilCount = minFootPupilCount; 
                    footPupilCount < pupils.Length; ++footPupilCount)
                {
                    if (pupils[footPupilCount].AverageEstimate != borderEstimation)
                        break;
                }
            }

            Pupil[] footPupils = new Pupil[footPupilCount];
            Array.Copy(pupils, footPupils, footPupilCount);
            return footPupils;
        }

        private class PupilComparer : IComparer<Pupil>
        {
            public int Compare(Pupil p1, Pupil p2)
            {
                if (p1.AverageEstimate < p2.AverageEstimate)
                    return -1;
                if (p1.AverageEstimate > p2.AverageEstimate)
                    return 1;
                return 0;
            }
        }

        public static Pupil[] ReadPupiles(string filename)
        {
            try
            {
                Pupil[] pupilArray = null;
                using (StreamReader sr = new StreamReader(filename))
                {
                    int pupilCount = int.Parse(sr.ReadLine());
                    pupilArray = new Pupil[pupilCount];
                    for (int i = 0; i < pupilCount; ++i)
                    {
                        string line = sr.ReadLine();
                        ParsePupilLine(line, ref pupilArray[i]);
                    }
                }
                return pupilArray;
            }
            catch (Exception ex)
            {
                throw new PupilAccountException(
                    "Ошибка при считывании учеников из файла. ", ex);
            }
        }

        private static void ParsePupilLine(string line, ref Pupil pupil)
        {
            string[] lineArray = line.Split(new char[] { ' ' });
            if (5 != lineArray.Length)
                throw new PupilAccountException("Неверный формат записи ученика.");

            pupil = new Pupil();
            pupil.Surname = lineArray[0];
            pupil.Name = lineArray[1];
            pupil.Estimate1 = int.Parse(lineArray[2]);
            pupil.Estimate2 = int.Parse(lineArray[3]);
            pupil.Estimate3 = int.Parse(lineArray[4]);
        }

        public static void PrintPupils(Pupil[] pupilArray)
        {
            for (int i = 0; i < pupilArray.Length; ++i)
            {
                Console.WriteLine("{0} {1}", 
                    pupilArray[i].Surname, pupilArray[i].Name);
            }
        }

        public static void PrintPupilsEstimations(Pupil[] pupilArray)
        {
            for (int i = 0; i < pupilArray.Length; ++i)
            {
                Console.WriteLine("{0} {1}: {2} {3} {4}",
                    pupilArray[i].Surname, pupilArray[i].Name, 
                    pupilArray[i].Estimate1, 
                    pupilArray[i].Estimate2, 
                    pupilArray[i].Estimate3);
            }
        }
    }
}
