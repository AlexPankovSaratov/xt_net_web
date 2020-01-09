using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Epam.Task_7.REGULAR_EXPRESSIONS
{
    class Program

    {
        public enum TypeNumber
        {
            NormalNotation = 1,
            ScientificNotation = 2,
            NotNumber = 0
        }
        static void Main(string[] args)
        {
            //ConsoleDateExistance();
            //ConsoleHTMLReplaser();
            //ConsoleEmailFinder();
            ConsoleNumberValidator();
            //ConsoleTimeCounter();

        }
        public static void ConsoleDateExistance()
        {
            Console.WriteLine("Enter text in the format dd-mm-yyyy");
            string value = Console.ReadLine();
            if (DateExistance(value))
            {
                Console.WriteLine("The text \"" + value + "\" contains the date");
            }
            else Console.WriteLine("The text \"" + value + "\" does not contain a date");
            Console.ReadKey();
        }
        public static void ConsoleHTMLReplaser()
        {
            Console.WriteLine("Enter HTML text");
            string value = Console.ReadLine();
            Console.WriteLine("Result replaced");
            Console.WriteLine(HTMLReplaser(value, "_"));
            Console.ReadKey();
        }
        public static void ConsoleEmailFinder()
        {
            Console.WriteLine("Enter text");
            string value = Console.ReadLine();
            string[] ArrayStr = EmailFinder(value);
            if(ArrayStr.Count() > 0)
            {
                Console.WriteLine("All mail addresses in the text:");
                foreach (string item in ArrayStr)
                {
                    Console.WriteLine(item);
                }
                Console.ReadKey();
            }
        }
        public static void ConsoleTimeCounter()
        {
            Console.WriteLine("Enter text");
            string value = Console.ReadLine();
            Console.WriteLine("Время в тексте присутствует " + TimeCounter(value) + " раз.");
            Console.ReadKey();
        }
        public static void ConsoleNumberValidator()
        {
            Console.WriteLine("Insert the number:");
            TypeNumber Type = NumberValidator(Console.ReadLine());
            switch (Type)
            {
                case TypeNumber.NormalNotation:
                    Console.WriteLine("This number is in normal notation.");
                    break;
                case TypeNumber.ScientificNotation:
                    Console.WriteLine("This number is in scientific notation.");
                    break;
                case TypeNumber.NotNumber:
                    Console.WriteLine("This is not a number");
                    break;
            }
            Console.ReadKey();
        }

        private static bool DateExistance(string Str)
        {
            Regex regex = new Regex(@"\b([0-2]\d|3[0-1])-(0[0-9]|1[0-2])-([1-2]\d{3})\b");
            MatchCollection matches = regex.Matches(Str);
            if (matches.Count > 0) return true;
            return false;
        }
        private static string HTMLReplaser(string Str, string ReplaceStr)
        {
            Regex regex = new Regex(@"(<\S+?>)|(<\\^\S+?>)");
            return regex.Replace(Str, ReplaceStr);
        }
        private static string[] EmailFinder(string Str)
        {
            Regex regex = new Regex(@"\b[\da-zA-Z]\w+@[\w.]+[\da-zA-Z]\b");
            MatchCollection matches = regex.Matches(Str);
            string[] ArrayStr = new string[matches.Count];
            for (int i = 0; i < matches.Count; i++)
            {
                ArrayStr[i] = matches[i].Value;
            }
            return ArrayStr;
        }
        private static int TimeCounter(string Str)
        {
            Regex regex = new Regex(@"\b(\d|[0-1]\d|2[0-3]):[0-5]\d\b");
            MatchCollection matches = regex.Matches(Str);
            return matches.Count;
        }
        private static TypeNumber NumberValidator(string Str)
        {
            Regex regex = new Regex(@"^-?\d+.\d+(e-?\d+|[×xX]\d+([-+]\d|\u0178|\u0178)?)");
            MatchCollection matches = regex.Matches(Str);
            if(matches.Count == 1) return TypeNumber.ScientificNotation;
            regex = new Regex(@"^-?\d+[.\d+]?$");
            matches = regex.Matches(Str);
            if (matches.Count == 1) return TypeNumber.NormalNotation;
            else return TypeNumber.NotNumber;
        }
    }
}
