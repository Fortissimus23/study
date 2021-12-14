using System;
using System.Collections.Generic;
using System.Text;

namespace Лаба_5
{
    public partial class transport

    {
        public void Add(Car tr, int speed, int rasxod, int price, string name)
        {
            tr.name = name;
            tr.speed = speed;
            tr.rasxod = rasxod;
            tr.price = price;
            Elements.Add(tr);
        }


        public void Add(Express tr, int speed, int rasxod, int price, string name)
        {
            tr.name = name;
            tr.speed = speed;
            tr.rasxod = rasxod;
            tr.price = price;
            Elements.Add(tr);
        }

        public void Print()
        {
            foreach (object obj in Elements)
                Console.WriteLine(obj);
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
                if (speed > min || speed < max)
                {
                    Console.WriteLine(((Engeen)item).name);
                }

            }
        }

        public void SortByFuel(transport tr)
        {

            {
                for (int i = 0; i < tr.Elements.Count; i++)
                    for (int j = 0; j < tr.Elements.Count - 1; j++)
                        if (((Engeen)tr.Elements[j]).rasxod > ((Engeen)tr.Elements[j + 1]).rasxod)
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







        }
    }



}
