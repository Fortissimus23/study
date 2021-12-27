using System;
using System.Collections.Generic;

namespace Lab6
{
    public abstract class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int CountPublications { get; set; }
        public abstract float WritingExperience(int x, int y);
        public abstract string CreateAlias { get; }

        public abstract override string ToString();
    }

    public class Author : Person
    {
        public Author() { }
        public Author(string _name, string _surname, int _countPublications)
        {
            Name = _name;
            Surname = _surname;
            CountPublications = _countPublications;
        }

        public override float WritingExperience(int year, int yearOfWriting) => (float)yearOfWriting / year;
        
        public override string CreateAlias => Name.ToUpper() + Surname.Substring(0, 2);
        
        public override string ToString() => $"Тип объекта: {GetType()}, фамилия и имя автора - {Surname} {Name}, количество книг - {CountPublications}";
    }

    public class Publishing : Author
    {
        private List<Author> authors;
        private int Count => authors.Count;

        public Publishing() => authors = new List<Author> { };

        public void Add(Author author) => authors.Add(author);
        public void RemoveAt(int index)
        {
            if (index > authors.Count || index < 0)
            {
                Console.WriteLine("");
            }
            authors.RemoveAt(index);
        }

        public void Clear() => authors.Clear();

        public Author this[int index]
        {
            get
            {
                if (index > authors.Count || index < 0)
                {
                    Console.WriteLine("");
                }

                return authors[index];
            }
            set
            {
                if (index > authors.Count || index < 0)
                {
                    Console.WriteLine("");
                }
                authors[index] = value;
            }
        }

        public override string ToString() => $"Количество авторов, печатающихcя в издательстве, {authors.Count}";
        
        public void Search(string alias)
        {
            for (int i = 0; i < Count; i++)
            {
                if (authors[i].CreateAlias == alias)
                {
                    Console.WriteLine("Это автор есть в базе");
                }
                else
                {
                    Console.WriteLine("Автора в базе нет");
                }
            }
        }
    }

   

    public struct Transport 
    {
        public int Price { get; set; }
        public int Speed { get; set; }
        public int Rasxod { get; set; }


    }
    public struct Magazine : IPublishing
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public int NumberOfPublicat { get; set; }
        public int Year { get; set; }
        public int Price { get; set; }

        public void GetTitle()
        {
            Console.WriteLine("Введите название журнала: ");
            Title = Console.ReadLine();
        }

        public void GetGenre()
        {
            Console.WriteLine("Выбирете жанр: \n1-Научный\n2-Комиксы\n3-Женский\n4-Детский");
            var choice = Convert.ToInt16(Console.ReadLine());

            if (choice > 5 || choice < 1)
            {
                throw new Exception("Out of range");
            }
            else
            {
                switch (choice)
                {
                    case 1:
                        Genre = "Научный";
                        break;
                    case 2:
                        Genre = "Комиксы";
                        break;
                    case 3:
                        Genre = "Женский";
                        break;
                    case 4:
                        Genre = "Детский";
                        break;
                }
            }
        }

        public void NumberOfPublications()
        {
            Console.WriteLine("Введите количество изданий:");
            NumberOfPublicat = Convert.ToInt16(Console.ReadLine());
        }

        public void YearOfPublications()
        {
            Console.WriteLine("Введите год выпуска");
            Year = Convert.ToInt16(Console.ReadLine());
        }

        public void GetPrice()
        {
            Price = (int)PriceList.Price2;
            Console.WriteLine($"Цена журналов - {Price} р.");
        }

        public override string ToString() => $"Тип объекта: {GetType()}, название журнала - {Title}, жанр - {Genre}, количество публикаций - {NumberOfPublicat}, год выпуска - {Year}";
        
        public void Create()
        {
            GetGenre();
            GetTitle();
            NumberOfPublications();
            YearOfPublications();
            GetPrice();
        }
    }

    public struct Schoolbook : IPublishing
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public int NumberOfPublicat { get; set; }
        public int Year { get; set; }
        public int Price { get; set; }

        public void GetTitle()
        {
            Console.WriteLine("Введите название учебника: ");
            Title = Console.ReadLine();
        }

        public void GetGenre()
        {
            Console.WriteLine("Выбирете жанр: \n1-Физика\n2-Химия\n3-Математика\n4-Биология");
            var choice = Convert.ToInt16(Console.ReadLine());

            if (choice > 5 || choice < 1)
            {
                throw new Exception("Out of range");
            }
            else
            {
                switch (choice)
                {
                    case 1:
                        Genre = "Научный";
                        break;
                    case 2:
                        Genre = "Комиксы";
                        break;
                    case 3:
                        Genre = "Женский";
                        break;
                    case 4:
                        Genre = "Детский";
                        break;
                }
            }
        }

        public void NumberOfPublications()
        {
            Console.WriteLine("Введите количество изданий:");
            NumberOfPublicat = Convert.ToInt16(Console.ReadLine());
        }

        public void YearOfPublications()
        {
            Console.WriteLine("Введите год выпуска");
            Year = Convert.ToInt16(Console.ReadLine());
        }

        public void GetPrice()
        {
            Price = (int)PriceList.Price3;
            Console.WriteLine($"Цена учебников - {Price} р.");
        }

        public override string ToString() => $"Тип объекта: {GetType()}, название учебника - {Title}, жанр - {Genre}, количество публикаций - {NumberOfPublicat}, год выпуска - {Year}";

        public void Create()
        {
            GetGenre();
            GetTitle();
            NumberOfPublications();
            YearOfPublications();
            GetPrice();
        }
    }
    public static partial class LibraryRealisation
    {
        public static void GetPrice(object[] libries)
        {
            var countPrice = 0;
            foreach (object i in libries)
            {
                if (i is Transport)
                {
                    countPrice += (int)PriceList.Price1 * ((Transport)i).NumberOfPublicat;
                }
                if (i is Magazine)
                {
                    countPrice += (int)PriceList.Price2 * ((Magazine)i).NumberOfPublicat;
                }
                if (i is Schoolbook)
                {
                    countPrice += (int)PriceList.Price3 * ((Schoolbook)i).NumberOfPublicat;
                }
            }
            Console.WriteLine($"Общая стоимость изданий в библиотеке {countPrice} р.");
        }
    }
}
