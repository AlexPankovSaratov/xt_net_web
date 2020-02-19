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
    public class HDDUserAttachmentDao : IUserAttachmentDao
    {
        private static DirectoryInfo AllUserAttachmentFolder = new DirectoryInfo(@"E:\AllUserAttachment");
        private static string FileName = AllUserAttachmentFolder.FullName + @"\" + "JSonAllUserAttachment.txt";
        private static Dictionary<string, UserAttachment> _userAttachment;
        public HDDUserAttachmentDao()
        {
            if (!AllUserAttachmentFolder.Exists) AllUserAttachmentFolder.Create();
            using (FileStream fstream = new FileStream(FileName, FileMode.OpenOrCreate))
            {
                var reader = new StreamReader(fstream);
                string value = reader.ReadToEnd();
                if (value == "")
                {
                    _userAttachment = new Dictionary<string, UserAttachment>();
                }
                else _userAttachment = JsonConvert.DeserializeObject<Dictionary<string, UserAttachment>>(value);
                reader.Close();
            }
        }

        public bool Add(UserAttachment user)
        {
            _userAttachment.Add(user.Login, user);
            Save();
            return true;
        }

        public bool AddUserRole(string Login, string RoleName)
        {
            _userAttachment.TryGetValue(Login, out UserAttachment user);
            user.Roles.Add(RoleName);
            Save();
            return true;
        }
        public IEnumerable<UserAttachment> GetAll()
        {
            foreach (var item in _userAttachment.Values)
            {
                yield return item;
            }
        }

        private void Save()
        {
            string StrJson = JsonConvert.SerializeObject(_userAttachment);
            using (FileStream fstream = new FileStream(FileName, FileMode.Create))
            {
                var writer = new StreamWriter(fstream);
                writer.Write(StrJson);
                writer.Close();
            }
        }
    }
}
