using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;


namespace MyPdfHelper
{
    public class PdfHelper
    {
        public static void GeneratePdfTesting(String appPhysicalPath)
        {
            //You need physical path of file you want to create
            var filePath = appPhysicalPath + "\\" + DateTime.Now.Ticks.ToString() + ".pdf";

            //Create Document
            var doc1 = new Document();

            //Create Document Instance and load in 'doc1'
            var streamObj = new System.IO.FileStream(filePath, System.IO.FileMode.CreateNew);
            PdfWriter.GetInstance(doc1, streamObj);
            doc1.Open();
           
            doc1.Add(new Paragraph("This is a custom size"));
            

           /* Chunk linebreak = new Chunk(new LineSeparator());
            //Chunk linebreak = new Chunk(new DottedLineSeparator());

            doc1.Add(linebreak);


            //Create a table with number of columns
            PdfPTable table = new PdfPTable(2);

            //Create Phrase Object (Data, Font object)
            Phrase ph = new Phrase("ABC's Data", new Font(Font.FontFamily.TIMES_ROMAN, 14f, Font.BOLD, BaseColor.BLACK));

            //Create Cell using Phrase object
            PdfPCell cell = new PdfPCell(ph);
            cell.Colspan = 2;
            cell.HorizontalAlignment = 1;
            cell.VerticalAlignment = 1;
            cell.BackgroundColor = BaseColor.LIGHT_GRAY;

            table.AddCell(cell);

            //Second row
            table.AddCell(new PdfPCell(new Phrase("Size", new Font(Font.FontFamily.TIMES_ROMAN, 12f, Font.BOLD))));
            table.AddCell("1024K");

            //Third row
            table.AddCell(new PdfPCell(new Phrase("Type", new Font(Font.FontFamily.TIMES_ROMAN, 12f, Font.BOLD))));
            table.AddCell("Image");


            doc1.Add(table);*/

            doc1.Close();
        }
    }
}
