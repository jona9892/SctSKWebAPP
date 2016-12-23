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
    [CustomAuthorize(Roles = "Admin,Student,Teacher,HeadMaster")]
    public class HomeController : Controller
    {
        private readonly Facade facade = new Facade();
        public ActionResult Index()
        {
            var categories = facade.GetCategoryService().GetAll().ToList();

            HomePageViewModel hpvm = new HomePageViewModel
            {
                Categories = categories
            };
            return View(hpvm);
        }

        public ActionResult ProductInfo(int id)
        {
            var product = facade.GetProductService().Get(id);
            return View(product);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult NavbarCategoryPartialView()
        {
            var categories = facade.GetCategoryService().GetAll();
            return PartialView(categories);
        }

        public ActionResult CategoryPartialView()
        {
            CategoryDetailsViewModel cdvm = new CategoryDetailsViewModel()
            {
                Categories = facade.GetCategoryService().GetAll().ToList()
            };         


            return PartialView(cdvm);
        }

        public ActionResult CategoryDetails(int id)
        {
            var getCategory = facade.GetCategoryService().Get(id);
            CategoryDetailsViewModel cdvm = new CategoryDetailsViewModel()
            {
                Categories = facade.GetCategoryService().GetAll().ToList(),
                Products = facade.GetProductService().GetProductsByCategory(getCategory.Name).ToList(),
                Category = getCategory
               
            };
            return View(cdvm);
        }

        public ActionResult ProductDetails(int id)
        {
            var getProduct = facade.GetProductService().Get(id);
            ProductViewModel pvm = new ViewModels.ProductViewModel()
            {
                Product = getProduct,
                Categories = facade.GetCategoryService().GetAll().ToList()
            };
            return View(pvm);
        }

        public ActionResult getList()
        {
            List<Product> list = facade.GetProductService().GetAll().ToList();

            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetProductList(string term = "")
        {
            List<Product> list = facade.GetProductService().GetAll()
                .Where(p => p.Title.ToUpper()
                .Contains(term.ToUpper()))
                .ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public ActionResult RedirectToOrder(int id)
        {
            return RedirectToAction("ViewOrderDetails", "Profile", new { id = id });
        }

        public ActionResult SearchPage(string q)
        {
            var list = facade.GetProductService().GetAll()
                .Where(p => p.Title.ToUpper()
                .Contains(q.ToUpper()))
                .ToList();

            return View(list);
        }

    }
}