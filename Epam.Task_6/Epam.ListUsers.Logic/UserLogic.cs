using Epam.ListUsers.DalContracts;
using Epam.ListUsers.Entities;
using Epam.ListUsers.LogicContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.ListUsers.Logic
{
    public class UserLogic : IUserLogic
    {
        private IUserDao _userDao;

        public UserLogic()
        {
            _userDao = DaoProviser.UserDao;
        }

        public User[] GetAll()
        {
            return _userDao.GetAll().ToArray();
        }
         
        public void RemovedUser(int ID)
        {
            throw new NotImplementedException();
        }
        public User AddUser(int ID, string Name, DateTime DateOfBirth, int Age)
        {
            User user = new User { Id = ID, Name = Name, DateOfBirth = DateOfBirth, Age = Age };
            if (_userDao.Add(user))
            {
                return user;
            }
            throw new ArgumentException("Error on user added");
        }
    }
}
