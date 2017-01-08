using Sct.JSKDAL;
using Sct.JSKDAL.Context;
using Sct.JSKDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Sct.JSKApi.Controllers
{
    public class CategoryController : ApiController
    {
        private Facade facade;
        
        public CategoryController()
        {
            facade = new Facade(new DBContextSctJSK());
        } 

        // GET: api/Category
        /// <summary>
        /// this returns an IEnumerable, which contains all Categories.
        /// </summary>
        /// <returns>an IEnumerable with Categories</returns>
        public HttpResponseMessage GetCategories()
        {
            var response = Request.CreateResponse(HttpStatusCode.OK, facade.GetCategoryRepository().ReadAll());
            return response;
        }

        public HttpResponseMessage GetCategory(int id)
        {
            var response = Request.CreateResponse(HttpStatusCode.OK, facade.GetCategoryRepository().Read(id));
            return response;

            //return facade.GetCategoryRepository().Read(id);
        }

        public HttpResponseMessage PostCategory(Category c)
        {
            var response = Request.CreateResponse(HttpStatusCode.Created, facade.GetCategoryRepository().Add(c));
            return response;
        }

        public void PutCategory(int id, Category c)
        {
            if (c == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            c.Id = id;
            facade.GetCategoryRepository().Update(c);
        }

        public void DeleteCategory(int id)
        {
            var c = facade.GetCategoryRepository().Read(id);
            facade.GetCategoryRepository().Delete(c);
        }
    }
}
