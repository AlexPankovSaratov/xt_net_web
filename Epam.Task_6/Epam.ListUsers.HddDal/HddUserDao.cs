using Epam.ListUsers.DalContracts;
using Epam.ListUsers.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.ListUsers.HddDal
{
    public class HddUserDao : IUserDao
    {
        private readonly Dictionary<int,User> users = new Dictionary<int, User>();
        private int maxID;
        public void MemoryUserDao()
        {
            maxID = 0;
        }
        public bool Add(User user)
        {
            users.Add(++maxID, user);
            return true;
        }

        public IEnumerable<User> GetAll()
        {
            foreach (var item in users.Values)
            {
                yield return item;
            }
        }

        public bool Remove(int ID)
        {
            return users.Remove(ID);
        }
    }
}
