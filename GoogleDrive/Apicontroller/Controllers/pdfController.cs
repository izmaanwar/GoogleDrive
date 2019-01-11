using iText.Kernel.Pdf;
using iText.Layout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using Assignment8.Models;
using iText.Layout.Element;

namespace Apicontroller.Controllers
{

    [EnableCors(origins: "http://localhost:50362", headers: "*", methods: "*")]
    public class pdfController : ApiController
    {

        [HttpPost]
        public void saveMetaData()
        {


            String dest = "C:\\Users\\aa\\Documents\\asp projects\\Assignment8\\Apicontroller\\UploadFiles\\Meta.pdf";
            var writer = new PdfWriter(dest);
            var pdf = new PdfDocument(writer);
            var doc1 = new Document(pdf);
          
            FolderBAL fb = new FolderBAL();
            List<FolderDTO> fdto = new List<FolderDTO>();
            fdto =  fb.GetAllFolders();
       
           
           

            foreach (var item in fdto)
            {
                doc1.Add(new Paragraph("FolderName :" + item.Name));
                doc1.Add(new Paragraph("Type :" + "Folder"));
                doc1.Add(new Paragraph("size :" + "none"));
                doc1.Add(new Paragraph("parentFolder :" + "Root"));
                var subf = fb.getsubfolder(item.FolderId);
                if(subf.Count > 0)
                {
                    foreach(var item1 in subf)
                    {
                        doc1.Add(new Paragraph("FolderName :" + item1.Name));
                        doc1.Add(new Paragraph("Type :" + "Folder"));
                        doc1.Add(new Paragraph("size :" + "none"));
                        doc1.Add(new Paragraph("parentFolder :" + item.Name));
                    }
                }
                var subfiles = fb.getsubfiles(item.FolderId);
                if(subfiles.Count > 0)
                {
                    foreach (var item2 in subfiles)
                    {
                        doc1.Add(new Paragraph("FileName :" +  item2.FileUniqueName));
                        doc1.Add(new Paragraph("Type :" + "File"));
                        doc1.Add(new Paragraph("size :" + item2.Size));
                        doc1.Add(new Paragraph("parentFolder :" + item.Name));
                    }

                }

            }



            doc1.Close();
            return;
        }

        [HttpGet]
        public HttpResponseMessage downloadpdf()
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