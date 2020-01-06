using Epam.ListUsers.DalContracts;
using Epam.ListUsers.HddDal;
using Epam.ListUsers.Logic;
using Epam.ListUsers.LogicContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.ListUsers.Ioc
{
    public static class DependencyResolver
    {
        private static IUserDao _userDao;
        public static IUserDao UserDao => _userDao ?? (_userDao = new HDDUserDao());
        private static IUserLogic _userLogic;
        public static IUserLogic UserLogic => _userLogic ?? (_userLogic = new UserLogic(UserDao));

        private static IAdwardDao _adwardDao;
        public static IAdwardDao AdwardDao => _adwardDao ?? (_adwardDao = new HDDAdwardDao());
        private static IAdwardLogic _adwarLogic;
        public static IAdwardLogic AdwardLogic => _adwarLogic ?? (_adwarLogic = new AdwardLogic(AdwardDao));
    }
}
