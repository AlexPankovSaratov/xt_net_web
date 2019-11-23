﻿using System;
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
            Task_1_5_SUM_OF_NUMBERS();
            Task_1_7_ARRAY_PROCESSING(0,10);
            Task_1_7_ARRAY_PROCESSING(-10, 10);
            Task_1_8_NO_POSITIVE();
            Task_1_9_NON_NEGATIVE_SUM();
            Task_1_10_2D_ARRAY();
            Task_1_12_CHAR_DOUBLER();
            */
            Task_1_11_AVERAGESTRING_LENGTH();

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

        static string Create_String(string Message)
        {
            string str = "";
            do
            {
                try
                {
                    Console.Write(Message);
                    str = Console.ReadLine();
                }
                catch (FormatException)
                {
                }
            } while (str == "");
            return str;
        }



        static int[] CreateRandomArray(int min, int max, int countValue)
        {
            Random random = new Random();
            int[] array = new int[countValue];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(min, max);
            }
            return array;
        }
        static int GetSumPositiveNumbers(int[] array)
        {
            int sum = 0;
            foreach (var i in array)
            {
                if (i > 0)
                {
                    sum += i;
                }
            }
            return sum;
        }
        static int SumEvenElementsInArray(int[][] array)
        {
            int sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                for (int q = 0; q < array[i].Length; q++)
                {
                    if ((i + q) % 2 == 0)
                    {
                        sum += array[i][q];
                    }
                }
            }
            return sum;
        }
        static int[,,] Create_3D_RandomArray(int size_1, int size_2, int size_3, int minValue, int maxValue)
        {
            Random random = new Random();
            int[,,] Array = new int[size_1, size_2, size_3];
            for (int i = 0; i < Array.GetLength(0); i++)
            {
                for (int j = 0; j < Array.GetLength(1); j++)
                {
                    for (int n = 0; n < Array.GetLength(2); n++)
                    {
                        Array[i, j, n] = random.Next(minValue, maxValue);

                    }
                }
            }
            return Array;
        }
        static int[][] СreationUser2D_Array(int minValue, int maxValue)
        {
            int CounArray = Create_positive_Int("Введите кол-во массивов: ");
            int[][] MainArray = new int[CounArray][];
            Random rand = new Random();
            for (int i = 0; i < CounArray; i++)
            {
                Console.Write("Введите размер массива №" + i + ": ");
                int arraySize = Create_positive_Int("Введите размер массива №" + i + ": ");
                MainArray[i] = new int[arraySize];
                for (int i2 = 0; i2 < arraySize; i2++)
                {
                    MainArray[i][i2] = rand.Next(minValue, maxValue);
                    Console.WriteLine(MainArray[i][i2]);
                }
            }
            return MainArray;
        }
        static void Print_3D_Array(int[,,] Array)
        {
            for (int i = 0; i < Array.GetLength(0); i++)
            {
                for (int j = 0; j < Array.GetLength(1); j++)
                {
                    for (int n = 0; n < Array.GetLength(2); n++)
                    {
                        if (n != Array.GetLength(2) - 1) Console.Write("[" + i + "," + j + "," + n + "] = " + Array[i, j, n] + " ");
                        else Console.WriteLine("[" + i + "," + j + "," + n + "] = " + Array[i, j, n] + " ");
                    }
                }
            }
        }
        static string[] ParceStringInArrayWords(string str)
        {
            char[] AllChar = str.ToCharArray();
            Stack<char> StackPunctuation = new Stack<char>();
            Stack<string> StackString = new Stack<string>();
            foreach (char element in AllChar)
            {
                if ((Char.IsNumber(element) || Char.IsSymbol(element) || Char.IsWhiteSpace(element) || Char.IsPunctuation(element)) && !StackPunctuation.Contains(element)) StackPunctuation.Push(element);
            }
            char[] PunctuationArray = new char[StackPunctuation.Count];
            for (int i = 0; StackPunctuation.Count != 0; i++) PunctuationArray[i] = StackPunctuation.Pop();
            string[] stringArray = str.Split(PunctuationArray);

            foreach (string element in stringArray)
            {
                if (element != "") StackString.Push(element);
            }
            stringArray = new string[StackString.Count];
            for (int i = 0; StackString.Count != 0; i++) stringArray[i] = StackString.Pop();
            return stringArray;
        }
        [Flags]
        enum TextFormat : int
        {
            Default = 0,
            bold = 1,
            italic = 2,
            uderline = 3,
            bold_italic = bold | italic,
            italic_uderline = italic | uderline
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
            int[][] MainArray = СreationUser2D_Array(0, 10);
            MainArray = ToothedArraySorting(MainArray);

            for (int i = 0; i < MainArray.Length; i++)
            {
                Console.WriteLine("Отсортированный массив №" + i);
                for (int i2 = 0; i2 < MainArray[i].Length; i2++)
                {
                    Console.WriteLine(MainArray[i][i2] + " ");
                }
            }
            Console.ReadLine();
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
            Create_ChristmasTree(N, 0);
            Console.ReadLine();
        }
        static void Task_1_4_X_MAS_TREE()
        {
            int N = Create_positive_Int("Введите число елочек: ");
            for (int i = 1, LeftMargin = N - 1; i <= N; i++, LeftMargin--)
            {
                Create_ChristmasTree(i, LeftMargin);
            }
            Console.ReadLine();
        }
        static void Task_1_5_SUM_OF_NUMBERS()
        {
            int sum = 0;
            for (int i = 1; i < 1000; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                {
                    sum += i;
                }
            }
            Console.WriteLine("Сумма всех чисел менее 1000 кратных 3 и 5 = " + sum);
            Console.ReadLine();

        }

 
        static void Task_1_6_FONT_ADJUSTMENT()
        {
            TextFormat currentTextStyle = new TextFormat();
            currentTextStyle ^= TextFormat.bold;
            currentTextStyle ^= TextFormat.italic;
            currentTextStyle ^= TextFormat.italic_uderline;
        }

        static void Task_1_7_ARRAY_PROCESSING(int min, int max)
        {
            int[] array = CreateRandomArray(min, max, 30);
            ArraySorting(array);
            foreach (var i in array)
            {
                Console.Write("{0} ", i);
            }
            Console.ReadLine();
        }


        static void Task_1_8_NO_POSITIVE()
        {
            int[,,] Array = Create_3D_RandomArray(4, 4, 4, -100, 100);
            Print_3D_Array(Array);
            for (int i = 0; i < Array.GetLength(0); i++)
            {
                for (int j = 0; j < Array.GetLength(1); j++)
                {
                    for (int n = 0; n < Array.GetLength(2); n++)
                    {
                        if (Array[i, j, n] > 0) Array[i, j, n] = 0;
                    }
                }
            }
            Console.WriteLine("Все положительные числа заменяем на 0");
            Print_3D_Array(Array);
            Console.ReadLine();
        }

        static void Task_1_9_NON_NEGATIVE_SUM()
        {
            int[] array = CreateRandomArray(-20, 20, 20);
            foreach (var i in array)
            {
                Console.Write("{0} ", i);
            }
            Console.WriteLine(Environment.NewLine + "Сумма положительных элементов = " + GetSumPositiveNumbers(array));
            Console.ReadLine();
        }
        static void Task_1_10_2D_ARRAY()
        {
            int sum = SumEvenElementsInArray(СreationUser2D_Array(0, 10));
            Console.WriteLine("Сумма элементов массива, стоящих на чётных позициях = " + sum);
            Console.ReadLine();
        }

        static void Task_1_11_AVERAGESTRING_LENGTH()
        {
            string [] strArr = ParceStringInArrayWords(Create_String("Введите строку: "));
            string str = "";
            foreach (string element in strArr)
            {
                str += element;
            }
            Console.WriteLine("Средний размер слова = " + (float)str.Length / (float)strArr.Count());
            Console.ReadLine();

        }
        static void Task_1_12_CHAR_DOUBLER()
        {
            string FirstString = Create_String("Введите первую строку: ");
            char[] Array = Create_String("Введите вторую строку: ").ToCharArray();
            StringBuilder STR = new StringBuilder();
            string test = "";
            foreach (char element in Array)
            {
                if (test.Contains(new string(element, 1)) == false)
                {
                    test += new string(element, 1);
                    FirstString = FirstString.Replace(new string(element, 1), new string(element, 2));
                }
                
            }
            Console.WriteLine("Результирующая строка: " + FirstString);
            Console.ReadLine();
        }
    }
}
