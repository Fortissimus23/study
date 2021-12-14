using System;
using System.Collections.Generic;
using System.Linq;


namespace Лаба_4
{





    class IntList : List<int>
    {
        private Owner il9 = new Owner { name = "иля", organization = "Bstu", id = 0 };
        private Date date = new Date { date = (DateTime.Now).ToString() };
        class Owner
        {
            public string name;
            public string organization;
            public uint id;
        }

        class Date
        {
            public string date;
        }


        public int kol_vo()
        {
            return this.Count;
        }


        public dynamic nulev()
        {
            this.Sort();

            if (this[0] == 0)
            {
                return true;
            }
            else return false;
        }



        public static IntList operator +(IntList rhs, int num)
        {
            rhs.Add(num);
            return rhs;
        }


        public static IntList operator --(IntList rhs)
        {
            rhs.RemoveAt(rhs.Count - 1);
            return rhs;
        }


        public static bool operator ==(IntList arr1, IntList arr2) => arr1.SequenceEqual(arr2);

        
        public static bool operator !=(IntList arr1, IntList arr2) => !arr1.SequenceEqual(arr2);


        public static bool operator true(IntList arr1)
        {

            List<int> arr2 = new List<int>();


            foreach (var item in arr1)
            {
                arr2.Add(item);
            }

            arr1.Sort();



            if (arr1.SequenceEqual(arr2)) return true;
            else return false;


        }


        public static bool operator false(IntList arr1)
        {

            List<int> arr2 = new List<int>();


            foreach (var item in arr1)
            {
                arr2.Add(item);
            }

            if (arr1.SequenceEqual(arr2)) return false;
            else return true;


        }


    }

    static class StaticOperation
    {
        static public int Sum(this IntList arr)
        {
            int sum = 0;
            for (int i = 0; i < arr.Count; i++)
                sum += arr[i];
            return sum;
        }

        static public int Diff(this IntList arr)
        {
            int max = arr[0], min = arr[0];
            for (int i = 0; i < arr.Count; i++)
            {
                if (arr[i] > max)
                    max = arr[i];
                if (arr[i] < min)
                    min = arr[i];
            }
            return max - min;
        }

        static public int Size(this IntList arr)
        {
            int counter = 0;

            while (arr[counter] != null)
                counter++;
            return --counter;
        }
        public static int CharCount(this string str, char c)
        {
            int counter = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == c)
                    counter++;
            }
            return counter;
        }



        class Program
        {



            static void Main(string[] args)
            {




                IntList numbers = new IntList() { 1, 2, 3, 45 };
                IntList number2 = new IntList() { 1, 2, 3, 45, 0, };


                Console.WriteLine(number2 == numbers);


                numbers = numbers + 15;
                numbers = numbers--;


                Console.WriteLine(numbers.Sum());
                if (numbers)
                {
                    Console.WriteLine("Одинаковы");
                }

                Console.WriteLine($"Количество - {numbers.kol_vo()}");
                Console.WriteLine($"нулевой - {number2.nulev()}");


                foreach (int i in numbers)
                {
                    Console.WriteLine(i);
                }

            }


        }
    }
}