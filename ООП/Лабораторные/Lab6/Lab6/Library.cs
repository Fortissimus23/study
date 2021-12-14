using System;

namespace Lab6
{
    public class Library
    {
        public object[] books = new object[1];
        private static int count = 0;

        public object this[int index]
        {
            get
            {
                if (index > count || index < 0)
                {
                    throw new Exception("Out of range");
                }
                return books[index];
            }
            set
            {
                if (index > count || index < 0)
                {
                    throw new Exception("Out of range");
                }
                books[index] = value;
            }
        }

        public void Add(object bookToAdd)
        {
            if (bookToAdd is IPublishing)
            {
                books[count] = bookToAdd;
                Array.Resize(ref books, count + 2);
                count++;
            }
            else
            {
                throw new Exception("Нельзя добавлять элементы в коллекцию,не реализующие интерфейс IPublishing");
            }
        }

        public void Delete(object bookToDelete)
        {
            var find = false;
            for (int i = 0; i < count; i++)
            {
                if (books[i].Equals(bookToDelete))
                {
                    for (int j = i; j < count; j++)
                    {
                        books[j] = books[j + 1];
                    }
                    find = true;
                    break;
                }
            }
            if (!find)
            {
                Console.WriteLine("Not found");
            }
        }

        public void Show()
        {
            Console.WriteLine("Библиотека: ");
            if (count == 0)
            {
                Console.WriteLine("Null");
            }
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(books[i]);
            }
        }
    }
}