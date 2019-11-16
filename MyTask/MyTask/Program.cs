using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTask
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = 9;
            Console.WriteLine(Task_0_1_Sequence(N));
            if (Task_0_2_Simple(N))
            {
                Console.WriteLine("Число " + N + " простое");
            }else
            {
                Console.WriteLine("Число " + N + " НЕ простое");
            }
            Task_0_3_Squere(N);
            Task_0_4_Array();
            
            Console.ReadKey();
        }
        
        public static int[] ArraySorting(int[] arr)
        //Сортировка массива
        {
            int tempValue;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = i + 1; j <= arr.Length - 1; j++)
                    if (arr[j] < arr[i])
                    {
                        tempValue = arr[i];
                        arr[i] = arr[j];
                        arr[j] = tempValue;
                    }
            }
            return arr;
        }
       
        static String Task_0_1_Sequence(int N)
        //Рекурсивное создание последовательных чисел
        {
            String result = N.ToString();
            if(N > 1)
            {
                result = Task_0_1_Sequence(N - 1) + ","+  result;
            }
            else
            {
                result = 1.ToString();
            }
            return result;
        }
        
        static Boolean Task_0_2_Simple(int N)
        //Проверка простое ли число
        {
            Boolean result = true;
            for(int i = N/2; i > 1; i--)
            {
                if (N % i == 0) result = false;
            }
            return result;
        }
        
        static void Task_0_3_Squere(int N)
        //Квадрат из звёздочек в центре с пробелом
        {
            for (int column = 1; column <= N; column++)
            {
                for (int row = 1; row <= N; row++)
                {
                    if(row == N/2+1 & column == N/2+1)
                    {
                        Console.Write(" ");
                    }
                    else if(row == N)
                    {
                        Console.WriteLine("*");
                    }
                    else
                    {
                        Console.Write("*");
                    }
                }
            }        
        }
        
        static void Task_0_4_Array()
        //Массив массивов
        {
            Console.Write("Кол-во массивов: ");
            int CounArray = Convert.ToInt32(Console.ReadLine());
            if(CounArray == 0)
            {
                return;
            }
            int AllCount = 0;
            int[][] MainArray = new int [CounArray][];
            Random rand = new Random();
            for (int i = 0; i < CounArray; i++)
            {
                Console.Write("Введите размер массива №" + i + ": ");
                int arraySize = Convert.ToInt32(Console.ReadLine());
                MainArray[i] = new int[arraySize];
                for(int i2 = 0; i2 < arraySize; i2++)
                {
                    MainArray[i][i2] = rand.Next(1,100);
                    AllCount = AllCount + 1;
                    Console.WriteLine(MainArray[i][i2]);
                }
            }
            int [] AllValueArray = new int[AllCount];
            int size = 0;
            for(int i = 0; i < MainArray.Length; i++)
            {
                MainArray[i].CopyTo(AllValueArray, size);
                size = size + MainArray[i].Length;
            }
            AllValueArray = ArraySorting(AllValueArray);
            int numberValue = 0;
            for(int i = 0; i < MainArray.Length; i++)
            {
                Console.WriteLine("Отсортированный массив №" + i);
                for (int i2 = 0; i2 < MainArray[i].Length; i2++)
                {
                    MainArray[i][i2] = AllValueArray[numberValue];
                    numberValue = numberValue + 1;
                    Console.WriteLine(MainArray[i][i2] + " ");
                }
            }
        }
    }
}
