using Epam.ListUsers.Entities;
using Epam.ListUsers.Ioc;
using Epam.ListUsers.LogicContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.ListUsers.WebUI
{
    public class WebUI
    {
        private static IUserLogic UserLogic;
        private static IAdwardLogic AdwardLogic;
        static WebUI()
        {
            UserLogic = DependencyResolver.UserLogic;
            AdwardLogic = DependencyResolver.AdwardLogic;
        }
        public static bool AddUserAdward(string IDAsward, string IDUser)
        {
            if (IDAsward == null || IDUser == null) return false;
            try
            {
                int intIDAsward = Convert.ToInt32(IDAsward);
                int intIDUser = Convert.ToInt32(IDUser);
                return UserLogic.AddUserAdward(intIDUser, intIDAsward);
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static bool RemoveUser(string Id)
        {
            if (Id == null) return false;
            try
            {
                UserLogic.RemovedUser(Convert.ToInt32(Id));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static bool AddUser(string Name, string BirthDay)
        {
            if (Name == null || BirthDay == null) return false;
            try
            {
                string [] Array = BirthDay.Split('-');
                int Year = Convert.ToInt32(Array[0]);
                int Month = Convert.ToInt32(Array[1]);
                int Day = Convert.ToInt32(Array[2]);
                DateTime Birth = new DateTime(Year, Month, Day);
                UserLogic.AddUser(Name, Birth);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static void AddAdward(string Name)
        {
            if (Name == null) return;
            AdwardLogic.AddAdward(Name);
        }
        public static Adward[] GetListAdwards()
        {
            return AdwardLogic.GetAll();
        }
        public static string GetTitleAdward(int ID)
        {
            return AdwardLogic.GetTitleAdward(ID);
        }
        public static User[] GetListUsers()
        {
            return UserLogic.GetAll();
        }
    }
}
