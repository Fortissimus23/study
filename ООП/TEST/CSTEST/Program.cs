using System;

namespace CSTEST
{


    class Month
    {
     
        private const int length = 12;
        private string[] mon;
        // массив месяцев

        public Month()
        {
            mon = new string[length] { "Январь", "Февраль", "Апрель", "Март", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь" };

        }


        // перегрузка 
        public string this[int index]
        {
            get
            {
                if (index >= 00 && index < length)
                    return $"Элемент под номером :{index} это - {mon[index]}.";
                else
                    return $"Что-то не так";
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string a = "asgasg";
            string b = "asgasg";
            
            // Проверка на индентичность строк 1.А
            Console.WriteLine(a.Equals(b));


            // Одномерный массив с обратный порядком 2.b
            // Создали массив 
            string[] arr_1 = new string[3] { "Первый", "Второй", "Трейтий"};
            // Второй массив куда будем сувать в обратном порядке
            string[] arr_2 = new string[3];
           


            int j = 0;
            for (int i = arr_1.Length; i > 0; i--)
            {
                arr_2[j] = arr_1[i-1];
                j++;
            }

            
            //Вывод значений массива
            foreach (var item in arr_2)
            {
                Console.WriteLine(item);
            }

            


            //Создаем экземпляр класса месяц
            Month mis9 = new Month();
            //Выводим эл пож индексом
            Console.WriteLine(mis9[2]);


            //Создаём экзм класса студент 
            Student van9 = new Student();
            //Создаём экзм интерфейса
            IDo nasled = van9;
            
            van9.coding();
            nasled.coding();



        }
    }

    //Создание интерфейса
    interface IDo
    {
        void coding();
    }
    // Создание абстрактного класса 
    abstract class Programmer
    {
        public abstract void coding();
    }
    class Student : Programmer, IDo
    {
        public override void coding() => Console.WriteLine("Тут у нас абстрактный класс");
        void IDo.coding() => Console.WriteLine("Тут у нас не абстрактный");
    }



}
