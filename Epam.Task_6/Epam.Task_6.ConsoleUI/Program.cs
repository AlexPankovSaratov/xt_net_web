using Epam.ListUsers.Entities;
using Epam.ListUsers.Ioc;
using Epam.ListUsers.LogicContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.ListUsers.ConsoleUI
{
    class Program
    {
        private static IUserLogic UserLogic;
        static Program()
        {
            UserLogic = DependencyResolver.UserLogic;
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
            if(users.Count() > 0) Console.WriteLine("All Users:");
            foreach (User item in users)
            {
                Console.WriteLine($"{item.Id}. {item.Name}. {item.DateOfBirth}. {item.Age}");
            }
            Console.ReadKey();
        }

        private static void RemoveUser()
        {
            Console.WriteLine("Enter the id of the user to be deleted");
            int Id = Convert.ToInt32(Console.ReadLine());
            UserLogic.RemovedUser(Id);
        }

        private static void AddUser()
        {
            Console.WriteLine("Enter username");
            string Name = Console.ReadLine();
            Console.WriteLine("Enter year of birth");
            int Year = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter month  of birth");
            int Month = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter day of birth");
            int Day = Convert.ToInt32(Console.ReadLine());
            DateTime Birth = new DateTime(Year, Month, Day);
            UserLogic.AddUser(Name, Birth);
        }
    }
}
