using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Cors;
using Assignment8.Models;
namespace Apicontroller.Controllers
{
    [EnableCors(origins: "http://localhost:50362", headers: "*", methods: "*")]
    public class downloadController : ApiController
    {
        [HttpGet]
        public Object DownloadFile(String UniqueName)
        {
            var rootpath = System.Web.HttpContext.Current.Server.MapPath("~/UploadedFiles");
            FolderBAL fb = new FolderBAL();
            var fileDTO = fb.GetFileByUniqueID(UniqueName);
            if (fileDTO != null)
            {
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
                var filefullpath = System.IO.Path.Combine(rootpath, fileDTO.FileUniqueName);
                byte[] file = System.IO.File.ReadAllBytes(filefullpath);
                System.IO.MemoryStream ms = new System.IO.MemoryStream(file);
                response.Content = new ByteArrayContent(file);
                response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
                response.Content.Headers.ContentType = new MediaTypeHeaderValue(fileDTO.ContentTpye);
                response.Content.Headers.ContentDisposition.FileName = fileDTO.fileActualName;
                return response;
            }
            else
            {
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.NotFound);
                return response;
            }
        }
        
    }
}