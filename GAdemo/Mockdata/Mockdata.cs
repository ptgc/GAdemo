using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GAdemo.Models.GAdata;

namespace GAdemo.Mockdata
{
    public class Mockdata
    {
        public static List<GAproduct> GetGAproducts()
        {
            var products = new List<GAproduct>()
            {
                new GAproduct()
                {
                    Id = "1",
                    Name = "CDU UX Lyntale",
                    Price = "15",
                    Brand = "Ciber CDU",
                    Category = "Ciber/CDU/Speech/Lightning",
                    Variant = "UX",
                    Quantity = "1",
                    Cupon = "",
                    List = "UX-list",
                    Position = "1"

                },
                new GAproduct()
                {
                    Id = "2",
                    Name = "CDU UX Tale",
                    Price = "30",
                    Brand = "Ciber CDU",
                    Category = "Ciber/CDU/Speech/Regular",
                    Variant = "UX",
                    Quantity = "1",
                    Cupon = "",
                    List = "UX-list",
                    Position = "2"

                },
                new GAproduct()
                {
                    Id = "3",
                    Name = "CDU UX Lang tale",
                    Price = "45",
                    Brand = "Ciber CDU",
                    Category = "Ciber/CDU/Speech/Long",
                    Variant = "UX",
                    Quantity = "1",
                    Cupon = "",
                    List = "UX-list",
                    Position = "3"

                },
                new GAproduct()
                {
                    Id = "4",
                    Name = "CDU Front-end Lyntale",
                    Price = "150",
                    Brand = "Ciber CDU",
                    Category = "Ciber/CDU/Speech/Lightning",
                    Variant = "Front-end",
                    Quantity = "1",
                    Cupon = "",
                    List = "Front-end-list",
                    Position = "1"

                },
                new GAproduct()
                {
                    Id = "5",
                    Name = "CDU Front-end Tale",
                    Price = "300",
                    Brand = "Ciber CDU",
                    Category = "Ciber/CDU/Speech/Regular",
                    Variant = "Front-end",
                    Quantity = "1",
                    Cupon = "",
                    List = "Front-end-list",
                    Position = "2"

                },
                new GAproduct()
                {
                    Id = "6",
                    Name = "CDU Front-end Lang tale",
                    Price = "450",
                    Brand = "Ciber CDU",
                    Category = "Ciber/CDU/Speech/Long",
                    Variant = "UX",
                    Quantity = "1",
                    Cupon = "",
                    List = "UX-list",
                    Position = "3"

                },
                new GAproduct()
                {
                    Id = "7",
                    Name = "CDU Felles Lyntale",
                    Price = "1500",
                    Brand = "Ciber CDU",
                    Category = "Ciber/CDU/Speech/Lightning",
                    Variant = "Felles",
                    Quantity = "1",
                    Cupon = "",
                    List = "Felles-list",
                    Position = "1"

                },
                new GAproduct()
                {
                    Id = "8",
                    Name = "CDU Felles Tale",
                    Price = "3000",
                    Brand = "Ciber CDU",
                    Category = "Ciber/CDU/Speech/Regular",
                    Variant = "Felles",
                    Quantity = "1",
                    Cupon = "",
                    List = "Felles-list",
                    Position = "2"

                },
                new GAproduct()
                {
                    Id = "9",
                    Name = "CDU Felles Lang tale",
                    Price = "4500",
                    Brand = "Ciber CDU",
                    Category = "Ciber/CDU/Speech/Long",
                    Variant = "Felles",
                    Quantity = "1",
                    Cupon = "",
                    List = "Felles-list",
                    Position = "3"

                },
                new GAproduct()
                {
                    Id = "10",
                    Name = "Default ",
                    Price = "1234",
                    Brand = "Ciber CDU",
                    Category = "Ciber/CDU/Default",
                    Variant = "Default",
                    Quantity = "1",
                    Cupon = "",
                    List = "No-list",
                    Position = "1"
                }
            };
            return products;
        }
        public static GAproduct GetMockProduct(int productNumber)
        {
            var product = GetGAproducts()[productNumber - 1];
            return product;
        }

        public static GApurchase GetGApurchase(GAbasket basket)
        {
            if (basket == null || !basket.Items.Any()) return null;
            var totalPrice = basket.Items.Sum(p => Convert.ToInt32(p.Price));
            var purchase = new GApurchase()
            {
                Id = Utils.Utils.RandomString(7),
                Affiliation = "CDU GA demo store",
                Revenue = totalPrice.ToString(),
                Tax = (totalPrice*0.25).ToString(),
                Shipping = (totalPrice*0.10).ToString(),
                Cupon = ""
            };
            return purchase;
        }
    }
}