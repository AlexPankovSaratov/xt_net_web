using Epam.ListUsers.DalContracts;
using Epam.ListUsers.HddDal;
using Epam.ListUsers.Logic;
using Epam.ListUsers.LogicContracts;
using Epam.ListUsers.SqlDal;
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
        public static IUserDao UserDao => _userDao ?? (_userDao = new SqlUserDao());
        private static IUserLogic _userLogic;
        public static IUserLogic UserLogic => _userLogic ?? (_userLogic = new UserLogic(UserDao));

        private static IAdwardDao _adwardDao;
        public static IAdwardDao AdwardDao => _adwardDao ?? (_adwardDao = new SqlAwardDao());
        private static IAdwardLogic _adwarLogic;
        public static IAdwardLogic AdwardLogic => _adwarLogic ?? (_adwarLogic = new AdwardLogic(AdwardDao));

        private static IUserAttachmentDao _userAttachmentDao;
        public static IUserAttachmentDao UserAttachmentDao => _userAttachmentDao ?? (_userAttachmentDao = new SqlUserAttachmentDao());
        private static IUserAttachmentLogic _userAttachmentLogic;
        public static IUserAttachmentLogic UserAttachmentLogic => _userAttachmentLogic ?? (_userAttachmentLogic = new UserAttachmentLogic(UserAttachmentDao));
    }
}
