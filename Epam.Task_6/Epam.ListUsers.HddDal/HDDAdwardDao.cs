﻿using Epam.ListUsers.DalContracts;
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
    }
}