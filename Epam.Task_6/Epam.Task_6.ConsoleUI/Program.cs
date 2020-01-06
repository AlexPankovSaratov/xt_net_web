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
        private static IAdwardLogic AdwardLogic;
        static Program()
        {
            UserLogic = DependencyResolver.UserLogic;
            AdwardLogic = DependencyResolver.AdwardLogic;
        }
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1. Add user");
                Console.WriteLine("2. Remove user");
                Console.WriteLine("3. View the list of users");
                Console.WriteLine("4. Add adward");
                Console.WriteLine("5. View the list of adwards");
                Console.WriteLine("6. Add a selected reward to a selected user");
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
                    case ConsoleKey.D4:
                        AddAdward();
                        break;
                    case ConsoleKey.D5:
                        ViewListAdwards();
                        break;
                    case ConsoleKey.D6:
                        AddUserAdward();
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
                if(item.AdwardsID.Count > 0)
                {
                    Console.Write("  All user rewards: ");
                    foreach (int adwardID in item.AdwardsID)
                    {
                        Console.Write(" " + GetTitleAdward(adwardID) + ".");
                    }
                    Console.WriteLine("");
                }
            }
            Console.ReadKey();
        }

        private static void AddUserAdward()
        {
            try
            {
                Console.WriteLine("Enter reward ID to add");
                int IDAsward = Convert.ToInt32(Console.ReadLine());     
                Console.WriteLine("Enter user ID");
                int IDUser = Convert.ToInt32(Console.ReadLine());
                if(!UserLogic.AddUserAdward(IDUser, IDAsward))
                {
                    Console.WriteLine("No reward added");
                    Console.ReadKey();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("The entered data is incorrect");
                Console.ReadKey();
            }
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
            try
            {
                Console.WriteLine("Enter year of birth");
                int Year = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter month  of birth");
                int Month = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter day of birth");
                int Day = Convert.ToInt32(Console.ReadLine());
                DateTime Birth = new DateTime(Year, Month, Day);
                UserLogic.AddUser(Name, Birth);
            }
            catch (Exception)
            {
                Console.WriteLine("The entered data is incorrect");
                Console.ReadKey();
            }
        }
        private static void AddAdward()
        {
            Console.WriteLine("Enter award name");
            string Name = Console.ReadLine();
            AdwardLogic.AddAdward(Name);
        }
        private static void ViewListAdwards()
        {
            Adward[] Adwards = AdwardLogic.GetAll();
            if (Adwards.Count() > 0) Console.WriteLine("All Adwards:");
            foreach (Adward item in Adwards)
            {
                Console.WriteLine($"{item.Id}. {item.Title}");
            }
            Console.ReadKey();
        }
        private static string GetTitleAdward(int ID)
        {
            return AdwardLogic.GetTitleAdward(ID);
        }
    }
}
