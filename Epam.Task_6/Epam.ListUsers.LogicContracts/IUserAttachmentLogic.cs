using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.ListUsers.Entities;

namespace Epam.ListUsers.LogicContracts
{
    public interface IUserAttachmentLogic
    {
        UserAttachment[] GetAll();
        UserAttachment AddUser(string Login, string Password);
        bool AddUserRole(string  Login, string  Role);
    }
}
