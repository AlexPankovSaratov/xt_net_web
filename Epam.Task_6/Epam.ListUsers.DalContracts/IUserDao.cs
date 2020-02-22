using Epam.ListUsers.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.ListUsers.DalContracts
{
    public interface IUserDao
    {
        bool Add(User user);
        bool Remove(int ID);
        IEnumerable<User> GetAll();
        bool AddUserAdward(int iDUser, int iDAward);
        bool RemoveAdwardAllUsers(int idadward);
        bool AddUserImage(int IDUser, byte[] ByteArrayImage);
        bool RemoveUserImage(int IDUser);
        byte[] GetUserImage(int IDUser);
    }
}
