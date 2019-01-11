using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Entities
{
    public class FolderDTO
    {
        public String Name { get; set; }
        public String ParentFolderId { set; get; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public Boolean IsActive { get; set; }
       
    }
}
