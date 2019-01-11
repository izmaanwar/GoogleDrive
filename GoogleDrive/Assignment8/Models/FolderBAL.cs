using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace Assignment8.Models
{
    public class FolderBAL
    {
        public  int Save(FolderDTO dto)
        {

            int uid = 0;
            string connString = @"Data Source=AZAZ-PC\SQLEXPRESS2012 ;Initial Catalog=Assignment8 ; User Id=sa;Password=1234";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                String sqlQuery = "";
                {
                    sqlQuery = String.Format("INSERT INTO dbo.Folder(Name,ParentFolderId,CreatedBy,createdOn,IsActive) VALUES('{0}','{1}','{2}','{3}','{4}');",
                        dto.Name, dto.ParentFolderId, dto.CreatedBy, dto.CreatedOn, dto.IsActive);
                }
                SqlCommand command = new SqlCommand(sqlQuery, conn);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    uid = reader.GetInt32(reader.GetOrdinal("ID"));
                }
            }

            return uid;
                
            }


       /* public  FileDTO GetFileByUniqueID(string uniqueName)
        {

           
        }*/
        public int SaveFile(FileDTO dto)
        {

            int uid = 0;
            string connString = @"Data Source=AZAZ-PC\SQLEXPRESS2012 ;Initial Catalog=Assignment8 ; User Id=sa;Password=1234";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                String sqlQuery = "";
                {
                    sqlQuery = String.Format("INSERT INTO dbo.Files(Name,parentFolderId,FileExt,FileSizeInKB,CreatedBy,UploadedOn,IsActive,ContentTpye,Actualname) VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}');",
                        dto.FileUniqueName,dto.ParentFolderid,dto.FileExt,dto.Size,dto.CreatedBy,dto.UploadedOn,dto.IsActive,dto.ContentTpye,dto.fileActualName);
                }
                SqlCommand command = new SqlCommand(sqlQuery, conn);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    uid = reader.GetInt32(reader.GetOrdinal("ID"));
                }
            }

            return uid;

        }

        public int DeleteProduct(int pid)
        {
            string connString = @"Data Source=AZAZ-PC\SQLEXPRESS2012 ;Initial Catalog=Assignment8 ; User Id=sa;Password=1234";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                string sqlQuery = String.Format("delete from dbo.Folder where ID = '{0}'",pid);
                //string query = "select * from dbo.Users where Login='" + login + "' ANd Password='" + password + "' AND Email='" + email + "' ";
                SqlCommand command = new SqlCommand(sqlQuery, conn);

                //SqlCommand command = new SqlCommand(sqlQuery, _conn);
                var count = command.ExecuteNonQuery();
                return count;

            }

        }

        public int deletefolder(int pid)
        {
            string connString = @"Data Source=AZAZ-PC\SQLEXPRESS2012 ;Initial Catalog=Assignment8 ; User Id=sa;Password=1234";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                string sqlQuery = String.Format("delete from dbo.Folder where ParentFolderId = '{0}'", pid);
                //string query = "select * from dbo.Users where Login='" + login + "' ANd Password='" + password + "' AND Email='" + email + "' ";
                SqlCommand command = new SqlCommand(sqlQuery, conn);

                //SqlCommand command = new SqlCommand(sqlQuery, _conn);
                var count = command.ExecuteNonQuery();
                return count;

            }

        }
        public int Deletefile(int pid)
        {
            string connString = @"Data Source=AZAZ-PC\SQLEXPRESS2012 ;Initial Catalog=Assignment8 ; User Id=sa;Password=1234";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                string sqlQuery = String.Format("delete from dbo.Files where parentFolderId = '{0}'",
                        pid);
                //string query = "select * from dbo.Users where Login='" + login + "' ANd Password='" + password + "' AND Email='" + email + "' ";
                SqlCommand command = new SqlCommand(sqlQuery, conn);

                //SqlCommand command = new SqlCommand(sqlQuery, _conn);
                var count = command.ExecuteNonQuery();
                return count;

            }

        }

        public int   deletefile(int pid)
        {
            string connString = @"Data Source=AZAZ-PC\SQLEXPRESS2012 ;Initial Catalog=Assignment8 ; User Id=sa;Password=1234";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                String sqlQuery = String.Format("delete dbo.Files Where ID={0}", pid);
               
                SqlCommand command = new SqlCommand(sqlQuery, conn);

                //SqlCommand command = new SqlCommand(sqlQuery, _conn);
                var count = command.ExecuteNonQuery();
                return count;

            }
        }

        public string getName(int pid)
        {   
            string name="";
            string connString = @"Data Source=AZAZ-PC\SQLEXPRESS2012 ;Initial Catalog=Assignment8 ; User Id=sa;Password=1234";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                String sqlQuery = String.Format("select  Name from  dbo.Folder Where ID={0}", pid);

                SqlCommand command = new SqlCommand(sqlQuery, conn);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    name = reader.GetString(reader.GetOrdinal("Name"));
                }
            }
            return name;
        }
         public combine  combine(int parid)
        {
            combine cm = new combine();
            cm.allfiles = GetAllParFiles(parid);
            cm.allfolders = GetAllParFolders(parid);
            return cm;

            

        }
         public FileDTO GetFileByUniqueID(string UniqueName)
         {

             FileDTO dto = new FileDTO();
             string connString = @"Data Source=AZAZ-PC\SQLEXPRESS2012 ;Initial Catalog=Assignment8 ; User Id=sa;Password=1234";
             using (SqlConnection conn = new SqlConnection(connString))
             {
                 conn.Open();
                 var query = String.Format("Select f.ID ,f.Name,f.parentFolderId,f.FileExt,f.FileSizeInKB ,f.CreatedBy,f.UploadedOn,f.ContentTpye  from Users u , Files f where u.UserID = f.CreatedBy and  f.Name = '{0}';", UniqueName);

                 SqlCommand command = new SqlCommand(query, conn);
                 SqlDataReader reader = command.ExecuteReader();
                 if(reader.Read())
                 {
                     dto.ID = reader.GetInt32(reader.GetOrdinal("ID"));
                     dto.FileExt = reader.GetString(reader.GetOrdinal("FileExt"));
                     dto.Size = reader.GetInt32(reader.GetOrdinal("FileSizeInKB"));
                     dto.FileUniqueName = reader.GetString(reader.GetOrdinal("Name"));
                     dto.ContentTpye = reader.GetString(reader.GetOrdinal("ContentTpye"));
                    
                 }

             }

             return dto;
             
         }
        public  List<FolderDTO> GetAllFolders()
        {
            List<FolderDTO> list = new List<FolderDTO>();
            string connString = @"Data Source=AZAZ-PC\SQLEXPRESS2012 ;Initial Catalog=Assignment8 ; User Id=sa;Password=1234";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                var query = String.Format("Select f.ID , f.Name, f.ParentFolderId ,f.CreatedBy,f.CreatedOn  from Users u , Folder f where u.UserID = f.CreatedBy and f.ParentFolderId = '{0}';",0);

                SqlCommand command = new SqlCommand(query, conn);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var dto = FillDTO(reader);
                    if (dto != null)
                    {
                        list.Add(dto);
                    }
                }
            }
                return list;
          }

      
 


        public List<FolderDTO> GetAllParFolders(int parid)
        {    
            FolderDTO dto =new FolderDTO();
            List<FolderDTO> list = new List<FolderDTO>();
            string connString = @"Data Source=AZAZ-PC\SQLEXPRESS2012 ;Initial Catalog=Assignment8 ; User Id=sa;Password=1234";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                var query = String.Format("Select f.ID , f.Name, f.ParentFolderId ,f.CreatedBy,f.CreatedOn  from Users u , Folder f where u.UserID = f.CreatedBy and f.ParentFolderId = '{0}';" ,parid);

                SqlCommand command = new SqlCommand(query, conn);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var dto1 = FillDTO(reader);
                   
                    if (dto1 != null)
                    {
                        list.Add(dto1);
                    }
                }
                 
            }
           
            return list;
        }

        public List<FolderDTO> getsubfolder(int folderid)
        {
            FolderDTO dto = new FolderDTO();
            List<FolderDTO> list = new List<FolderDTO>();
            string connString = @"Data Source=AZAZ-PC\SQLEXPRESS2012 ;Initial Catalog=Assignment8 ; User Id=sa;Password=1234";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                var query = String.Format("Select f.ID , f.Name, f.ParentFolderId ,f.CreatedBy,f.CreatedOn  from Users u , Folder f where u.UserID = f.CreatedBy and f.ParentFolderId = '{0}';", folderid);

                SqlCommand command = new SqlCommand(query, conn);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var dto1 = FillDTO(reader);

                    if (dto1 != null)
                    {
                        list.Add(dto1);
                    }
                }

            }

            return list;
        }
        public List<FileDTO> GetAllParFiles(int parid)
        {
            List<FileDTO> list = new List<FileDTO>();
            string connString = @"Data Source=AZAZ-PC\SQLEXPRESS2012 ;Initial Catalog=Assignment8 ; User Id=sa;Password=1234";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                var query = String.Format("Select f.ID , f.Name, f.parentFolderId,f.FileExt,f.FileSizeInKB ,f.CreatedBy,f.UploadedOn  from Users u , Files f where u.UserID = f.CreatedBy and f.parentFolderId = '{0}';", parid);

                SqlCommand command = new SqlCommand(query, conn);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var dto = FillDTO1(reader);
                    if (dto != null)
                    {
                        list.Add(dto);
                    }
                }
                
            }
            return list;
        }
        public List<FileDTO> getsubfiles(int parid)
        {
            List<FileDTO> list = new List<FileDTO>();
            string connString = @"Data Source=AZAZ-PC\SQLEXPRESS2012 ;Initial Catalog=Assignment8 ; User Id=sa;Password=1234";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                var query = String.Format("Select f.ID , f.Name, f.parentFolderId,f.FileExt,f.FileSizeInKB ,f.CreatedBy,f.UploadedOn  from Users u , Files f where u.UserID = f.CreatedBy and f.parentFolderId = '{0}';", parid);

                SqlCommand command = new SqlCommand(query, conn);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var dto = FillDTO1(reader);
                    if (dto != null)
                    {
                        list.Add(dto);
                    }
                }

            }
            return list;
        }
        public List<FileDTO> search(string name)
        {
            List<FileDTO> list = new List<FileDTO>();
            string conn1 = @"Data Source=AZAZ-PC\SQLEXPRESS2012 ;Initial Catalog=Assignment8 ; User Id=sa;Password=1234";
            using (SqlConnection conn = new SqlConnection(conn1))
            {
                conn.Open();
                String sqlQuery = String.Format("Select  f.ID, f.Name  from Users u , Files f where u.UserID = f.CreatedBy and f.Actualname  like '%'+@name+'%' ");
                SqlCommand com = new SqlCommand(sqlQuery, conn);
                SqlParameter parr = new SqlParameter();
                // add the userid
                parr.ParameterName = "name";
                parr.SqlDbType = System.Data.SqlDbType.VarChar;
                parr.Value = name;
                com.Parameters.Add(parr);
              

                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    var dto = FillDTO2(reader);
                    if (dto != null)
                    {
                        list.Add(dto);
                    }
                }
                   return list;
            }
           
           
           
        }
        private  FolderDTO FillDTO(SqlDataReader reader)
        {
            var dto = new FolderDTO();
            dto.FolderId = reader.GetInt32(0);
            dto.Name = reader.GetString(1);
            dto.ParentFolderId = reader.GetInt32(2);
            dto.CreatedBy = reader.GetInt32(3);
            dto.CreatedOn = reader.GetDateTime(4);
           
            return dto;
        }
        private FileDTO FillDTO1(SqlDataReader reader)
        {
            var dto = new FileDTO();
            dto.ID = reader.GetInt32(0);
            dto.FileUniqueName = reader.GetString(1);
            dto.ParentFolderid = reader.GetInt32(2);
            dto.FileExt = reader.GetString(3);
            dto.Size = reader.GetInt32(4);
            dto.CreatedBy = reader.GetInt32(5);
            dto.UploadedOn = reader.GetDateTime(6);
            
            return dto;
        }

        private FileDTO FillDTO2(SqlDataReader reader)
        {
            var dto = new FileDTO();

            dto.ID = reader.GetInt32(0);
            dto.FileUniqueName = reader.GetString(1);

            return dto;
        }
    
    }
    
}