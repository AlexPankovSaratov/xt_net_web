using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task_6.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ModeSelection();
        }
        private static void ModeSelection()
        {
            Console.Clear();
            Console.WriteLine("1. Add user");
            Console.WriteLine("2. Remove user");
            Console.WriteLine("3. View the list of users");
            Console.WriteLine("0. Exit");

            ConsoleKeyInfo Mode = Console.ReadKey();
            switch (Mode.Key)
            {
                case ConsoleKey.D1:
                    //AddUser();
                    break;
                case ConsoleKey.D2:
                    //RemoveUser();
                    break;
                case ConsoleKey.D3:
                    //ViewListUsers();
                    break;
                case ConsoleKey.D0:
                    return;
                default :
                    ModeSelection();
                    break;
            }
        }
    }
}
