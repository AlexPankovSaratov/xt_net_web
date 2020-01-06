using Epam.ListUsers.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.ListUsers.LogicContracts
{
    public interface IAdwardLogic
    {
        Adward[] GetAll();
        Adward AddAdward(string Title);
        string GetTitleAdward(int ID);
    }
}
