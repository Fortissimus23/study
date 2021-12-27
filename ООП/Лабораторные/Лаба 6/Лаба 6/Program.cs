using System;
using System.Collections.Generic;
using System.Linq;

namespace Лаба_5
{
    class Program
    {
        static void Main(string[] args)
        {

            // subaru тож самое что и new Car() ?
            //Car subaru = new Car() { marka = "impreza"};
            //Transport bmw = subaru;




            //subaru.print();
            //bmw.print_2();


            //Express to_moscow = new Express() { number_vagon = 11, going_to = "moscow", number_train = 13 };

            //if (!(to_moscow is Car))
            //{
            //    Console.WriteLine("express не машина");
            //}

            //List<Engeen> CE = new List<Engeen>();
            //CE.Add(new Train());
            //CE.Add(new Car());
            //CE.Add(new Vagon());


            //Printer printer = new Printer();
            //foreach (Engeen E in CE)
            //{
            //    printer.IAmPrinting(E);
            //    if (E is Train)
            //        Console.WriteLine(" - Train");
            //    else if (E is Car)
            //        Console.WriteLine(" - Car");
            //    else if (E is Vagon)
            //        Console.WriteLine(" - Vagon");
            //}


            Marka_car ta4la = Marka_car.Audi;
            Console.WriteLine(ta4la);

            banan test = new banan { kolvo = 1,color = "желтый" };
            test.Print();

            van9 ilya = new van9();
            ilya.pisat();
            ilya.alarm();


            transport mashin = new transport();
            mashin.Add(new Car(), 15, 11, 10, "bmw");
            mashin.Add(new Express(), 11, 9, 25, "не bmw");

            tr_manage trm = new tr_manage();
            trm.Price(mashin);
            trm.spee(mashin,1,20);

            trm.SortByFuel(mashin);



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

    public abstract class Engeen
    {
        public bool have_engine = true;
        public int price;
        public int rasxod;
        public int speed;
        public string name;
        public int Get_rasxod() => rasxod;
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

        //public override string ToString()
        //{
        //    return "Использован метод ToString()";
        //}

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

        public byte menu()
        {
            Console.Write($"1. Вывести список всех кнопок\n" +
                          $"2. Вывести общее количество всех элементов\n" +
                          $"3. Найти общую площадь, всех фигур\n" +
                          $"4. Выход\n" +
                          $"$ ");
            return Convert.ToByte(Console.ReadLine());

        }

       


    }
    public class tr_manage
    {
        public void Price(transport tr)
        {
            int summa = 0;
            foreach (object item in tr.Elements)
            {

                try
                {
                    if (((Engeen)item).have_engine)

                        summa += ((Engeen)item).price;
                        
                }
                catch (System.InvalidCastException) { continue; }
            }

            Console.WriteLine($"Price:{summa }");
        }

        public void spee(transport tr, int min, int max)
        {

            foreach (object item in tr.Elements)
            {
                int speed = ((Engeen)item).speed;
                if( speed > min || speed < max)
                {
                    Console.WriteLine("Скорость машины подходит:" + ((Engeen)item).name);
                }

            }
        }

        public void SortByFuel(transport tr)
        {

            {
                for (int i = 0; i < tr.Elements.Count; i++)
                    for (int j = 0; j < tr.Elements.Count - 1; j++)
                        if (((Engeen)tr.Elements[j]).rasxod > ((Engeen)tr.Elements[j+1]).rasxod)
                        {
                            var t = tr.Elements[j + 1];
                            tr.Elements[j + 1] = tr.Elements[j];
                            tr.Elements[j] = t;
                        }
            }

            

            
            foreach (var item in tr.Elements)
            {
                Console.WriteLine(((Engeen)item).rasxod);
            }
                


                //Console.ReadLine();
;            
            

        }
    }



    }
