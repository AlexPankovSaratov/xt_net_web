using Epam.ListUsers.DalContracts;
using Epam.ListUsers.Entities;
using Epam.ListUsers.LogicContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.ListUsers.Logic
{
    public class AdwardLogic : IAdwardLogic
    {
        private readonly IAdwardDao _adwardDao;
        public AdwardLogic(IAdwardDao adwardDao)
        {
            _adwardDao = adwardDao;
        }

        public Adward AddAdward(string Title)
        {
            Adward adward = new Adward {Id = _adwardDao.GetAll().Count() + 1 ,Title = Title };
            if (_adwardDao.AddAdward(adward))
            {
                return adward;
            }
            throw new ArgumentException("Error on adward added");
        }

        public bool AddAdwardImage(int IdAdward, byte[] ByteArrayImage)
        {
            if (ByteArrayImage.Length < 1) return false;
            return _adwardDao.AddAdwardImage(IdAdward, ByteArrayImage);
        }

        public byte[] GetAdwardImage(int IdAdward)
        {
            return _adwardDao.GetAdwardImage(IdAdward);
        }

        public Adward[] GetAll()
        {
            return _adwardDao.GetAll().ToArray();
        }

        public string GetTitleAdward(int ID)
        {
            return _adwardDao.GetTitleAdward(ID);
        }

        public bool RemoveAdward(int ID)
        {
            return _adwardDao.RemoveAdward(ID);
        }

        public bool RemoveAdwardImage(int IdAdward)
        {
            return _adwardDao.RemoveAdwardImage(IdAdward);
        }
    }
}
