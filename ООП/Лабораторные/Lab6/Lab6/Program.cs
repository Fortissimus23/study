using System;

namespace Lab6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("~~~~~~~~~~~~~~Книги~~~~~~~~~~~~~~");
            var book1 = new Transport();
            var book2 = new Transport();
            book1.Create();
            book2.Create();

            Console.WriteLine("\n~~~~~~~~~~~~Журналы~~~~~~~~~~~~~");
            var magazine1 = new Magazine();
            var magazine2 = new Magazine();
            magazine1.Create();
            magazine2.Create();

            Console.WriteLine("\n~~~~~~~~~~~~~Учебники~~~~~~~~~~~");
            var schoolbook1 = new Schoolbook();
            var schoolbook2 = new Schoolbook();
            schoolbook1.Create();
            schoolbook2.Create();

            Console.WriteLine("\n\n~~~~~~~~~~Библиотека~~~~~~~~~~");
            var library = new Library();
            library.Add(book1);
            library.Add(book2);
            library.Add(magazine1);
            library.Add(magazine2);
            library.Add(schoolbook1);
            library.Add(schoolbook2);
            library.Show();
            library.Delete(book2);
            library.Show();

            LibraryRealisation.FindBook(library.books);
            Console.WriteLine();
            LibraryRealisation.CountSchoolbook(library.books);
            Console.WriteLine();
            LibraryRealisation.GetPrice(library.books);
        }
    }
}
