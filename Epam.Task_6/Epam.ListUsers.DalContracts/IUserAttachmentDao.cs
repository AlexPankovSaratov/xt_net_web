using Epam.ListUsers.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.ListUsers.DalContracts
{
    public interface IUserAttachmentDao
    {
        bool Add(UserAttachment user);
        IEnumerable<UserAttachment> GetAll();
        bool AddUserRole(string Login, string RoleName);
    }
}
