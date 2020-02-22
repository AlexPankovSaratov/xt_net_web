using Epam.ListUsers.DalContracts;
using Epam.ListUsers.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.ListUsers.SqlDal
{
    public class SqlUserAttachmentDao : IUserAttachmentDao
    {
        private string conStr = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
        public bool Add(UserAttachment user)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = con.CreateCommand();
                con.Open();
                cmd.CommandText = "dbo.AddUserAttachment";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                var LoginParam = new SqlParameter()
                {
                    DbType = System.Data.DbType.String,
                    ParameterName = "@Login",
                    Value = user.Login,
                };
                var PasswordParam = new SqlParameter()
                {
                    DbType = System.Data.DbType.String,
                    ParameterName = "@Password",
                    Value = user.Password,
                };
                cmd.Parameters.Add(LoginParam);
                cmd.Parameters.Add(PasswordParam);

                cmd.ExecuteNonQuery();
            }
            return true;
        }

        public bool AddUserRole(string Login, string RoleName)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = con.CreateCommand();
                con.Open();
                cmd.CommandText = "dbo.AddUserAttachmentRole";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                var LoginParam = new SqlParameter()
                {
                    DbType = System.Data.DbType.String,
                    ParameterName = "@Login",
                    Value = Login,
                };
                var RoleParam = new SqlParameter()
                {
                    DbType = System.Data.DbType.String,
                    ParameterName = "@Role",
                    Value = RoleName,
                };
                cmd.Parameters.Add(LoginParam);
                cmd.Parameters.Add(RoleParam);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    return false;
                }    
            }
            return true;
        }

        public IEnumerable<UserAttachment> GetAll()
        {
            HashSet<UserAttachment> userAttachment = new HashSet<UserAttachment>();
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = con.CreateCommand();
                con.Open();
                cmd.CommandText = "dbo.GetAllUsersAttachment";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader sqlDataReader = cmd.ExecuteReader();
                UserAttachment[] usersAttachment = new UserAttachment[] { };
                while (sqlDataReader.Read())
                {
                    string Login = (string)sqlDataReader["Login"];
                    string Password = (string)sqlDataReader["Password"];
                    string Role = "";
                    HashSet<string> Roles = new HashSet<string> { };
                    if (!System.DBNull.Value.Equals(sqlDataReader["Role"]))
                    {
                        Role = (string)sqlDataReader["Role"];
                        Roles.Add(Role);
                    }
                    UserAttachment user = new UserAttachment {Login = Login, Password = Password , Roles = Roles };
                    UserAttachment SerchUser = userAttachment.FirstOrDefault(element => element.Login == user.Login);
                    if (SerchUser != null && Role != "") SerchUser.Roles.Add(Role);
                    else userAttachment.Add(user);
                }
            }
            return userAttachment;
        }
    }
}
