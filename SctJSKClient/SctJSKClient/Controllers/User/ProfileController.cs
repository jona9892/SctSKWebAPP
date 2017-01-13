using DTOModel;
using GatewayService;
using SctJSKClient.Models;
using SctJSKClient.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SctJSKClient.Controllers
{
    [CustomAuthorize(Roles = "Admin,Student,Teacher,HeadMaster")]
    public class ProfileController : Controller
    {
        Facade facade = new Facade();
        // GET: Profile
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetEvents()
        {
            //Get the events
            var userId = int.Parse(SessionPersister.UserId);
            var eventList = facade.GetUserService().GetEvents(userId);

            var rows = eventList.ToArray();
            return Json(rows, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ViewOrders()
        {
            int userId = int.Parse(SessionPersister.UserId);
            
            var getOrdersbyUser = facade.GetUserService().GetOrdersByUser(userId);
            UserOrderModel uovm = new UserOrderModel();
            uovm.Orders = getOrdersbyUser.ToList();
            return View(uovm);
        }

        public ActionResult ViewCurrentOrders(string sortOrder)
        {
            int userId = int.Parse(SessionPersister.UserId);

            ViewBag.OrderCreatedSortParm = String.IsNullOrEmpty(sortOrder) ? "ordercreated_desc" : "";
            ViewBag.DateSortParm = sortOrder == "OrderDate" ? "orderdate_desc" : "OrderDate";
            ViewBag.TotalPriceSortParm = sortOrder == "TotalPrice" ? "total_desc" : "TotalPrice";

            var getOrdersbyUser = facade.GetUserService().GetCurrentOrders(userId);
            UserOrderModel uovm = new UserOrderModel();
            var orders = getOrdersbyUser.ToList();

            switch (sortOrder)
            {
                case "ordercreated_desc":
                    orders = orders.OrderByDescending(s => s.OrderCreated).ToList();
                    break;
                case "OrderDate":
                    orders = orders.OrderBy(s => s.OrderDate).ToList();
                    break;
                case "orderdate_desc":
                    orders = orders.OrderByDescending(s => s.OrderDate).ToList();
                    break;
                case "Total":
                    orders = orders.OrderBy(s => s.TotalPrice).ToList();
                    break;
                case "totalprice_desc":
                    orders = orders.OrderByDescending(s => s.TotalPrice).ToList();
                    break;
                default:
                    orders = orders.OrderBy(s => s.OrderCreated).ToList();
                    break;
            }


            uovm.Orders = orders;


            return View(uovm);
        }

        public ActionResult ViewPreviousOrders(string sortOrder)
        {
            int userId = int.Parse(SessionPersister.UserId);

            ViewBag.OrderCreatedSortParm = String.IsNullOrEmpty(sortOrder) ? "ordercreated_desc" : "";
            ViewBag.DateSortParm = sortOrder == "OrderDate" ? "orderdate_desc" : "OrderDate";
            ViewBag.TotalPriceSortParm = sortOrder == "TotalPrice" ? "total_desc" : "TotalPrice";

            var getOrdersbyUser = facade.GetUserService().GetPreviousOrders(userId);
            UserOrderModel uovm = new UserOrderModel();

            var orders = getOrdersbyUser.ToList();

            switch (sortOrder)
            {
                case "ordercreated_desc":
                    orders = orders.OrderByDescending(s => s.OrderCreated).ToList();
                    break;
                case "OrderDate":
                    orders = orders.OrderBy(s => s.OrderDate).ToList();
                    break;
                case "orderdate_desc":
                    orders = orders.OrderByDescending(s => s.OrderDate).ToList();
                    break;
                case "Total":
                    orders = orders.OrderBy(s => s.TotalPrice).ToList();
                    break;
                case "totalprice_desc":
                    orders = orders.OrderByDescending(s => s.TotalPrice).ToList();
                    break;
                default:
                    orders = orders.OrderBy(s => s.OrderCreated).ToList();
                    break;
            }


            uovm.Orders = orders;
            return View(uovm);
        }



        public ActionResult ViewOrderDetails(int id)
        {
            UserOrderModel uovm = new UserOrderModel();
            uovm.order = facade.GetOrderService().Get(id);

            foreach(var item in uovm.order.OrderDetails)
            {
                OrderDetail orderDetail = new OrderDetail();

                orderDetail.Quantity = item.Quantity;
                orderDetail.Price = item.Price;

                orderDetail.Product = facade.GetProductService().Get(item.ProductId);
                uovm.OrderDetails.Add(orderDetail);
            }
            return View(uovm);
        }

        public ActionResult Delete(int id)
        {
            int userid = int.Parse(SessionPersister.UserId);

            facade.GetOrderService().Delete(id, userid);
            return Redirect(Request.UrlReferrer.ToString());
        }
    }
}