using Data;
using Service.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.CRUD
{
    public class ProductCRUD
    {
        private DataLayerAbstractAPI dataLayer;

        public ProductCRUD()
        {
            dataLayer = DataLayerAbstractAPI.CreateLayer();
        }

        public ProductCRUD(DataLayerAbstractAPI dataLayer)
        {
            this.dataLayer = dataLayer;
        }

        private ProductData Map(InterfaceProduct product)
        {
            if (product == null)
            {
                return null;
            }

            return new ProductData
            {
                ProductID = product.ProductID,
                Price = product.Price,
                Category = product.Category
            };
        }

        public void AddProduct(decimal price, string category)
        {
            dataLayer.AddProduct(price, category);
        }

        public void DeleteProduct(int id)
        {
            dataLayer.DeleteProduct(id);
        }

        public void UpdateProductPrice(int id, decimal price)
        {
            dataLayer.UpdateProductPrice(id, price);
        }

        public void UpdateProductCategory(int id, string category)
        {
            dataLayer.UpdateProductCategory(id, category);
        }

        public ProductData GetProduct(int id)
        {
            return Map(dataLayer.GetProduct(id));
        }

        public IEnumerable<ProductData> GetAllProducts()
        {
            var clients = dataLayer.GetAllProducts();
            var result = new List<ProductData>();

            foreach (var client in clients)
            {
                result.Add(Map(client));
            }

            return result;
        }
    }
}
