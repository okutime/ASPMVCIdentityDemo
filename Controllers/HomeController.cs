using ASPMVCIdentityDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace ASPMVCIdentityDemo.Controllers
{
    public class HomeController : AppController
    {
        // GET: Home
        public ActionResult Index()
        {
            //Accessing custom claim data
            var claimsIdentity = CurrentUser.Name;
            ViewBag.country = CurrentUser.Country;
            ViewBag.email = CurrentUser.Email;
            return View();
        }
    }
}