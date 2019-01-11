using apicontroller.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace apicontroller.Controllers
{
    [EnableCors(origins: "http://localhost:59311", headers: "*", methods: "*")]
    public class ValuesController : ApiController
    {
        // GET api/values

        /*
         /api/Values/GetValue
        */
        [HttpGet]
        public int GetValue()
        {
            return 10;
        }

        /*
         /api/Values/AddNumbers?a=10&b=20
        */
        [HttpGet]
        public int AddNumbers(int a, int b)
        {
            return a + b;
        }


        [HttpGet]
        public CustomerDTO GetCustomer()
        {
            var dto = new CustomerDTO();
            dto.ID = 1;
            dto.Name = "Bilal";

            return dto;
        }

        [HttpGet]
        public CustomerDTO SaveCustomer([FromUri]apicontroller.Models.CustomerDTO dto)
        {
            return dto;
        }

        [HttpPost]
        public int AddNumbersP(int a, int b)
        {
            return a + b;
        }

        [HttpPost]
        public CustomerDTO GetCustomerP()
        {
            var dto = new CustomerDTO();
            dto.ID = 1;
            dto.Name = "Bilal";

            return dto;
        }
        [HttpPost]
        public CustomerDTO SaveCustomerP(CustomerDTO dto)
        {
            return dto;
        }


        [HttpPost]
        public void PostFormData()
        {
            var age = HttpContext.Current.Request["Age"];
            if (HttpContext.Current.Request.Files.Count > 0)
            {
              
                try
                {
                    foreach (var fileName in HttpContext.Current.Request.Files.AllKeys)
                    {
                        HttpPostedFile file = HttpContext.Current.Request.Files[fileName];
                        if (file != null)
                        {
                            //Generate a unique name using Guid
                            var uniqueName = Guid.NewGuid().ToString();
                            //Get physical path of our folder where we want to save images
                            var rootPath = HttpContext.Current.Server.MapPath("~/UploadedFiles");

                            var fileSavePath = System.IO.Path.Combine(rootPath, uniqueName);
                            // Save the uploaded file to "UploadedFiles" folder
                            file.SaveAs(fileSavePath);
                            
                        }
                    }//end of foreach
                   
                }
                catch (Exception ex)
                { }
               
            }//end of if count > 0
           

        }
    }
}
