using DTOModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace SctJSKClient.Security
{
    public class CustomPrincipal : IPrincipal
    {
        private User User;

        public CustomPrincipal(User user)
        {
            this.User = user;
            this.Identity = new GenericIdentity(user.Username);
        }

        public IIdentity Identity
        {
            get;
            set;
        }

        public bool IsInRole(string role)
        {
            var roles = role.Split(new char[] { ',' });
            return roles.Any(r => this.User.Roles.Title.Equals(r));
        }
    }
}