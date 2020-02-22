using Epam.ListUsers.DalContracts;
using Epam.ListUsers.Entities;
using Epam.ListUsers.Ioc;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.ListUsers.SqlDal
{
    public class SqlAwardDao : IAdwardDao
    {
        private string conStr = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
        public bool AddAdward(Adward adward)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = con.CreateCommand();
                con.Open();
                cmd.CommandText = "dbo.AddAward";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                var IdParam = new SqlParameter()
                {
                    DbType = System.Data.DbType.Int32,
                    ParameterName = "@Id",
                    Value = adward.Id,
                    Direction = System.Data.ParameterDirection.Output,
                };
                var TitleParam = new SqlParameter()
                {
                    DbType = System.Data.DbType.String,
                    ParameterName = "@Title",
                    Value = adward.Title,
                };
                cmd.Parameters.Add(IdParam);
                cmd.Parameters.Add(TitleParam);

                cmd.ExecuteNonQuery();
            }
            return true;
        }

        public bool AddAdwardImage(int IdAdward, byte[] ByteArrayImage)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = con.CreateCommand();
                con.Open();
                cmd.CommandText = "dbo.AddAwardImage";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                var IdParam = new SqlParameter()
                {
                    DbType = System.Data.DbType.Int32,
                    ParameterName = "@Id",
                    Value = IdAdward,
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

        public byte[] GetAdwardImage(int IdAdward)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = con.CreateCommand();
                con.Open();
                cmd.CommandText = "dbo.GetAwardImage";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                var IdParam = new SqlParameter()
                {
                    DbType = System.Data.DbType.Int32,
                    ParameterName = "@Id",
                    Value = IdAdward,
                };
                cmd.Parameters.Add(IdParam);
                SqlDataReader sqlDataReader = cmd.ExecuteReader();
                byte[] ImageAward = new byte[] { };
                while (sqlDataReader.Read())
                {
                    if (!System.DBNull.Value.Equals(sqlDataReader["Image"])) ImageAward = Convert.FromBase64String((string)sqlDataReader["Image"]);
                }
                return ImageAward;
            }
        }

        public IEnumerable<Adward> GetAll()
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = con.CreateCommand();
                con.Open();
                cmd.CommandText = "dbo.GetAllAward";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader sqlDataReader = cmd.ExecuteReader();
                User[] users = new User[] { };
                while (sqlDataReader.Read())
                {
                    int Id = (int)sqlDataReader["Id"];
                    string Title = (string)sqlDataReader["Title"];
                    Adward award = new Adward { Id = Id, Title = Title};
                    yield return award;
                }
            }
        }

        public string GetTitleAdward(int ID)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = con.CreateCommand();
                con.Open();
                cmd.CommandText = "dbo.GetAwardTitle";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                var IdParam = new SqlParameter()
                {
                    DbType = System.Data.DbType.Int32,
                    ParameterName = "@Id",
                    Value = ID,
                };
                cmd.Parameters.Add(IdParam);
                SqlDataReader sqlDataReader = cmd.ExecuteReader();
                string TitleAward = "";
                while (sqlDataReader.Read())
                {
                    TitleAward = (string)sqlDataReader["Title"];
                }
                return TitleAward;
            }
        }

        public bool RemoveAdward(int Idadward)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = con.CreateCommand();
                con.Open();
                cmd.CommandText = "dbo.RemoveAward";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                var IdParam = new SqlParameter()
                {
                    DbType = System.Data.DbType.Int32,
                    ParameterName = "@Id",
                    Value = Idadward,
                };
                cmd.Parameters.Add(IdParam);
                cmd.ExecuteNonQuery();
            }
            DependencyResolver.UserDao.RemoveAdwardAllUsers(Idadward);
            return true;
        }

        public bool RemoveAdwardImage(int IdAdward)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = con.CreateCommand();
                con.Open();
                cmd.CommandText = "dbo.AddAwardImage";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                var IdParam = new SqlParameter()
                {
                    DbType = System.Data.DbType.Int32,
                    ParameterName = "@Id",
                    Value = IdAdward,
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
