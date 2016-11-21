using System.Security.Claims;
using System.Web.Mvc;

namespace ASPMVCIdentityDemo.Models
{
    public abstract class AppController : Controller
    {
        public AppUser CurrentUser => new AppUser(User as ClaimsPrincipal);
    }
}