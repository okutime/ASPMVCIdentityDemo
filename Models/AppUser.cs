using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace ASPMVCIdentityDemo.Models
{
    public class AppUser : ClaimsPrincipal
    {
        public AppUser(ClaimsPrincipal principal) : base(principal: principal)
        {

        }

        public string Name
        {
            get { return this.FindFirst(ClaimTypes.Name).Value; }
        }
        public string Country
        {
            get { return this.FindFirst(ClaimTypes.Country).Value; }
        }

        public string Email
        {
            get
            {
                return this.FindFirst(ClaimTypes.Email).Value;
            }
        }
    }
}