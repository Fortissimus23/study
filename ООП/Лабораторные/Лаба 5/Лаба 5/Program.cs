using System;
using System.Collections.Generic;

namespace Лаба_5
{
    class Program
    {
        static void Main(string[] args)
        {

            // subaru тож самое что и new Car() ?
            Car subaru = new Car() { marka = "impreza"};
            Transport bmw = subaru;




            subaru.print();
            bmw.print_2();


            Express to_moscow = new Express() { number_vagon = 11, going_to = "moscow", number_train = 13 };

            if (!(to_moscow is Car))
            {
                Console.WriteLine("express не машина");
            }

            List<Engeen> CE = new List<Engeen>();
            CE.Add(new Train());
            CE.Add(new Car());
            CE.Add(new Vagon());


            Printer printer = new Printer();
            foreach (Engeen E in CE)
            {
                printer.IAmPrinting(E);
                if (E is Train)
                    Console.WriteLine(" - Train");
                else if (E is Car)
                    Console.WriteLine(" - Car");
                else if (E is Vagon)
                    Console.WriteLine(" - Vagon");
            }



        }
    }


    //Автомобиль, Поезд, Транспортное средство, Экспресс, Двигатель, Вагон. 


    interface Transport
    {
        void print_2() => Console.WriteLine("Тут у нас не абстрактный");
    }

    abstract class Engeen
    {
        public abstract void print();

        public override string ToString()
        {
            return "Использован метод ToString()";
        }
    }

    class Car : Engeen, Transport
    {
        public string marka;
        public override void print()
        {
            Console.WriteLine("Тут у нас абстрактный класс");
        }

       

    }


    class Vagon : Engeen, Transport
    {
        public int number_vagon;

        public override void print()
        {
            Console.WriteLine("Тут у нас абстрактный класс");
        }

        public override string ToString()
        {
            return "Использован метод ToString()";
        }

    }


    class Train : Vagon, Transport
    {
        public int number_train;
    }

    sealed class Express : Train, Transport
    {
        public string going_to;
    }

    class Printer
    {
        public virtual void IAmPrinting(object someObj)
        {
            Console.Write(someObj.GetType());
        }
    }



}
