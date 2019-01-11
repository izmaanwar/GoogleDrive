using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment8.Models
{
    public class FolderDTO
    {
        public int FolderId { get; set; }
        public String Name { get; set; }
        public int ParentFolderId { set; get; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public Boolean IsActive { get; set; }

       
    }
}