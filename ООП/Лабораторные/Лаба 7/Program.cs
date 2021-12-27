using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;


namespace Лаба_5
{
    class Program
    {
        static void Main(string[] args)
        {

            //Marka_car ta4la = Marka_car.Audi;
            //Console.WriteLine(ta4la);

            //banan test = new banan { kolvo = 1,color = "желтый" };
            //test.Print();

            //van9 ilya = new van9();
            //ilya.pisat();
            //ilya.alarm();


            //transport mashin = new transport();
            //mashin.Add(new Car(), 15, 11, 10, "bmw");
            //mashin.Add(new Express(), 11, 9, 25, "yt bmw");

            //tr_manage trm = new tr_manage();
            //trm.Price(mashin);
            //trm.spee(mashin,1,20);

            //trm.SortByFuel(mashin);

      

            try
            {
                Car tr1 = new Car { price = -10 };
            }
            catch (Exept.PriceException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}  Метод: {ex.TargetSite }");
            }

            try
            {
                Car tr2 = new Car { speed = 1111111111};
                
            }
            catch (Exept.SpeedException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}  Метод: {ex.TargetSite }");
            }

            //tra = null;


            Car tr3 = new Car();
            try
            {
                int tr4 = tr3.speed / 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}  Метод: {ex.TargetSite }");
            }
            //Console.Read();

            try
            {
                Car tr5 = new Car { rasxod = 1111111111 };

            }
            catch (Exept.RasxodExeption ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}  Метод: {ex.TargetSite }");
            }



            int x = 0;
            int div = 0;
            try
            {
                div = 100 / x;
                Console.WriteLine("This linein not executed");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}  Метод: {ex.TargetSite }");
            }

            try
            {
                int[] myNumbers = { 1, 2, 3 };
                Console.WriteLine(myNumbers[10]);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}  Метод: {ex.TargetSite }");
            }

            



            finally
            {
                Console.WriteLine("Блок finally");
            }

            int index1;

            // Perform some action that sets the index.
            index1 =    40;

            // Test that the index value is valid.
            Debug.Assert(index1 > -1);




        }
    }


    //Автомобиль, Поезд, Транспортное средство, Экспресс, Двигатель, Вагон. 

  

    public partial class van9
    {
        public void pisat() { Console.WriteLine("Ваня пишет"); }
    }


    interface Transport
    {
        void print_2() => Console.WriteLine("Тут у нас не абстрактный");
    }


    class Exept
    {
        public class PriceException : Exception
        {
            public PriceException(string message) : base(message)
            {


            }
        }
        public class SpeedException : ArgumentException
        {
            public int Value { get; }
            public SpeedException(string message, int val) : base(message)
            {
                Value = val;
            }
        }

        public class RasxodExeption : Exception
        {
            public RasxodExeption(string message) : base(message)
            {


            }
        }

    }


    
    public abstract class Engeen
    {
        public bool have_engine = true;
        public int _speed;
        public int _price;
        public int _rasxod;
        public int rasxod
        {
            get
            {
                return _rasxod;
            }
            set
            {

                if (value > 250 && value < 1)
                    throw new Exept.SpeedException("Расход не может принимать такое значение", value);
                else
                    _rasxod = value;
            }
        }
        public int speed
        {
            get
            {
                return _speed;
            }
            set
            {

                if (value > 250)
                    throw new Exept.SpeedException("Скорость не может принимать такое значение", value);
                else
                    _speed = value;
            }
        }
        public string name;
        public int price
        {
            get { return _price; }
            set
            {
                if (value <= 0)
                    throw new Exept.PriceException("Цена не может быть меньше 0");
                else
                    _price = value;
            }
        }
        public abstract void print();




        //public override string ToString()
        //{
        //    return "Использован метод ToString()";
        //}
    }

    public class Car : Engeen, Transport
    {
         public bool isCar = true;
        public string marka;
        public override void print()
        {
            Console.WriteLine("Тут у нас абстрактный класс");
        }



    }
    enum Marka_car
    {
        BMW,
        Porshe,
        Audi,
        lada

    }

    struct banan
    {
        public string color;
        public int kolvo;
        public void Print()
        {
            Console.WriteLine($"Цвет банана: {color}, количество бананов: {kolvo}");
        }
    }

    public class Vagon : Engeen, Transport
    {
        public int number_vagon;

        public override void print()
        {
            Console.WriteLine("Тут у нас абстрактный класс");
        }

    }


    public class Train : Vagon, Transport
    {
        public int number_train;
    }

    public sealed class Express : Train, Transport
    {
        public string going_to;
    }

    public class Printer
    {
        public virtual void IAmPrinting(object someObj)
        {
            Console.Write(someObj.GetType());
        }
    }


    public partial class transport
    {

        public List<object> Elements = new List<object>();


    }
    



    }
