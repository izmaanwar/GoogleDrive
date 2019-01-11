using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.Entities;
using System.Data.SqlClient;

namespace PMS.DAL
{
    public static class ProductDAO
    {
        public static int Save(FolderDTO dto)
        {
            using (DBHelper helper = new DBHelper())
            {
               /* String sqlQuery = "";
                if (dto.ProductID > 0)
                {
                    sqlQuery = String.Format("Update dbo.Products Set dName='{0}',Price='{1}',PictureName='{2}',ModifiedOn='{3}',ModifiedBy='{4}' Where ProductID={5}",
                        dto.Name, dto.Price, dto.PictureName, dto.ModifiedOn, dto.ModifiedBy, dto.ProductID);
                    helper.ExecuteQuery(sqlQuery);
                    return dto.ProductID;
                }
                else
                {
                    sqlQuery = String.Format("INSERT INTO dbo.Products(dName, Price, PictureName, CreatedOn, CreatedBy,IsActive) VALUES('{0}','{1}','{2}','{3}','{4}',{5}); Select @@IDENTITY; Select  u.Name from Users u , Products d where u.UserID = d.CreatedBy;",
                        dto.Name, dto.Price, dto.PictureName, dto.CreatedOn, dto.CreatedBy, 1);

                    var obj = helper.ExecuteScalar(sqlQuery);
                    return Convert.ToInt32(obj);
                }*/
                return 1;
            }
        }
        public static FolderDTO GetProductById(int pid)
        {
            var query = String.Format("Select * from dbo.Products Where ProductId={0}", pid);

            using (DBHelper helper = new DBHelper())
            {
                var reader = helper.ExecuteReader(query);

                FolderDTO dto = null;

                if (reader.Read())
                {
                    dto = FillDTO(reader);
                }

                return dto;
            }
        }

        public static List<FolderDTO> GetAllProducts(Boolean pLoadComments=false)
        {
            var query = "Select d.ProductID , d.dName, d.Price  ,d.PictureName ,d.CreatedON,d.CreatedBy , u.Name from Users u , Products d where u.UserID = d.CreatedBy;";

            using (DBHelper helper = new DBHelper())
            {
                var reader = helper.ExecuteReader(query);
                List<FolderDTO> list = new List<FolderDTO>();

               /* while (reader.Read())
                {
                    var dto = new FolderDTO();
                    dto.ProductID = reader.GetInt32(0);
                    dto.Name = reader.GetString(1);
                    dto.Price = reader.GetDouble(2);
                    dto.PictureName = reader.GetString(3);
                    dto.CreatedOn = reader.GetDateTime(4);
                    dto.CreatedBy = reader.GetInt32(5);
                    dto.UserName = reader.GetString(reader.GetOrdinal("Name"));
                    
                    list.Add(dto);
                }
                if (pLoadComments == true)
                {
                    //var commentsList = CommentDAO.GetAllComments();

                    var commentsList = CommentDAO.GetTopComments(2);

                    foreach (var prod in list)
                    {
                        List<CommentDTO> prodComments = commentsList.Where(c => c.ProductID == prod.ProductID).ToList();
                        prod.Comments = prodComments;
                    }
                }*/
                return list;
            }
        }

        public static int DeleteProduct(int pid)
        {
            String sqlQuery = String.Format("delete dbo.Products Where ProductID={0}", pid);

            using (DBHelper helper = new DBHelper())
            {
                return helper.ExecuteQuery(sqlQuery);
            }
        }

        private static FolderDTO FillDTO(SqlDataReader reader)
        {
            var dto = new FolderDTO();
           /* dto.ProductID = reader.GetInt32(0);
            dto.Name = reader.GetString(1);
            dto.Price = reader.GetDouble(2);
            
            dto.PictureName = reader.GetString(3);
            dto.CreatedOn = reader.GetDateTime(4);
            
            dto.CreatedBy = reader.GetInt32(5);
            if (reader.GetValue(6) != DBNull.Value)
                dto.ModifiedOn = reader.GetDateTime(6);
            if (reader.GetValue(7) != DBNull.Value)
                dto.ModifiedBy = reader.GetInt32(7);
            dto.IsActive = reader.GetBoolean(8);*/
            return dto;
        }
    }
}
