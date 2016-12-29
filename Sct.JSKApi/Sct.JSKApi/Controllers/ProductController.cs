using Sct.JSKDAL;
using Sct.JSKDAL.Context;
using Sct.JSKDAL.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Sct.JSKApi.Controllers
{
    public class ProductController : ApiController
    {
        private Facade facade;
        public ProductController()
        {
            facade = new Facade(new DBContextSctJSK());
        }

        // GET: api/Product
        /// <summary>
        /// this returns an IEnumerable, which contains all products.
        /// </summary>
        /// <returns>an IEnumerable with products</returns>
        public HttpResponseMessage GetProducts()
        {
            var response = Request.CreateResponse(HttpStatusCode.OK, facade.GetProductRepository().ReadAll());
            return response;
        }

        public HttpResponseMessage GetProduct(int id)
        {
            var response = Request.CreateResponse(HttpStatusCode.OK, facade.GetProductRepository().Read(id));
            return response;
        }

        public HttpResponseMessage PostProduct(Product p)
        {
            var product = facade.GetProductRepository().Add(p);

            var response = Request.CreateResponse(HttpStatusCode.Created, product);
            return response;
        }

        public void PutProduct(int id, Product p)
        {
            if (p == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            p.Id = id;


            facade.GetProductRepository().Update(p);
        }

        public void DeleteProduct(int id)
        {
            var e = facade.GetProductRepository().Read(id);
            facade.GetProductRepository().Delete(e);
        }
        
       
        public HttpResponseMessage GetProductsByCategory(string category)
        {
            var response = Request.CreateResponse(HttpStatusCode.OK, facade.GetProductRepository().GetProductsByCategory(category));
            return response;
        }
    }
}
