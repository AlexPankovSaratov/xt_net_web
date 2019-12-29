using Epam.ListUsers.Entities;
using Epam.ListUsers.Logic;
using Epam.ListUsers.LogicContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task_6.ConsoleUI
{
    class Program
    {
        private static IUserLogic UserLogic;
        static Program()
        {
            UserLogic = new UserLogic();
        }
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1. Add user");
                Console.WriteLine("2. Remove user");
                Console.WriteLine("3. View the list of users");
                Console.WriteLine("0. Exit");

                ConsoleKeyInfo Mode = Console.ReadKey(intercept: true);
                switch (Mode.Key)
                {
                    case ConsoleKey.D1:
                        AddUser();
                        break;
                    case ConsoleKey.D2:
                        RemoveUser();
                        break;
                    case ConsoleKey.D3:
                        ViewListUsers();
                        break;
                    case ConsoleKey.D0:
                        return;
                    default:
                        break;
                }
            }
        }
        private static void ViewListUsers()
        {
            User[] users = UserLogic.GetAll();
            foreach (User item in users)
            {
                //Console.WriteLine("ID - " + item.Id + " Name - " + item.Name + " DateOfBirth - " + item.DateOfBirth + " Age - " + item.Age);
                Console.WriteLine($"{item.Id}. {item.Name}. {item.DateOfBirth}. {item.Age}");
            }
        }

        private static void RemoveUser()
        {
            UserLogic.RemovedUser(5);
            Console.WriteLine("User Removed");
        }

        private static void AddUser()
        {
            UserLogic.AddUser(1, "qwe", DateTime.Now, 12);
            Console.WriteLine("User Added");
        }
    }
}
