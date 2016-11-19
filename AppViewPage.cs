using ASPMVCIdentityDemo.Models;
using System.Security.Claims;
using System.Web.Mvc;

namespace ASPMVCIdentityDemo
{
    /// <summary>
    /// Why do we need to add this information to ViewBag when we already have 
    /// access to the current user within our view?
    /// </summary>
    /// <typeparam name="TModel">dynamic model</typeparam>
    public abstract class AppViewPage<TModel> : WebViewPage<TModel>
    {
        protected AppUser CurrentUser
        {
            get
            {
                return new AppUser(this.User as ClaimsPrincipal);
            }
        }
    }

    public abstract  class AppViewPage:AppViewPage<dynamic>
    {

    }
}