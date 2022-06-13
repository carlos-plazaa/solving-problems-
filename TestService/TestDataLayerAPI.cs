using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestService
{
    public class TestDataLayerAPI : DataLayerAbstractAPI
    {
        public List<InterfaceUser> Clients = new List<InterfaceUser>();
        public List<InterfaceEvent> Events = new List<InterfaceEvent>();
        public List<InterfaceProduct> Products = new List<InterfaceProduct>();


        public override void AddClient(string name, string surname)
        {
            Clients.Add(new ClientTest(Clients.Count + 1, name, surname));
        }

        public override void DeleteClient(int id)
        {
            Clients.RemoveAt(id - 1);
        }

        public override void UpdateClientName(int id, string name)
        {
            Clients[id - 1].Name = name;
        }

        public override void UpdateClientSurname(int id, string surname)
        {
            Clients[id - 1].Surname = surname;
        }

        public override InterfaceUser GetClient(int id)
        {
            return Clients[id - 1];
        }

        public override IEnumerable<InterfaceUser> GetAllClients()
        {
            var result = new List<InterfaceUser>();

            foreach (var client in Clients)
            {
                result.Add(client);
            }

            return result;
        }



        public override void AddEvent(int clientId, int productId, DateTime purchaseDate)
        {
            Events.Add(new EventTest(Events.Count + 1, clientId, productId, purchaseDate));
        }

        public override void DeleteEvent(int id)
        {
            Events.RemoveAt(id - 1);
        }

        public override void UpdateEventClient(int id, int clientId)
        {
            Events[id - 1].UserID = clientId;
        }

        public override void UpdateEventProduct(int id, int productId)
        {
            Events[id - 1].UserID = productId;
        }

        public override void UpdateEventPurchaseDate(int id, DateTime purchaseDate)
        {
            Events[id - 1].PurchaseDate = purchaseDate;
        }

        public override InterfaceEvent GetEvent(int id)
        {
            return Events[id - 1];
        }

        public override IEnumerable<InterfaceEvent> GetAllEvents()
        {
            var result = new List<InterfaceEvent>();

            foreach (var e in Events)
            {
                result.Add(e);
            }

            return result;
        }



        public override void AddProduct(decimal price, string category)
        {
            Products.Add(new ProductTest(Products.Count + 1, price, category));
        }

        public override void DeleteProduct(int id)
        {
            Products.RemoveAt(id - 1);
        }

        public override void UpdateProductPrice(int id, decimal price)
        {
            Products[id - 1].Price = price;
        }

        public override void UpdateProductCategory(int id, string category)
        {
            Products[id - 1].Category = category;
        }

        public override InterfaceProduct GetProduct(int id)
        {
            return Products[id - 1];
        }

        public override IEnumerable<InterfaceProduct> GetAllProducts()
        {
            var result = new List<InterfaceProduct>();

            foreach (var e in Products)
            {
                result.Add(e);
            }

            return result;
        }
    }
}
