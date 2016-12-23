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
    [CustomAuthorize(Roles = "Admin,HeadMaster")]
    public class ArrangementController : Controller
    {
        Facade facade = new Facade();
        // GET: Arrangement
        public ActionResult Index()
        {
            var arrangements = facade.GetArrangementService().GetAll();
            return View(arrangements);
        }

        public ActionResult GetEvents(DateTime start, DateTime end)
        {
            //Get the events
            //You may get from the repository also
            var userId = int.Parse(SessionPersister.UserId);
            var eventList = facade.GetArrangementService().GetEvents(userId);

            var rows = eventList.ToArray();
            return Json(rows, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Create()
        {
            ArrangementViewModel avm = new ArrangementViewModel()
            {
                Products = facade.GetProductService().GetAll().ToList(),
                Categrories = facade.GetCategoryService().GetAll().ToList()

            };
            return View(avm);
        }
        
        [HttpPost]
        public ActionResult Create(ArrangementViewModel avm)
        {
            if (ModelState.IsValid)
            {

                Arrangement arrangement = facade.GetArrangementService().Add(avm.Arrangement);

                foreach(var ap in avm.selected)
                {
                    ArrangementProduct arp = new ArrangementProduct();
                    arp.ProductId = int.Parse(ap);
                    arp.ArrangementId = arrangement.Id;
                    arp.Quantity = 29;
                    
                    facade.GetArrangementProductService().create(arp);
                }

                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Aftale/Delete/5
        public ActionResult Delete(int id)
        {
            var arrangement = facade.GetArrangementService().Get(id);
            if (arrangement == null)
            {
                return HttpNotFound();
            }
            return View(arrangement);
        }

        // POST: Aftale/Delete/5
        [HttpPost]
        public ActionResult Delete(Arrangement arrangement)
        {
            try
            {
                // TODO: Add delete logic here
                facade.GetArrangementService().Delete(arrangement);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        public ActionResult ViewArrangementDetails(int id)
        {
            ArrangementProductViewModel apvm = new ArrangementProductViewModel();
            apvm.Arrangement = facade.GetArrangementService().Get(id);

            foreach (var item in apvm.Arrangement.Products)
            {
                ArrangementProduct arrangementProduct = new ArrangementProduct();
                arrangementProduct.Quantity = item.Quantity;
                arrangementProduct.Arrangement = apvm.Arrangement;
                arrangementProduct.Product = facade.GetProductService().Get(item.ProductId);

                apvm.ArrangementProducts.Add(arrangementProduct);
            }
            return View(apvm);
        }

    }
}