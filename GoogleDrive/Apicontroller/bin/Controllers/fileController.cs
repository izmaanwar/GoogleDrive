using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using Assignment8.Models;
using System.IO;
using System.Net.Http.Headers;
namespace Apicontroller.Controllers
{
    [EnableCors(origins: "http://localhost:50362", headers: "*", methods: "*")]
    public class fileController : ApiController
    {
        [HttpPost]
        public void UploadFile()
        {

            var uniqueName = "";

            if (HttpContext.Current.Request.Files.Count > 0)
            {
                try
                {

                    foreach (var FileName in HttpContext.Current.Request.Files.AllKeys)
                    {
                        HttpPostedFile file = HttpContext.Current.Request.Files[FileName];
                        if (file != null)
                        {
                            FileDTO fileDTO = new FileDTO();
                            fileDTO.fileActualName = file.FileName;
                            fileDTO.FileExt = Path.GetExtension(file.FileName);
                            fileDTO.ContentTpye = file.ContentType;
                            fileDTO.Size = file.ContentLength;
                            String createdby = HttpContext.Current.Request["createdby"];
                            String parid = HttpContext.Current.Request["parid"];
                            fileDTO.CreatedBy = int.Parse(createdby);
                            fileDTO.ParentFolderid = int.Parse(parid);
                           
                            fileDTO.UploadedOn = DateTime.Now;
                            fileDTO.IsActive = true;
                           /* var rootpath = HttpContext.Current.Server.MapPath("~/UploadedFiles");
                            var fileSavePath = System.IO.Path.Combine(rootpath, fileDTO.FileUniqueName, fileDTO.FileExt);
                            file.SaveAs(fileSavePath);*/
                            var ext = System.IO.Path.GetExtension(file.FileName);

                            //Generate a unique name using Guid
                            uniqueName = Guid.NewGuid().ToString() + ext;
                            fileDTO.FileUniqueName = uniqueName;
                            //Get physical path of our folder where we want to save images
                            var rootPath = HttpContext.Current.Server.MapPath("~/UploadedFiles");

                            var fileSavePath = System.IO.Path.Combine(rootPath, uniqueName);

                            // Save the uploaded file to "UploadedFiles" folder
                            file.SaveAs(fileSavePath);
                            FolderBAL fb = new FolderBAL();
                            int id = fb.SaveFile(fileDTO);
                        }
                    }
                }
                catch (Exception e)
                {

                }
            }
        }


        
        
    }



    }
