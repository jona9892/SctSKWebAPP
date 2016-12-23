using GatewayService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SctJSKClient.Security
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        private readonly Facade facade = new Facade();
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (string.IsNullOrEmpty(SessionPersister.Username))
            {
                filterContext.Result = new RedirectToRouteResult
                    (new System.Web.Routing.RouteValueDictionary(new { controller = "Account", action = "Index" }));
            }
            else
            {
                var user = facade.GetUserService();
                CustomPrincipal mp = new CustomPrincipal(user.Get(SessionPersister.Username));
                //Find the error view
                if (!mp.IsInRole(Roles))
                {
                    filterContext.Result = new RedirectToRouteResult
                        (new System.Web.Routing.RouteValueDictionary(
                            new { controller = "AccessDenied", action = "Index" }));
                }
            }
        }
    }
}