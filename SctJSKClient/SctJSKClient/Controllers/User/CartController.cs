using DTOModel;
using GatewayService;
using SctJSKClient.Models;
using SctJSKClient.Security;
using SctJSKClient.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace SctJSKClient.Controllers
{
    [CustomAuthorize(Roles = "Admin,Student,Teacher,HeadMaster")]
    public class CartController : Controller
    {
        private Facade facade = new Facade();

        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Buy(int id)
        {
            if(Session["cart"] == null)
            {
                List<Item> cart = new List<Item>();
                cart.Add(new Models.Item() {
                    product = facade.GetProductService().Get(id),
                    quantity = 1
                });
                Session["cart"] = cart;
            }
            else
            {
                List<Item> cart = (List<Item>)Session["cart"];
                int index = isExits(id);

                if(index == -1)
                {
                    cart.Add(new Models.Item()
                    {
                        product = facade.GetProductService().Get(id),
                        quantity = 1
                    });
                } else
                {
                    cart[index].quantity = cart[index].quantity + 1;
                }

                
                Session["cart"] = cart;
            }
            return View("Index");
        }

        private int isExits(int id)
        {
            List<Item> cart = (List<Item>)Session["cart"];
            for(int i = 0; i < cart.Count; i++)
            {
                if(cart[i].product.Id == id)
                {
                    return i;
                }
            }
            return -1;
        }

        public ActionResult Delete(int id)
        {
            List<Item> cart = (List<Item>)Session["cart"];
            cart.RemoveAt(id);
            Session["cart"] = cart;
            return View("Index");
        }

        public ActionResult SetOrderDates()
        {
            List<OrderDate> listmodel = new List<OrderDate>();
            string tomorrow = DateTime.Today.AddDays(1).Date.ToString();
            string date = tomorrow.Split(' ')[0];

            listmodel.Add(new OrderDate() { orderdate = date.ToString()});

            List<string> list = new List<string>();
            list.Add("09:50");
            list.Add("11:30");

            OrderDateViewModel odvm = new OrderDateViewModel
            {
                dates = listmodel,
                breaks = list
            };

            return View(odvm);
        }
    

        [HttpPost]
        public ActionResult SetOrderDates(IEnumerable<OrderDate> dates, string dayoftime)
        {
            OrderDateViewModel odvm = new OrderDateViewModel
            {
                dates = dates.ToList(), 
                timeofday = dayoftime
            };
            Session["orderdates"] = odvm;
            
            return RedirectToAction("Checkout");
        }

        public ActionResult BlankEditorRow()
        {
            return PartialView("EditorRow", new OrderDate());
        }


        public ActionResult Checkout()
        {
            if(SessionPersister.Username == null)
            {
                return RedirectToAction("Index", "account");
            }
            else
            {

                CheckoutItem checkoutitem = new CheckoutItem();
                List<Item> cart = (List<Item>)Session["cart"];
                OrderDateViewModel orderdates = (OrderDateViewModel)Session["orderdates"];

                //Save order 
                foreach(var od in orderdates.dates)
                {
                    Order order = new Order();
                    order.OrderCreated = DateTime.Now;

                    order.OrderDate = Convert.ToDateTime(od.orderdate);                    

                    int totalprice = 0;

                    foreach(var item in cart)
                    {
                        var productPrice = item.quantity * item.product.Price; 
                        totalprice = totalprice + productPrice;
                    }
                    order.TotalPrice = totalprice;
                    var user = SessionPersister.Username;
                    order.User = facade.GetUserService().Get(user);

                    Order getOrder = facade.GetOrderService().Add(order);
                    int orderId = getOrder.Id;
                    checkoutitem.order = getOrder;

                    //Save order detail
                    foreach (var item in cart)
                    {
                        OrderDetail orderDetail = new OrderDetail();

                        orderDetail.OrderId = orderId;
                        orderDetail.ProductId = item.product.Id;
                        orderDetail.Price = item.product.Price;
                        orderDetail.Quantity = item.quantity;


                        facade.GetOrderDetailService().create(orderDetail);
                        orderDetail.Product = facade.GetProductService().Get(orderDetail.ProductId);
                        checkoutitem.orderDetails.Add(orderDetail);
                    }
                }
               
                //Remove cart
                Session.Remove("cart");

                return View(checkoutitem);
            }
            
            
        }
    }
}