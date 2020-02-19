using Epam.ListUsers.Entities;
using Epam.ListUsers.Ioc;
using Epam.ListUsers.LogicContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace Epam.ListUsers.WebUI
{
    public class MyRoleProvider : RoleProvider
    {
        private static IUserAttachmentLogic UserAttachmentLogic;
        static MyRoleProvider()
        {
            UserAttachmentLogic = DependencyResolver.UserAttachmentLogic;
        }
        public static bool VerifUser(string Login, string Password)
        {
            if (UserAttachmentLogic.GetAll().Length == 0)
            {
                //Создаём гостевую учётку
                UserAttachmentLogic.AddUser("", "");
            }
            //if (Login == "" && Password != "") return false;
            foreach (UserAttachment item in UserAttachmentLogic.GetAll())
            {
                if (item.Login == Login)
                {
                    return item.Password == Password;
                }
            }
            UserAttachmentLogic.AddUser(Login, Password);
            if (UserAttachmentLogic.GetAll().Length == 2 && Login != "" && Password != "")
            {
                //Первый зарегистрированный пользователь становится админом
                UserAttachmentLogic.AddUserRole(Login, "Admin");
            }
            return true;
        }
        public static bool AddUserRole(string Login, string RoleName)
        {
            if (Login == "" && RoleName != "") return false;
            if (UserAttachmentLogic.GetAll().Length < 1)
            {
                AddUserRole(Login, "Admin");
            }
            foreach (UserAttachment item in UserAttachmentLogic.GetAll())
            {
                if (item.Login == Login)
                {
                    return UserAttachmentLogic.AddUserRole(Login, RoleName);
                }
            }
            return false;
        }
        public override bool IsUserInRole(string Login, string roleName)
        {
            if (Login == "Alex" && roleName == "Admin") return true;
            return false;
        }

        public override string[] GetRolesForUser(string Login)
        {
            string [] Roles = new string[] { };
            foreach (UserAttachment item in UserAttachmentLogic.GetAll())
            {
                if(item.Login == Login)
                {
                    Roles = item.Roles.ToArray(); ;
                }
            }
            return Roles;
        }
        #region NOT_IMPLEMENTED
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }


        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
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
        public static bool RemoveAdward(string ID)
        {
            if (ID == "") return false;
            try
            {
                AdwardLogic.RemoveAdward(Convert.ToInt32(ID));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
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
        public bool AddAdwardImage(string IdAdward, byte[] ByteArrayImage)
        {
            try
            {
                return AdwardLogic.AddAdwardImage(Convert.ToInt32(IdAdward), ByteArrayImage);
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool RemoveAdwardImage(string IdAdward)
        {
            try
            {
                return AdwardLogic.RemoveAdwardImage(Convert.ToInt32(IdAdward));
            }
            catch (Exception)
            {
                return false;
            }
        }
        public byte[] GetAdwardImage(string IdAdward)
        {
            try
            {
                return AdwardLogic.GetAdwardImage(Convert.ToInt32(IdAdward));
            }
            catch (Exception)
            {
                return new byte[] { };
            }
        }
        public bool AddUserImage(string ID, byte[] ByteArrayImage)
        {
            try
            {
                return UserLogic.AddUserImage(Convert.ToInt32(ID), ByteArrayImage);
            }
            catch (Exception)
            {
                return false;
            } 
        }
        public bool RemoveUserImage(string ID)
        {
            try
            {
                return UserLogic.RemoveUserImage(Convert.ToInt32(ID));
            }
            catch (Exception)
            {
                return false;
            } 
        }
        public byte[] GetUserImage(string ID)
        {
            try
            {
                return UserLogic.GetUserImage(Convert.ToInt32(ID));
            }
            catch (Exception)
            {
                return new byte[] { };
            }
        }
    }
}
