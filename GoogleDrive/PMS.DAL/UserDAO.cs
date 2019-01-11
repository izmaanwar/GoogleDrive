using PMS.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.DAL
{
    public static class UserDAO
    {
        public static int Save(UserDTO dto)
        {
            String sqlQuery = "";
            if (dto.UserID > 0)
            {
                sqlQuery = String.Format("Update dbo.Users Set Name='{0}', PictureName='{1}',Login= '{2}',Password= '{3}' ,Email= '{4}' Where UserID= '{5}'" ,
                    dto.Name, dto.PictureName,dto.Login,dto.Password ,dto.Email, dto.UserID);
            }
            else
            {
                sqlQuery = String.Format("INSERT INTO dbo.Users(Name, Login,Password, PictureName,Email, IsAdmin,IsActive) VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}')",
                    dto.Name, dto.Login, dto.Password, dto.PictureName , dto.Email ,  0,  1);
            }

            using (DBHelper helper = new DBHelper())
            {
                return helper.ExecuteQuery(sqlQuery);
            }
        }

        public static int isValidEmail(string email)
        {
            
            string sqlQuery = "SELECT UserID ,password FROM Users WHERE Email='{email}'";
            using (DBHelper helper = new DBHelper())
            {
                var reader = helper.ExecuteReader(sqlQuery);
                if (reader.Read())
                {
                    int id = reader.GetInt32(reader.GetOrdinal("UserID"));
                    return id;
                }
                else
                    return -1;
            } 
         }
        public static int UpdatePassword(UserDTO dto)
        {
            String sqlQuery = "";
            sqlQuery = String.Format("Update dbo.Users Set Password='{0}' Where UserID={1}", dto.Password, dto.UserID);


            using (DBHelper helper = new DBHelper())
            {
                return helper.ExecuteQuery(sqlQuery);
            }
        }

        public static UserDTO ValidateUser(String pLogin, String pPassword)
        {
            var query = String.Format("Select * from dbo.Users Where Login='{0}' and Password='{1}'", pLogin, pPassword);

            using (DBHelper helper = new DBHelper())
            {
                var reader = helper.ExecuteReader(query);

                UserDTO dto = null;

                if (reader.Read())
                {
                    dto = FillDTO(reader);
                }

                return dto;
            }
        }

        public static UserDTO GetUserById(int pid)
        {

            var query = String.Format("Select * from dbo.Users Where UserId={0}", pid);

            using (DBHelper helper = new DBHelper())
            {
                var reader = helper.ExecuteReader(query);

                UserDTO dto = null;

                if (reader.Read())
                {
                    dto = FillDTO(reader);
                }

                return dto;
            }
        }
        public static  Boolean UserExist( string login,  string password,string email)
        {


            string connString = @"Data Source=AZAZ-PC\SQLEXPRESS2012 ;Initial Catalog=Assignment8 ; User Id=sa;Password=1234";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                string query = "select * from dbo.Users where Login='" + login + "' ANd Password='" + password + "' AND Email='" + email + "' ";
                SqlCommand command = new SqlCommand(query, conn);
                SqlDataReader reader = command.ExecuteReader();
                if(reader.Read())
                {
                    return true;
                }
                return false;

            }
        }

        public static int getUserID( string login,  string password)
        {
              int uid = 0;
            string connString = @"Data Source=AZAZ-PC\SQLEXPRESS2012 ;Initial Catalog=Assignment8 ; User Id=sa;Password=1234";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                var query = String.Format("Select UserID from dbo.Users Where Login= '{0}' and password= '{1}' ", login,password);
                SqlCommand command = new SqlCommand(query, conn);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    uid = reader.GetInt32(reader.GetOrdinal("UserID"));
                }
            }

            return uid;
        }

        public static List<UserDTO> GetAllUsers()
        {
            using (DBHelper helper = new DBHelper())
            {
                var query = "Select * from dbo.Users Where IsActive = 1;";
                var reader = helper.ExecuteReader(query);
                List<UserDTO> list = new List<UserDTO>();

                while (reader.Read())
                {
                    var dto = FillDTO(reader);
                    if (dto != null)
                    {
                        list.Add(dto);
                    }
                }

                return list;
            }
        }

        public static int DeleteUser(int pid)
        {
            String sqlQuery = String.Format("Update dbo.Users Set IsActive=0 Where UserID={0}", pid);

            using (DBHelper helper = new DBHelper())
            {
                return helper.ExecuteQuery(sqlQuery);
            }
        }

        private static UserDTO FillDTO(SqlDataReader reader)
        {
            var dto = new UserDTO();
            dto.UserID = reader.GetInt32(0);
            dto.Name = reader.GetString(1);
            dto.Login = reader.GetString(2);
            dto.Password = reader.GetString(3);
            
            dto.Email = reader.GetString(4);
            return dto;
        }
    }
}
