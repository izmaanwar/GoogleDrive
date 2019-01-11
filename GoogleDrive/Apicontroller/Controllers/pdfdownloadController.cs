using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using Assignment8.Models;
using System.Web;
using iText.Layout.Element;
using iText.Kernel.Pdf;
using iText.Layout;
using System.Web.Http.Cors;
namespace Apicontroller.Controllers
{

    [EnableCors(origins: "http://localhost:50362", headers: "*", methods: "*")]
    public class pdfdownloadController : ApiController
    {

       [HttpPost]
        public void getMetaData()
        {


            String dest = "C:\\Users\\aa\\Documents\\asp projects\\Assignment8\\Apicontroller\\UploadFiles\\Meta.pdf";
            var writer = new PdfWriter(dest);
            var pdf = new PdfDocument(writer);
            var doc1 = new Document(pdf);
            combine cm = new combine();
            FolderBAL fb = new FolderBAL();

            string id = HttpContext.Current.Request["parid"];
            int id1 = int.Parse(id);
            cm = fb.combine(id1);
            string name = fb.getName(id1);

            foreach (var item in cm.allfolders)
            {
                doc1.Add(new Paragraph("FolderName :" + item.Name));
                doc1.Add(new Paragraph("Type :" + "Folder"));
                doc1.Add(new Paragraph("size :" + "none"));
                doc1.Add(new Paragraph("parentFolder :" + name));
            }

            foreach (var item in cm.allfiles)
            {
                doc1.Add(new Paragraph("FileName : " + item.FileUniqueName));
                doc1.Add(new Paragraph("Type : " + "File"));
                doc1.Add(new Paragraph("size :" + item.Size));
                doc1.Add(new Paragraph("parentFolder :" + name));
            }
 

           
            doc1.Close();
            return;
        }

        [HttpGet]
        public HttpResponseMessage downloadMeta()
        {
            var rootPath = HttpContext.Current.Server.MapPath("~/uploadfiles");
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            var fileFullPath = System.IO.Path.Combine(rootPath, "Meta.pdf");

            byte[] file = System.IO.File.ReadAllBytes(fileFullPath);
            System.IO.MemoryStream ms = new System.IO.MemoryStream(file);

            response.Content = new ByteArrayContent(file);
            response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");

            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");
            response.Content.Headers.ContentDisposition.FileName = "Meta.pdf";
            return response;
        }
    }



     
    
}