namespace GAdemo.Models.GAdata
{
    public class GAproduct
    {

       // 'name': 'Triblend Android T-Shirt',       // Name or ID is required.
       //'id': '12345',
       //'price': '15.25',
       //'brand': 'Google',
       //'category': 'Apparel',
       //'variant': 'Gray',
       //'list': 'Search Results',
       //'position': 1
        public string Name { get; set; }

        public string Id { get; set; }

        public string Price { get; set; }
        public string Brand { get; set; }
        public string Category { get; set; }
        public string Variant { get; set; }
        public string List { get; set; }
        public string Position { get; set; }

        public string Quantity { get; set; }
        public string Cupon { get; set; }
    }
}