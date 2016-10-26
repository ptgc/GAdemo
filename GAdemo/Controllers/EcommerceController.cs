using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using GAdemo.Models;
using GAdemo.Models.GAdata;

namespace GAdemo.Controllers
{
    public class EcommerceController : Controller
    {
        public ActionResult Ecommerce()
        {
            var model = new EcommerceViewModel {Products = GetProducts()};
            return View(model);
        }

        [HttpPost]
        public ActionResult AddToBasket(FormCollection formCollection)
        {
            var productId = formCollection.Get("ProductId");
            var cachedBasket = BasketController.GetBasket();
            var basket = cachedBasket ?? new GAbasket() { BasketId = Utils.Utils.RandomString(16), Items = new List<GAproduct>() };
            var addedProduct = Mockdata.Mockdata.GetMockProduct(Convert.ToInt32(productId));
            basket.Items.Add(addedProduct);
            var cachedCart = System.Web.HttpContext.Current.Cache.Add("GAbasket", basket, null, DateTime.Now.AddMinutes(30), Cache.NoSlidingExpiration, CacheItemPriority.High, null);

            var model = new EcommerceViewModel
            {
                Basket = basket,
                AddedGAproduct = addedProduct,
                Product = addedProduct,
                Message = addedProduct.Name+" lagt til i handlekurv."
            };
            return View("~/Views/Ecommerce/Product.cshtml", model);
        }

        public ActionResult AddToBasket()
        {
            var cachedBasket = BasketController.GetBasket();
            
            var model = new EcommerceViewModel
            {
                Basket = cachedBasket
            };
            return View("~/Views/Ecommerce/Product.cshtml", model);
        }


        [HttpPost]
        public ActionResult GoToProduct(FormCollection formCollection)
            {
            var productId = formCollection.Get("Products");
            
            var product = Mockdata.Mockdata.GetMockProduct(Convert.ToInt32(productId));
            
            var model = new EcommerceViewModel { Product = product};
            return View("~/Views/Ecommerce/Product.cshtml", model);
        }

        public ActionResult GoToProduct()
        {
            var model = new EcommerceViewModel { };
            return View("~/Views/Ecommerce/Product.cshtml", model);
        }

        public ActionResult Product()
        {
            var model = new EcommerceViewModel { Basket = BasketController.GetBasket() };
            return View(model);
        }

        public ActionResult Checkout()
        {
            var model = new EcommerceViewModel {Basket = BasketController.GetBasket()};
            return View(model);
        }
        public ActionResult Orderconfirmation()
        {
            var model = new EcommerceViewModel {Basket = BasketController.GetBasket()};
            model.Purchase = Mockdata.Mockdata.GetGApurchase(model.Basket);
            System.Web.HttpContext.Current.Cache.Remove("GAbasket");
            return View(model);
        }

        private GAproduct GetProduct(int productNumber)
        {
            return Mockdata.Mockdata.GetMockProduct(productNumber);
        }

        private List<GAproduct> GetProducts()
        {
            return Mockdata.Mockdata.GetGAproducts();
        }
    }
}