using Microsoft.VisualStudio.TestTools.UnitTesting;
using Service.CRUD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestService
{
    [TestClass]
    public class ServiceProductTest
    {
        [TestMethod]
        public void AddDeleteProductTest()
        {
            ProductCRUD productService = new ProductCRUD(new TestDataLayerAPI());

            productService.AddProduct(10, "Book");

            Assert.AreEqual(productService.GetProduct(1).Category, "Book");

            productService.DeleteProduct(1);
        }

        [TestMethod]
        public void UpdateProductTest()
        {
            ProductCRUD productService = new ProductCRUD(new TestDataLayerAPI());

            productService.AddProduct(10, "Book");
            productService.UpdateProductCategory(1, "Book");

            Assert.AreEqual(productService.GetProduct(1).Category, "Book");

            productService.DeleteProduct(1);
        }

        [TestMethod]
        public void GetProductTest()
        {
            ProductCRUD productService = new ProductCRUD(new TestDataLayerAPI());

            Assert.AreEqual(productService.GetAllProducts().Count(), 0);
        }
    }
}
