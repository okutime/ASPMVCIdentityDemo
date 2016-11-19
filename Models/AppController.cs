using System.Security.Claims;
using System.Web.Mvc;

namespace ASPMVCIdentityDemo.Models
{
    public abstract class AppController : Controller
    {
        public AppUser CurrentUser
        {
            get
            {
                return new AppUser(this.User as ClaimsPrincipal);
            }
        }
    }
}