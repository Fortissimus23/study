using System;

namespace Lab6
{
    public static partial class LibraryRealisation
    {
        public static void FindBook(object[] libraries)
        {
            Console.WriteLine("Введите год: ");
            var year = Convert.ToInt16(Console.ReadLine());
            foreach (object i in libraries)
            {
                if (i is Transport)
                {
                    if (((Transport)i).Year < year)
                    {
                        Console.WriteLine(((Transport)i).ToString());
                    }
                }
            }
        }

        public static void CountSchoolbook(object[] libraries)
        {
            var countSchoolbook = 0;
            foreach (object i in libraries)
            {
                if (i is Schoolbook)
                {
                    countSchoolbook++;
                }
            }
            Console.WriteLine($"Библиотека содержит {countSchoolbook} учебника(ов)");
        }
    }
}
