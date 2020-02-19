using Epam.ListUsers.DalContracts;
using Epam.ListUsers.Entities;
using Epam.ListUsers.Ioc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.ListUsers.HddDal
{
    public class HDDAdwardDao : IAdwardDao
    {
        private static DirectoryInfo AllAdwardsFolder = new DirectoryInfo(@"E:\AllUsers");
        private static string FileName = AllAdwardsFolder.FullName + @"\" + "JSonAllAdwards.txt";
        private static Dictionary<int, Adward> _adwards;
        public HDDAdwardDao()
        {
            if (!AllAdwardsFolder.Exists) AllAdwardsFolder.Create();
            using (FileStream fstream = new FileStream(FileName, FileMode.OpenOrCreate))
            {
                var reader = new StreamReader(fstream);
                string value = reader.ReadToEnd();
                if (value == "")
                {
                    _adwards = new Dictionary<int, Adward>();
                }
                else _adwards = JsonConvert.DeserializeObject<Dictionary<int, Adward>>(value);
                reader.Close();
            }
        }
        public bool AddAdward(Adward adward)
        {
            _adwards.Add(_adwards.Keys.Count + 1, adward);
            Save();
            return true;
        }
        public bool RemoveAdward(int Idadward)
        {
            _adwards.Remove(Idadward);
            Ioc.DependencyResolver.UserDao.RemoveAdwardAllUsers(Idadward);
            Save();
            return true;
        }

        public string GetTitleAdward(int ID)
        {
            _adwards.TryGetValue(ID, out Adward adward);
            return adward.Title;
        }

        public IEnumerable<Adward> GetAll()
        {
            foreach (var item in _adwards.Values)
            {
                yield return item;
            }
        }
        private void Save()
        {
            string StrJson = JsonConvert.SerializeObject(_adwards);
            using (FileStream fstream = new FileStream(FileName, FileMode.Create))
            {
                var writer = new StreamWriter(fstream);
                writer.Write(StrJson);
                writer.Close();
            }
        }

        public bool AddAdwardImage(int IdAdward, byte[] ByteArrayImage)
        {
            _adwards.TryGetValue(IdAdward, out Adward adward);
            adward.ImageAdward = ByteArrayImage;
            Save();
            return true;
        }

        public bool RemoveAdwardImage(int IdAdward)
        {
            _adwards.TryGetValue(IdAdward, out Adward adward);
            adward.ImageAdward = new byte[] { };
            Save();
            return true;
        }

        public byte[] GetAdwardImage(int IdAdward)
        {
            _adwards.TryGetValue(IdAdward, out Adward adward);
            return adward.ImageAdward;
        }
    }
}
