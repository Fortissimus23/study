using System;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{

   
    class Train
    {
        // Свойства 
        public string destination { get; set; }
        public string departure_time { get; set; }


        public int train_number;


        public int train_number_2 { 
            get { return train_number; }
            set {
                if (train_number > 0)
                    train_number = value;
                            }

             }
        public int seat_number { get; set; }

        public int y { get; } = 5 ;
        public const int Months = 12;


        public int Num_private { get; }
        
        static int forStatic;
        static int counter;
       
        public void seats() 
        {
            Console.WriteLine("Количество мест в поезде: {0}", seat_number);
        }

        //// Конструктор без параметров
        public Train()
        {
            destination = "Таганрог";
            departure_time = "13:37";
            train_number = 43;
            seat_number = 13;
            counter++;
        }


        public Train(int Train_num, string Destination)
        {
            destination = Destination;
            departure_time = "4:20";
            train_number = Train_num;
            seat_number = 2;

        }

        //private Train(int Num)
        //{
        //    _ID = GetHashCode();
        //}




        static Train()
        {
            forStatic = 228;
            counter++;

        }

        public static void printCounter()
        {
            Console.WriteLine("Количество экземплятров класса: " + counter);
        }


        public override string ToString()
        {
            return $"{destination}:{departure_time}:{train_number}:{seat_number}";
        }

        public override int GetHashCode()
        {
            return destination.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType()) return false;

            Train train = (Train)obj;
            return (this.destination == train.destination);
        }

        public Train(string Place, string Time, int trNum, int stNum)
        {
            Regex TimeRegex = new Regex(@"^([0-1]?[0-9]|2[0-3]):[0-5][0-9]$");
            if (TimeRegex.Matches(Time).Count > 0)
            {

                destination = Place;
                train_number = trNum;
                departure_time = Time;
                seat_number = stNum;
            }
            else return;
            counter++;
        }




        void find(Train[] trains, string destination, string time, byte type)
        {
            if (type == 0)
                Console.WriteLine($"---Список рейсов для назначения: {destination}---");
            else if (type == 1)
                Console.WriteLine($"---Список рейсов для назначения и после время: {destination}---");


            var t1 = Convert.ToDateTime("5:00");

            foreach (Train train in trains)
            {
                var t2 = Convert.ToDateTime(train);
                int i = DateTime.Compare(t2, t1);


                if (type == 0 && train.destination == destination)
                    Console.WriteLine($"До {destination} едут поезда с номерамми {train.train_number}");
                else if (type == 1 && train.destination == destination && i == 1)
                    Console.WriteLine($"До {destination}, после 5:00, едут поезда с номерамми {train.train_number}");


            }
            
        }




    }


    public partial class Person
    {
        public void Eat()
        {
            Console.WriteLine("I am eating");
        }
    }


    class Program
    {





        static void Main(string[] args)
        {
            void find(Train[] trains, string destination, byte type)
        {
            if (type == 0)
                Console.WriteLine($"---Список рейсов для назначения: {destination}---");
            else if (type == 1)
                Console.WriteLine($"---Список рейсов для назначения и после время: {destination}---");


            var t1 = Convert.ToDateTime("5:00");

            foreach (Train train in trains)
            {
                var t2 = Convert.ToDateTime(train.departure_time);
                int i = DateTime.Compare(t2, t1);


                if (type == 0 && train.destination == destination)
                    Console.WriteLine($"До {destination} едут поезда с номерамми {train.train_number}");
                else if (type == 1 && train.destination == destination && i == 1)
                    Console.WriteLine($"До {destination}, после 5:00, едут поезда с номерамми {train.train_number}");


            }

        }
            
            
            Train[] trains = new Train[3];
            trains[0] = new Train();
            trains[1] = new Train(12, "Минск");
            trains[2] = new Train("Бобруйск", "12:30", 11, 56);
            Console.WriteLine(trains[0]);
            Console.WriteLine(trains[1]);
            Console.WriteLine(trains[2]);

            find(trains, "Бобруйск", 1);


            Console.WriteLine(trains[0].ToString());


            Train test_1 = new Train { destination = "Москва" };
            Train test_2 = new Train { destination = "Не москва" };
            Train test_3 = new Train { destination = "Москва" };


            bool t1_t2 = test_1.Equals(test_2);
            bool t1_t3 = test_1.Equals(test_3);

            Console.WriteLine(t1_t2);
            Console.WriteLine(t1_t3);
            Console.WriteLine(trains[0].train_number_2);

            Person tom = new Person();
            tom.Move();
            tom.Eat();




            void GetRectangleData(int width, int height, out int rectArea, out int rectPerimetr)
            {
                rectArea = width * height;
                rectPerimetr = (width + height) * 2;
            }

            GetRectangleData(10, 20, out int area, out int perimetr);

            Console.WriteLine($"Площадь прямоугольника: {area}");       // 200
            Console.WriteLine($"Периметр прямоугольника: {perimetr}");   // 60

            var user = new { Name = "Tom", Age = 34 };
            Console.WriteLine(user.Name);




            //void PrintPerson(string name, int age = 1, string company = "Undefined")
            //{
            //    Console.WriteLine($"Name: {name}  Age: {age}  Company: {company}");
            //}


        }
    }
}
