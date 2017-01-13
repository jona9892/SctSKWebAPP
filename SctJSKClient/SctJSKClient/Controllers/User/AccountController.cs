using GatewayService;
using SctJSKClient.Security;
using SctJSKClient.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SctJSKClient.Controllers
{
    public class AccountController : Controller
    {
        private readonly Facade facade = new Facade();
        // GET: Account
        public ActionResult Index()
        {
            if(SessionPersister.Username == null && SessionPersister.UserId == null)
            {
                return View();
            }
            else
            {
                return View("LoggedIn");
            }
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(AccountViewModel avm)
        {
            var user = facade.GetUserService();
            if (string.IsNullOrEmpty(avm.User.Username) || string.IsNullOrEmpty(avm.User.Password) || user.Login(avm.User.Username, avm.User.Password) == null)
            {
                ViewBag.Error = "Account's Invalid";
                return View("Index");
            }
            SessionPersister.Username = avm.User.Username;
            var getUser = facade.GetUserService().Get(avm.User.Username);
            SessionPersister.UserId = getUser.Id.ToString();
            SessionPersister.UserRole = getUser.Roles.Title;
            return RedirectToAction("Index","Home");
        }

        public ActionResult Logout()
        {
            SessionPersister.Username = null;
            SessionPersister.UserId = null;
            return RedirectToAction("Index");
        }
    }
}