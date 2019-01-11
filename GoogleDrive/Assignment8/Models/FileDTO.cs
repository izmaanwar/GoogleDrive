using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment8.Models
{
    public class FileDTO
    {
        public String FileUniqueName
        { set; get; }
        public string fileActualName { set; get; }
        public String FileExt
        { set; get; }
        public int Size
        { get; set; }
        public int ParentFolderid 
        { set; get; }
        public int CreatedBy
        { get; set; }
        public DateTime UploadedOn
        { set; get; }
        public Boolean IsActive
        {
            get;
            set;
        }
        public int ID
        { get; set; }
        public string ContentTpye { set; get; }
    }
}