using Epam.ListUsers.DalContracts;
using Epam.ListUsers.HddDal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.ListUsers.Logic
{
    internal static class DaoProviser
    {
        static DaoProviser()
        {
            UserDao =  new HddUserDao();
        }
        public static IUserDao UserDao { get; }
    }
}
