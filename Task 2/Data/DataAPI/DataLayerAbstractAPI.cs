using System;
using System.Collections.Generic;
using System.Linq;
using Data.DataBase;

namespace Data
{
    public abstract class DataLayerAbstractAPI
    {
        public abstract void AddClient(string name, string surname);
        public abstract void DeleteClient(int id);
        public abstract void UpdateClientName(int id, string name);
        public abstract void UpdateClientSurname(int id, string surname);
        public abstract InterfaceUser GetClient(int id);
        public abstract IEnumerable<InterfaceUser> GetAllClients();

        //Product
        public abstract void AddProduct(decimal price, string category);
        public abstract void DeleteProduct(int id);
        public abstract void UpdateProductPrice(int id, decimal price);
        public abstract void UpdateProductCategory(int id, string category);
        public abstract InterfaceProduct GetProduct(int id);
        public abstract IEnumerable<InterfaceProduct> GetAllProducts();


        //Event
        public abstract void AddEvent(int clientId, int productId, DateTime purchaseDate);
        public abstract void DeleteEvent(int id);
        public abstract void UpdateEventClient(int id, int clientId);
        public abstract void UpdateEventProduct(int id, int productId);
        public abstract void UpdateEventPurchaseDate(int id, DateTime purchaseDate);
        public abstract InterfaceEvent GetEvent(int id);
        public abstract IEnumerable<InterfaceEvent> GetAllEvents();

        public static DataLayerAbstractAPI CreateLayer()
        {
            return new DataLayerConcrete();
        }

        public static DataLayerAbstractAPI CreateLayer(string sqlString)
        {
            return new DataLayerConcrete(sqlString);
        }

        private class DataLayerConcrete : DataLayerAbstractAPI
        {
            private DataClasses1DataContext context;
            public DataLayerConcrete()
            {
                context = new DataClasses1DataContext();
            }

            public DataLayerConcrete(string sqlString)
            {
                context = new DataClasses1DataContext(sqlString);
            }

            public override void AddClient(string name, string surname)
            {
                var client = new Client 
                { 
                    ClientID = context.Clients.Count() + 1, 
                    ClientName = name, 
                    ClientSurname = surname 
                };

                context.Clients.InsertOnSubmit(client);
                context.SubmitChanges();
            }

            public override void DeleteClient(int id)
            {
                Client client = context.Clients.FirstOrDefault(x => x.ClientID == id);

                context.Clients.DeleteOnSubmit(client);
                context.SubmitChanges();
            }

            public override void UpdateClientName(int id, string name)
            {
                Client client = context.Clients.FirstOrDefault(x => x.ClientID == id);
                client.ClientName = name;

                context.SubmitChanges();
            }

            public override void UpdateClientSurname(int id, string surname)
            {
                Client client = context.Clients.FirstOrDefault(x => x.ClientID == id);
                client.ClientName = surname;

                context.SubmitChanges();
            }

            public override InterfaceUser GetClient(int id)
            {
                return (InterfaceUser) context.Clients.FirstOrDefault(x => x.ClientID == id);
            }

            public override IEnumerable<InterfaceUser> GetAllClients()
            {
                var clients = from x in context.Clients
                              select (InterfaceUser) x;

                return clients;
            }


            //Product
            public override void AddProduct(decimal price, string category)
            {
                var product = new Product
                {
                    ProductID = context.Clients.Count() + 1,
                    ProductPrice = price,
                    ProductCategory = category
                };
                context.Products.InsertOnSubmit(product);
                context.SubmitChanges();
            }

            public override void DeleteProduct(int id)
            {
                Product product = context.Products.FirstOrDefault(x => x.ProductID == id);

                context.Products.DeleteOnSubmit(product);
                context.SubmitChanges();
            }

            public override void UpdateProductPrice(int id, decimal price)
            {
                Product product = context.Products.FirstOrDefault(x => x.ProductID == id);
                product.ProductPrice = price;

                context.SubmitChanges();
            }

            public override void UpdateProductCategory(int id, string category)
            {
                Product product = context.Products.FirstOrDefault(x => x.ProductID == id);
                product.ProductCategory = category;

                context.SubmitChanges();
            }

            public override InterfaceProduct GetProduct(int id)
            {
                return (InterfaceProduct) context.Products.FirstOrDefault(x => x.ProductID == id);
            }

            public override IEnumerable<InterfaceProduct> GetAllProducts()
            {
                var products = from x in context.Clients
                               select (InterfaceProduct) x;

                return products;
            }


            //Event
            public override void AddEvent(int clientId, int productId, DateTime purchaseDate)
            {
                Event newEvent = new Event
                {
                    EventID = context.Clients.Count() + 1,
                    ClientID = clientId,
                    ProductID = productId,
                    Date = purchaseDate
                };
                context.Events.InsertOnSubmit(newEvent);
                context.SubmitChanges();
            }

            public override void DeleteEvent(int id)
            {
                Event thisEvent = context.Events.FirstOrDefault(x => x.EventID == id);

                context.Events.DeleteOnSubmit(thisEvent);
                context.SubmitChanges();
            }

            public override void UpdateEventClient(int id, int clientId)
            {
                Event thisEvent = context.Events.FirstOrDefault(x => x.EventID == id);
                thisEvent.ClientID = clientId;

                context.SubmitChanges();
            }

            public override void UpdateEventProduct(int id, int productId)
            {
                Event thisEvent = context.Events.FirstOrDefault(x => x.EventID == id);
                thisEvent.ProductID = productId;

                context.SubmitChanges();
            }

            public override void UpdateEventPurchaseDate(int id, DateTime purchaseDate)
            {
                Event thisEvent = context.Events.FirstOrDefault(x => x.EventID == id);
                thisEvent.Date = purchaseDate;

                context.SubmitChanges();
            }

            public override InterfaceEvent GetEvent(int id)
            {
                return (InterfaceEvent) context.Events.FirstOrDefault(x => x.EventID == id);
            }

            public override IEnumerable<InterfaceEvent> GetAllEvents()
            {
                var events = from x in context.Events
                             select (InterfaceEvent) x;

                return events;
            }
        }
    }
}
