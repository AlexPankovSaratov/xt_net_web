using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace Task_4
{
    class Program
    {
        static void Main(string[] args)
        {
            //CustomSort

            //string [] Array = new string[] { "Привет как твои дела?", "Как дела?", "АБ Как дела?", "АА Как дела?", "Дела?" };
            //CustomSort(Array, moreA);

            //foreach (var item in Array)
            //{
            //    Console.WriteLine(item);
            //}

            // NumberArraySum
            //int[] intArr = new int[] { 1, 2, 3,-5 };
            //Console.WriteLine("sum = " + intArr.NumberArraySum());

            // TO INT OR NOT TO INT
            //Console.WriteLine("3425342".ToPositiveInt());

            //I SEEK YOU (Ищу все положительные элементы в массиве)

            TimePrint();
        }
        static int []GetRandomArr(int count = 10000, int minValue = -100, int maxValue = 100)
        {
            int[] Arr = new int[count];
            Random rand = new Random();
            for (int i = 0; i < count; i++) Arr[i] = rand.Next(minValue,maxValue);
            return Arr;
        }
        static long TimeMEtod()
        {
            int[] ArrInt = GetRandomArr().ToArray();
            Stopwatch time = new Stopwatch();
            time.Start();
            ArrInt = AllPositiveElements(ArrInt, ElementPositive);
            time.Stop();
            return time.ElapsedMilliseconds;
        }
        static void TimePrint()
        {
            long resulttime = 0;
            long time = 0;
            for (int k = 0; k < 10; k++)
            {
                time = TimeMEtod();
                Console.WriteLine("Время вызова: " + time);
                resulttime += time;
            }
            Console.WriteLine("время работы AllPositiveElements: " + resulttime + " мс");
            Console.ReadLine();
        }
        static void CustomSort<T>(T[] Array, Func<T, T, bool> ElementComparison)
        {
            if (ElementComparison == null) return;
            T tempValue;
            for (int i = 0; i < Array.Count() - 1; i++)
            {
                for (int j = i + 1; j <= Array.Count() - 1; j++)
                    if (ElementComparison.Invoke(Array[j], Array[i])) //Array[j] < Array[i]
                    {
                        tempValue = Array[i];
                        Array[i] = Array[j];
                        Array[j] = tempValue;
                    }
            }
        }
        static bool moreA(string A, string B)
        {
            if(A.Length == B.Length)
            {
                char[] CharArrayA = A.ToCharArray();
                char[] CharArrayB = B.ToCharArray();
                foreach (char itemA in CharArrayA)
                {
                    foreach (char itemB in CharArrayB)
                    {
                        if (itemA != itemB) return itemA < itemB;
                    }
                }
                return false;
            }
            if (A.Length < B.Length) return true;
            return false;
        }
        static void CustomSortInAnotherThread<T>(T [] Array, Func<T, T, bool> ElementComparison)
        {
            //Thread myThread = new Thread();
        }
        public static int[] AllPositiveElements(int[] Array)
        {
            IList<int> ValidList = new List<int>();
            foreach (int item in Array)
            {
                if (item >= 0) ValidList.Add(item);
            }
            return ValidList.ToArray();
        }
        public static T[] AllPositiveElements<T>(T[] Array, Func<T, bool> ElementValidation)
        {
            if (ElementValidation == null) return Array;
            IList < T > ValidList = new List<T>();
            foreach (T item in Array)
            {
                if (ElementValidation(item)) ValidList.Add(item);
            }
            return ValidList.ToArray();
        }
        static bool ElementPositive(int item) => item >= 0;
    }
    public static class Extension
    {
        public static int NumberArraySum(this int[] Array)
        {
            int sum = 0;
            foreach (int item in Array)
            {
                sum += item;
            }
            return sum;
        }
        public static bool ToPositiveInt(this string str)
        {
            if (str.Length > Int32.MaxValue) return false;
            foreach (Char item in str.ToCharArray())
            {
                if(!Char.IsDigit(item)) return false;
            }
            return true;
        }
    }
}
