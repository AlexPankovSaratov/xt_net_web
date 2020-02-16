using Epam.ListUsers.DalContracts;
using Epam.ListUsers.Entities;
using Epam.ListUsers.LogicContracts;
using System;
using System.Linq;

namespace Epam.ListUsers.Logic
{
    public class UserAttachmentLogic : IUserAttachmentLogic
    {
        private readonly IUserAttachmentDao _userAttachmentDao;
        public UserAttachmentLogic(IUserAttachmentDao userAttachmentDao)
        {
            _userAttachmentDao = userAttachmentDao;
        }

        public UserAttachment AddUser(string Login, string Password)
        {
            UserAttachment user = new UserAttachment {Login = Login, Password = Password };
            if (_userAttachmentDao.Add(user))
            {
                return user;
            }
            throw new ArgumentException("Error on user added");
        }

        public bool AddUserRole(string Login, string Role)
        {
            return _userAttachmentDao.AddUserRole(Login, Role);
        }

        public UserAttachment[] GetAll()
        {
            return _userAttachmentDao.GetAll().ToArray();
        }
    }
}
