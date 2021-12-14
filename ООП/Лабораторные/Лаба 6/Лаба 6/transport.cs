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
}
