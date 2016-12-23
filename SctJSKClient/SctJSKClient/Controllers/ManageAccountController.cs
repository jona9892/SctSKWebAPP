using DTOModel;
using GatewayService;
using SctJSKClient.Security;
using SctJSKClient.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SctJSKClient.Controllers
{
    [CustomAuthorize(Roles = "Admin,Student,Teacher,Member")]
    public class ManageAccountController : Controller
    {
        private Facade facade = new Facade();
        // GET: ManageAccount
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewOrders()
        {
            var getUsername = SessionPersister.Username;
            var getUser = facade.GetUserService().Get(getUsername);
            return View(getUser);
        }
    }
}