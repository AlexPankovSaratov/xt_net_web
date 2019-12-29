using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.ListUsers.Entities;

namespace Epam.ListUsers.LogicContracts
{
    public interface IUserLogic
    {
        User[] GetAll();
        User AddUser(int ID, string Name, DateTime DateOfBirth, int Age);
        void RemovedUser(int ID);
    }
}
