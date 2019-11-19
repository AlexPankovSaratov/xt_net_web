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
            /*
                // Task 0

            int N = 9;
            Console.WriteLine(Task_0_1_Sequence(N));
            if (Task_0_2_Simple(N))
            {
                Console.WriteLine("Число " + N + " простое");
            }
            else
            {
                Console.WriteLine("Число " + N + " НЕ простое");
            }
            Task_0_3_Squere(N);
            Task_0_4_Array();

            Console.ReadKey();
            

                //Task 1

            Task_1_1_RECTANGLE();
            Task_1_2_TRIANGLE();
            Task_1_3_ANOTHER_TRIANGLE();
            Task_1_4_X_MAS_TREE();
            */


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
        static int[][] ToothedArraySorting(int[][] MainArray)
        //Сортировка зубчатаого массива
        {
            int AllCount = 0;
            for (int i = 0; i < MainArray.Length; i++)
            {
                AllCount = AllCount + MainArray[i].Length;
            }
            int[] AllValueArray = new int[AllCount];
            int size = 0;
            for (int i = 0; i < MainArray.Length; i++)
            {
                MainArray[i].CopyTo(AllValueArray, size);
                size = size + MainArray[i].Length;
            }
            AllValueArray = ArraySorting(AllValueArray);
            int numberValue = 0;
            for (int i = 0; i < MainArray.Length; i++)
            {
                for (int i2 = 0; i2 < MainArray[i].Length; i2++)
                {
                    MainArray[i][i2] = AllValueArray[numberValue];
                    numberValue = numberValue + 1;
                }
            }
            return MainArray;
        }
        static void Create_ChristmasTree(int CountStrings, int LeftMargin)
        {
            int count_stars = 1;
            do
            {
                for (int i = 0; i < CountStrings - 1 + LeftMargin; i++) Console.Write(" ");
                for (int i = 0; i < count_stars; i++) Console.Write("*");
                if (CountStrings > 0) Console.WriteLine("");
                count_stars += 2;
                CountStrings--;
            } while (CountStrings > 0);
        }

        /// <summary>
        /// Создание положительного числа больше 0
        /// </summary>
        /// <returns></returns>
        static int Create_positive_Int(string Message)
        {
            int N = 0;
            do
            {
                try
                {
                    Console.Write(Message);
                    N = Convert.ToInt32(Console.ReadLine());
                    if (N < 1) Console.WriteLine("Число должно быть больше нуля");
                }
                catch (FormatException)
                {
                }
            } while (N < 1);
            return N;
        }

        static String Task_0_1_Sequence(int N)
        //Рекурсивное создание последовательных чисел
        {
            String result = N.ToString();
            if (N > 1)
            {
                result = Task_0_1_Sequence(N - 1) + "," + result;
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
            for (int i = N / 2; i > 1; i--)
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
                    if (row == N / 2 + 1 & column == N / 2 + 1)
                    {
                        Console.Write(" ");
                    }
                    else if (row == N)
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
        //Создание пользователем массива с рандомными значениями и его сортировка
        {
            Console.Write("Кол-во массивов: ");
            int CounArray = Convert.ToInt32(Console.ReadLine());
            if (CounArray == 0)
            {
                return;
            }
            int[][] MainArray = new int[CounArray][];
            Random rand = new Random();
            for (int i = 0; i < CounArray; i++)
            {
                Console.Write("Введите размер массива №" + i + ": ");
                int arraySize = Convert.ToInt32(Console.ReadLine());
                MainArray[i] = new int[arraySize];
                for (int i2 = 0; i2 < arraySize; i2++)
                {
                    MainArray[i][i2] = rand.Next(1, 100);
                    Console.WriteLine(MainArray[i][i2]);
                }
            }
            MainArray = ToothedArraySorting(MainArray);

            for (int i = 0; i < MainArray.Length; i++)
            {
                Console.WriteLine("Отсортированный массив №" + i);
                for (int i2 = 0; i2 < MainArray[i].Length; i2++)
                {
                    Console.WriteLine(MainArray[i][i2] + " ");
                }
            }
        }
        /// <summary>
        /// Вычисляет площадь прямоугольника по введённым пользователем данным
        /// </summary>
        static void Task_1_1_RECTANGLE()
        {
            int rectangle_width = Create_positive_Int("Введите ширину прямоугольника: ");
            int rectangle_long = Create_positive_Int("Введите длинну прямоугольника: ");
            Console.Write("Площадь прямоугольника = " + rectangle_width * rectangle_long);
            Console.ReadLine();
        }
        static void Task_1_2_TRIANGLE()
        {
            int N = Create_positive_Int("Введите число строк: ");
            string ValueString = "";
            do
            {
                ValueString += "*";
                Console.WriteLine(ValueString);
                N--;
            } while (N > 0);
            Console.ReadLine();
        }/// <summary>
        /// Рисует ёлочку по колличеству строк, которое вводит пользователь
        /// </summary>
        static void Task_1_3_ANOTHER_TRIANGLE()
        {
            int N = Create_positive_Int("Введите число строк: ");
            Create_ChristmasTree(N,0);
            Console.ReadLine();
        }
        static void Task_1_4_X_MAS_TREE()
        {
            int N = Create_positive_Int("Введите число елочек: ");
            for(int i = 1, LeftMargin = N-1; i <= N; i++, LeftMargin--)
            {
                Create_ChristmasTree(i, LeftMargin);
            }
            Console.ReadLine();
        }
    }
}
