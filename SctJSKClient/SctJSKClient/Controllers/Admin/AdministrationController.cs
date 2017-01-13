using GatewayService;
using SctJSKClient.Models;
using SctJSKClient.Security;
using SctJSKClient.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SctJSKClient.Controllers
{
    [CustomAuthorize(Roles = "Admin")]
    public class AdministrationController : Controller
    {
        Facade facade = new Facade();
        // GET: Administration
        public ActionResult Index()
        {
            OrderDate orderdate = new Models.OrderDate();
           // orderdate.orderdate = DateTime.Today.Date;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(OrderDate od, string command)
        {
            if (command.Equals("submit1"))
            {
                return RedirectToAction("ViewOrderedProducts", new { orderdate = od.orderdate });
            }
            else
            {
                return RedirectToAction("ViewOrderedCustomers", new { orderdate = od.orderdate });
            }
        }

        public ActionResult ViewOrderedProducts(string orderdate)
        {
            if (orderdate == null)
            {
                return HttpNotFound();
            }
            //DateTime date = Convert.ToDateTime(orderdate);
            string date = orderdate.Split(' ')[0];
            var productCount = facade.GetOrderService().GetOrderedProducts(date);
            return View(productCount);
        }

        
        public ActionResult ViewOrderedCustomers(string orderdate)
        {
            if (orderdate == null)
            {
                return HttpNotFound();
            }
            string date = orderdate.Split(' ')[0];
            var getusers = facade.GetOrderService().GetAllOrderedCustomers(date).ToList();
            UserOrderDateViewModel uovm = new UserOrderDateViewModel()
            {
                users = getusers,
                orderdate = orderdate
            };
            
            return View(uovm);
        }

        public ActionResult ViewOrderedCustomerDetails(string orderdate, int id)
        {
            if (orderdate == null || id == 0)
            {
                return HttpNotFound();
            }
            string date = orderdate.Split(' ')[0];
            var order = facade.GetOrderService().GetOrderedCustomerDetails(date, id);

            return View(order);
        }

        public ActionResult MenuBarPartial()
        {
            return PartialView();
        }
        
    }
}