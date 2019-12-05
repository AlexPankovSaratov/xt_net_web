using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            //IList<int> Array = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
            //Console.WriteLine("Колличество элементов: " + Array.Count);
            //Lost(Array);
            //Console.WriteLine("Значение оставшенося элемента: " + Array[0]);
            //Console.ReadLine();

            WordFrequency("Hellow HELLOW Hellow may happy friend, may friend");
        }
        static void Lost<T>(IList<T> Array)
        {
            bool removeElement = false;
            Stack<int> RemoveStack = new Stack<int>();
            int index = 0;
            while (Array.Count > 1)
            {
                if (removeElement) RemoveStack.Push(index);
                index++;
                removeElement = !removeElement;
                if (index > Array.Count-1)
                {
                    index = 0;
                    while(RemoveStack.Count > 0)
                    {
                        Array.RemoveAt(RemoveStack.Pop());
                    }
                }
            }
        }
        static void WordFrequency(string str)
        {
            IList<string> ListStrUnique = new List<string> { };
            IList<string> ListStrAll = new List<string> { };
            foreach (string item in str.ToUpper().Split(' ', ','))
            {
                if (!(ListStrUnique.Contains(item))) ListStrUnique.Add(item);
            }
            foreach (string item in str.ToUpper().Split(' ', ','))
            {
                ListStrAll.Add(item);
            }
            foreach (string item in ListStrUnique)
            {
                if (item != "")
                {
                    int count = 0;
                    foreach (string itemAll in ListStrAll)
                    {
                        if (itemAll.Equals(item)) count++;
                    }
                    Console.WriteLine(item + " встречается " + count + " раз");
                }  
            }
            Console.ReadLine();
        }
    }
}
