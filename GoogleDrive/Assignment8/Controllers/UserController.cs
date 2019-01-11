using PMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PMS.DAL;
using Assignment8.Models;
using WebPrac.Security;

namespace WebPrac.Controllers
{
    public class UserController : Controller
    {


        [HttpGet]
        public ActionResult Logout()
        {
            SessionManager.ClearSession();
            return RedirectToAction("Login");
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        // simple login screen without ajax
        [HttpPost]
        public ActionResult Login(String login, String password)
        {
            UserDTO dto = new UserDTO();
            if (login == "")
            {
                @ViewBag.mesg = "login cnt be empty";
            }
            else if (password == "")
            {
                @ViewBag.mesg = "password cnt be empty";
            }
            else
            {
                var obj = PMS.BAL.UserBO.ValidateUser(login, password);
                if (obj != null)
                {

                    dto.Login = login;
                    dto.Password = password;
                    int id = PMS.BAL.UserBO.getuserID(login, password);
                    Session["userid"] = id;
                    Session["user"] = obj;
                    Session["username"] = obj.Name;
                    return Redirect("~/Home/NormalUser");
                }

                @ViewBag.MSG = "Invalid Login/Password";
                @ViewBag.Login = login;
            }
            return View();
        }
         public ActionResult CreateFolder()
        {
            return View();
        }


         [HttpPost]
         public ActionResult search(string Actualname)
         {

             List<FileDTO> list = new List<FileDTO>();
             FolderBAL fb = new FolderBAL();
             FileDTO fd = new FileDTO();
              list = fb.search(Actualname);

             return View(list);

         }

         public ActionResult search()
         {

             List<FileDTO> list = new List<FileDTO>();
             return View(list);

         }
    }
       
}