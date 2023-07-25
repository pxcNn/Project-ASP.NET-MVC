using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebDT.Areas.Admin.Controllers
{
    public class DefaultController : Controller
    {
        [HttpGet]
        //GET: Admin/Default
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            return View();
        }


    }
}