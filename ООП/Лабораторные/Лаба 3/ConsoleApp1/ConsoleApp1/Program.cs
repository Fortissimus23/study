using System;

namespace ConsoleApp1
{

    enum MyEnum
    {

    }

    class Train
    {
        string place;
        int train_number;
        int time;
        int seats;



    }

    class Program
    {
        static void Main(string[] args)
        {
            Train t = new Train();
            t.x = 4;
            t.y = 2;
            Console.WriteLine(t.x);
        }
    }
}
