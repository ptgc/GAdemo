using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GAdemo.Models.GAdata
{
    public class GApurchase
    {
        //'id': 'T12345',                         // Transaction ID. Required for purchases and refunds.
        //'affiliation': 'Online Store',
        //'revenue': '35.43',                     // Total transaction value (incl. tax and shipping)
        //'tax':'4.90',
        //'shipping': '5.99',
        //'coupon': 'SUMMER_SALE'

        public string Id { get; set; }
        public string Affiliation { get; set; }
        public string Revenue { get; set; }
        public string Tax { get; set; }
        public string Shipping { get; set; }
        public string Cupon { get; set; }
    }
}