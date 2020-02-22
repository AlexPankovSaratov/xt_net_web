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
    public class SqlUserDao : IUserDao
    {
        private string conStr = ConfigurationManager.ConnectionStrings["db"].ConnectionString;

        public bool Add(User user)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = con.CreateCommand();
                con.Open();
                cmd.CommandText = "dbo.AddUser";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                var IdParam = new SqlParameter()
                {
                    DbType = System.Data.DbType.Int32,
                    ParameterName = "@Id",
                    Value = user.Id,
                    Direction = System.Data.ParameterDirection.Output,
                };
                var NameParam = new SqlParameter()
                {
                    DbType = System.Data.DbType.String,
                    ParameterName = "@Name",
                    Value = user.Name,
                };
                var DateOfBirthParam = new SqlParameter()
                {
                    DbType = System.Data.DbType.DateTime,
                    ParameterName = "@DateOfBirth",
                    Value = user.DateOfBirth,
                };
                var AgeParam = new SqlParameter()
                {
                    DbType = System.Data.DbType.Int32,
                    ParameterName = "@Age",
                    Value = user.Age,
                };
                cmd.Parameters.Add(IdParam);
                cmd.Parameters.Add(NameParam);
                cmd.Parameters.Add(DateOfBirthParam);
                cmd.Parameters.Add(AgeParam);
                cmd.ExecuteNonQuery();
            }
            return true;
        }

        public bool AddUserAdward(int iDUser, int iDAward)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = con.CreateCommand();
                con.Open();
                cmd.CommandText = "dbo.AddUserAward";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                var IdUserParam = new SqlParameter()
                {
                    DbType = System.Data.DbType.Int32,
                    ParameterName = "@IdUser",
                    Value = iDUser,
                };
                var IdAwardParam = new SqlParameter()
                {
                    DbType = System.Data.DbType.Int32,
                    ParameterName = "@IdAward",
                    Value = iDAward,
                };
                cmd.Parameters.Add(IdUserParam);
                cmd.Parameters.Add(IdAwardParam);

                cmd.ExecuteNonQuery();
            }
            return true;
        }

        public bool AddUserImage(int IDUser, byte[] ByteArrayImage)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = con.CreateCommand();
                con.Open();
                cmd.CommandText = "dbo.AddUserImage";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                var IdParam = new SqlParameter()
                {
                    DbType = System.Data.DbType.Int32,
                    ParameterName = "@Id",
                    Value = IDUser,
                };
                var ImageParam = new SqlParameter()
                {
                    DbType = System.Data.DbType.String,
                    ParameterName = "@Image",
                    Value = Convert.ToBase64String(ByteArrayImage),
                };
                cmd.Parameters.Add(IdParam);
                cmd.Parameters.Add(ImageParam);
                cmd.ExecuteNonQuery();
            }
            return true;
        }

        public IEnumerable<User> GetAll()
        {
            HashSet<User> users = new HashSet<User>();
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = con.CreateCommand();
                con.Open();
                cmd.CommandText = "dbo.GetAllUsers";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader sqlDataReader = cmd.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    int Id = (int)sqlDataReader["Id"];
                    string Name = (string)sqlDataReader["Name"];
                    DateTime Birthdate = (DateTime)sqlDataReader["DateOfBirth"];
                    int Age = (int)sqlDataReader["Age"];
                    HashSet<int> AdwardsID = new HashSet<int> { };
                    int Id_Award = 0;
                    if (!System.DBNull.Value.Equals(sqlDataReader["Id_Award"]))
                    {
                        Id_Award = (int)sqlDataReader["Id_Award"];
                        AdwardsID.Add(Id_Award);
                    }
                    byte[] ImageUser = new byte[] { };
                    if (!System.DBNull.Value.Equals(sqlDataReader["Image"])) ImageUser = Convert.FromBase64String((string)sqlDataReader["Image"]);
                    User user = new User { Id = Id, Name = Name, DateOfBirth = Birthdate, Age = Age, AdwardsID = AdwardsID, ImageUser = ImageUser };
                    User SerchUser = users.FirstOrDefault(element => element.Id == user.Id);
                    if (SerchUser != null && Id_Award != 0) SerchUser.AdwardsID.Add(Id_Award);
                    else users.Add(user);
                }
            }
            return users;
        }

        public byte[] GetUserImage(int IDUser)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = con.CreateCommand();
                con.Open();
                cmd.CommandText = "dbo.GetUserImage";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                var IdParam = new SqlParameter()
                {
                    DbType = System.Data.DbType.Int32,
                    ParameterName = "@Id",
                    Value = IDUser,
                };
                cmd.Parameters.Add(IdParam);
                SqlDataReader sqlDataReader = cmd.ExecuteReader();
                byte[] ImageUser = new byte[] { };
                while (sqlDataReader.Read())
                {
                    if (!System.DBNull.Value.Equals(sqlDataReader["Image"])) ImageUser = Convert.FromBase64String((string)sqlDataReader["Image"]);
                }
                return ImageUser;
            }
        }

        public bool Remove(int ID)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = con.CreateCommand();
                con.Open();
                cmd.CommandText = "dbo.RemoveUser";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                var IdParam = new SqlParameter()
                {
                    DbType = System.Data.DbType.Int32,
                    ParameterName = "@Id",
                    Value = ID,
                };
                cmd.Parameters.Add(IdParam);
                cmd.ExecuteNonQuery();
            }
            return true;
        }

        public bool RemoveAdwardAllUsers(int idadward)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = con.CreateCommand();
                con.Open();
                cmd.CommandText = "dbo.RemoveAdwardAllUsers";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                var IdParam = new SqlParameter()
                {
                    DbType = System.Data.DbType.Int32,
                    ParameterName = "@Id",
                    Value = idadward,
                };
                cmd.Parameters.Add(IdParam);
                cmd.ExecuteNonQuery();
            }
            return true;
        }

        public bool RemoveUserImage(int IDUser)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = con.CreateCommand();
                con.Open();
                cmd.CommandText = "dbo.AddUserImage";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                var IdParam = new SqlParameter()
                {
                    DbType = System.Data.DbType.Int32,
                    ParameterName = "@Id",
                    Value = IDUser,
                };
                var ImageParam = new SqlParameter()
                {
                    DbType = System.Data.DbType.String,
                    ParameterName = "@Image",
                    Value = System.DBNull.Value,
                };
                cmd.Parameters.Add(IdParam);
                cmd.Parameters.Add(ImageParam);
                cmd.ExecuteNonQuery();
            }
            return true;
        }
    }
}
