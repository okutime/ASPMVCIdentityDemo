using ASPMVCIdentityDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace ASPMVCIdentityDemo.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        // GET: Auth
        public ActionResult Login(string ReturnUrl)
        {
            var vm = new LoginModel
            {
                ReturnUrl = ReturnUrl
            };
            ViewBag.back = ReturnUrl;
            return View(vm);
        }
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (!ModelState.IsValid)
                return View();


            if (model.Email == "otis@xandrux.com" && model.Password == "password@1")
            {
                //define new user claimsIdentity
                var identity = new ClaimsIdentity(new[]
                {
                new Claim(ClaimTypes.Email,"otis@xandrux.com"),
                new Claim(ClaimTypes.Name,"Otis Henry"),
                new Claim(ClaimTypes.Country,"Nigeria")
            }, "ApplicationCookie");


                //specify the context
                var context = Request.GetOwinContext();

                //define userAuthManager
                var authManager = context.Authentication;

                //Login by calling the SignIn extension method from the authManager
                authManager.SignIn(identity);

                return Redirect(GetRedirectUrl(model.ReturnUrl));
            }
            ModelState.AddModelError("", "Invalid Email or Password!");
            return View();

        }
        /// <summary>
        /// private method that takes care of checking if return url is null or !local
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        private string GetRedirectUrl(string returnUrl)
        {
            if (string.IsNullOrEmpty(returnUrl) || !Url.IsLocalUrl(returnUrl))
            {
                return Url.Action("index", "Home");
            }
            return returnUrl;
        }
        /// <summary>
        /// Logging Out
        /// </summary>
        /// <returns></returns>
        public ActionResult Logout()
        {
            var authManager = Request.GetOwinContext().Authentication;
            authManager.SignOut("ApplicationCookie");

            return RedirectToAction("index", "Home");
        }
    }
}