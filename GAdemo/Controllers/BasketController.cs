using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Caching;
using System.Web.Http;
using GAdemo.Models.GAdata;
using Microsoft.Owin;

namespace GAdemo.Controllers
{
    public class BasketController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Add(FormCollection formCollection)
        {
            var productId = formCollection.Get("Products");
            var cachedBasket = GetBasket();
            var basket = cachedBasket ?? new GAbasket() {BasketId = Utils.Utils.RandomString(16), Items = new List<GAproduct>()};
            basket.Items.Add(Mockdata.Mockdata.GetMockProduct(Convert.ToInt32(productId)));
            var cachedProduct = HttpContext.Current.Cache.Add("GAbasket", basket, null, DateTime.Now.AddMinutes(30), Cache.NoSlidingExpiration, CacheItemPriority.High, null);
        

            return Ok();
        }

        public static GAbasket GetBasket()
        {
            var basket = (GAbasket)HttpContext.Current.Cache.Get("GAbasket");
            return basket;
        }
    }
}
