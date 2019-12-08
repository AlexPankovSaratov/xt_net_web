using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4
{
    class Program
    {
        static void Main(string[] args)
        {
            //CustomSort

            string [] Array = new string[] { "Привет как твои дела?", "Как дела?", "А Как дела?", "Б Как дела?", "Дела?" };
            CustomSort(Array, moreA);
            //CustomSort(Array, moreAInAlphabetOrder);
            foreach (var item in Array)
            {
                Console.WriteLine(item);
            }

            //

            Console.ReadLine();
        }
        static T[] CustomSort<T>(T[] Array, Func<T, T, bool> SortFunction)
        {
            T tempValue;
            for (int i = 0; i < Array.Count() - 1; i++)
            {
                for (int j = i + 1; j <= Array.Count() - 1; j++)
                    if (SortFunction.Invoke(Array[j], Array[i])) //Array[j] < Array[i]
                    {
                        tempValue = Array[i];
                        Array[i] = Array[j];
                        Array[j] = tempValue;
                    }
            }
            return Array;
        }
        static bool moreA(string A, string B)
        {
            if (A.Length < B.Length) return true;
            return false;
        }
        static bool moreAInAlphabetOrder(string A, string B)
        {
            bool result = false;
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
    }
}
