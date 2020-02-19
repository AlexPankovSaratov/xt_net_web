using Epam.ListUsers.DalContracts;
using Epam.ListUsers.Entities;
using Epam.ListUsers.LogicContracts;
using System;
using System.Linq;

namespace Epam.ListUsers.Logic
{
    public class UserLogic : IUserLogic
    {
        private readonly IUserDao _userDao;
        public UserLogic(IUserDao userDao)
        {
            _userDao = userDao;
        }

        public User[] GetAll()
        { 
            return _userDao.GetAll().ToArray();
        }      
        public void RemovedUser(int ID)
        {
            _userDao.Remove(ID);
        }
        public User AddUser(string Name, DateTime DateOfBirth)
        {
            double AgeInDays = (DateTime.Now.Date - DateOfBirth.Date).Days / 365;
            User user = new User { Id = _userDao.GetAll().Count() + 1, Name = Name, DateOfBirth = DateOfBirth, Age = (int)Math.Truncate(AgeInDays) };
            if (_userDao.Add(user))
            {
                return user;
            }
            throw new ArgumentException("Error on user added");
        }

        public bool AddUserAdward(int IDUser, int IDAsward)
        {
            return _userDao.AddUserAdward(IDUser, IDAsward);
        }

        public bool AddUserImage(int IDUser, byte[] ByteArrayImage)
        {
            return _userDao.AddUserImage(IDUser, ByteArrayImage);
        }

        public byte[] GetUserImage(int IDUser)
        {
            return _userDao.GetUserImage(IDUser);
        }

        public bool RemoveUserImage(int IDUser)
        {
            return _userDao.RemoveUserImage(IDUser);
        }
    }
}
