using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobsInABA.BL;
using JobsInABA.DAL.Entities;

namespace Api.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            /*
            UsersBL oUsersBL = new UsersBL();

            User u = new User
            {
                FirstName = "Third User",
                MiddleName = "A",
                LastName = "Test",
                UserName = "thirdusertest",
                DOB = new DateTime(2011, 12, 1),
                IsActive = true,
                IsDeleted = false,
                insdt = DateTime.Now,
                upddt = DateTime.Now,
                insuser = 3,
                upduser = 3
            };

            User usr = oUsersBL.Create(u);
            
            ViewBag.Title = "Home Page";
            */
            return View();
        }
    }
}
