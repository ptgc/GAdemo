using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GAdemo.Models.GAdata
{
    public class GAbasket
    {
        public string BasketId { get; set; }
        public List<GAproduct> Items { get; set; }
        public GApurchase TransactionInfo { get; set; }
    }
}