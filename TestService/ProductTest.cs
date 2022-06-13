using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestService
{
    internal class ProductTest : InterfaceProduct
    {
        public int ProductID { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }

        public ProductTest(int productID, decimal price, string category)
        {
            ProductID = productID;
            Price = price;
            Category = category;
        }
    }
}
