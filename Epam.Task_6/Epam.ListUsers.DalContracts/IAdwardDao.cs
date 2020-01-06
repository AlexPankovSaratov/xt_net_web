﻿using Epam.ListUsers.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.ListUsers.DalContracts
{
    public interface IAdwardDao
    {
        bool AddAdward(Adward adward);
        IEnumerable<Adward> GetAll();
        string GetTitleAdward(int ID);
    }
}
