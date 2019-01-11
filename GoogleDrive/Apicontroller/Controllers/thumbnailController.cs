using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Assignment8.Models;
using System.Web;
using System.Drawing;
using System.IO;
using Microsoft.WindowsAPICodePack.Shell;
namespace Apicontroller.Controllers
{
     [EnableCors(origins: "http://localhost:50362", headers: "*", methods: "*")]
   
    public class  thumbnailController : ApiController
    {
         [HttpGet]
         public Object getThumbnail(string uniqueName)
         {
              FolderBAL fb = new FolderBAL();
               FileDTO filedto =fb.GetFileByUniqueID(uniqueName);
              var rootPath = HttpContext.Current.Server.MapPath("~/UploadedFiles");
              var fileFullPath = System.IO.Path.Combine(rootPath, uniqueName);

              ShellFile shellFile = ShellFile.FromFilePath(fileFullPath);
              Bitmap shellThumb = shellFile.Thumbnail.SmallBitmap;

              if (filedto != null)
              {
                  HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
                  byte[] file = ImageToBytes(shellThumb);
                  MemoryStream ms = new MemoryStream(file);
                 response.Content = new ByteArrayContent(file);
                  response.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
                  response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(filedto.ContentTpye);
                  response.Content.Headers.ContentDisposition.FileName = filedto.FileUniqueName;
                  return response;
              }
              else
              {
                  HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.NotFound);
                  return response;
              }

          }
          private byte[] ImageToBytes(Image img)
          {
              using (var stream = new MemoryStream())
              {
                  img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                  return stream.ToArray();
              }
          }
         }
    }
