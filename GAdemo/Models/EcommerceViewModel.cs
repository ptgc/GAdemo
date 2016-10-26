using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GAdemo.Models.GAdata;

namespace GAdemo.Models
{
    public class EcommerceViewModel
    {
        public GAbasket Basket { get; set; }
        public GAproduct Product { get; set; }
        public List<GAproduct> Products { get; set; }
        public GApurchase Purchase { get; set; }
        public string Message { get; set; }

        public GAproduct AddedGAproduct { get; set; }
    }
}