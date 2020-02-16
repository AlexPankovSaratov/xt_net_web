using Epam.ListUsers.DalContracts;
using Epam.ListUsers.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.ListUsers.HddDal
{
    public class HDDUserDao : IUserDao
    {
        private static DirectoryInfo AllUsersFolder = new DirectoryInfo(@"E:\AllUsers");
        private static string FileName = AllUsersFolder.FullName + @"\" + "JSonAllUsers.txt";
        private static Dictionary<int,User> _users;
        public HDDUserDao()
        {
            if (!AllUsersFolder.Exists) AllUsersFolder.Create();
            using (FileStream fstream = new FileStream(FileName, FileMode.OpenOrCreate))
            {
                var reader = new StreamReader(fstream);
                string value = reader.ReadToEnd();
                if (value == "")
                {
                    _users = new Dictionary<int, User>();
                }
                else _users = JsonConvert.DeserializeObject<Dictionary<int, User>>(value);
                reader.Close();
            }
        }
        public bool Add(User user)
        {
            _users.Add(_users.Keys.Count + 1, user);
            Save();
            return true;
        }
        public bool RemoveAdwardAllUsers(int Idadward)
        {
            foreach (User item in Ioc.DependencyResolver.UserDao.GetAll())
            {
                item.AdwardsID.Remove(Idadward);
            }
            Save();
            return true;
        }
        public bool AddUserAdward(int iDUser, int iDAsward)
        {
            _users.TryGetValue(iDUser, out User user);
            user.AdwardsID.Add(iDAsward);
            Save();
            return true;
        }

        public IEnumerable<User> GetAll()
        {
            foreach (var item in _users.Values)
            {
                yield return item;
            }
        }

        public bool Remove(int ID)
        {
            bool result = _users.Remove(ID);
            if(result) Save();
            return result;
        }
        private void Save()
        {
            string StrJson = JsonConvert.SerializeObject(_users);
            using (FileStream fstream = new FileStream(FileName, FileMode.Create))
            {
                var writer = new StreamWriter(fstream);
                writer.Write(StrJson);
                writer.Close();
            }
        }  
    }
}
