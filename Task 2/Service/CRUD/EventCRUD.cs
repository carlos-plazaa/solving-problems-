using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Service.Data;

namespace Service.CRUD
{
    public class EventCRUD
    {
        private DataLayerAbstractAPI dataLayer;

        public EventCRUD()
        {
            dataLayer = DataLayerAbstractAPI.CreateLayer();
        }

        public EventCRUD(DataLayerAbstractAPI dataLayer)
        {
            this.dataLayer = dataLayer;
        }

        private EventData Map(InterfaceEvent e)
        {
            if (e == null)
            {
                return null;
            }

            return new EventData
            {
                EventID = e.EventID,
                UserID = e.UserID,
                ProductID = e.ProductID,
                PurchaseDate = e.PurchaseDate
            };
        }

        public void AddEvent(int userId, int productId, DateTime purchaseDate)
        {
            dataLayer.AddEvent(userId, productId, purchaseDate);
        }

        public void DeleteEvent(int id)
        {
            dataLayer.DeleteEvent(id);
        }

        public void UpdateEventClient(int id, int userId)
        {
            dataLayer.UpdateEventClient(id, userId);
        }

        public void UpdateEventProduct(int id, int productId)
        {
            dataLayer.UpdateEventProduct(id, productId);
        }

        public void UpdateEventPurchaseDate(int id, DateTime purchaseDate)
        {
            dataLayer.UpdateEventPurchaseDate(id, purchaseDate); 
        }

        public EventData GetEvent(int id)
        {
            return Map(dataLayer.GetEvent(id));
        }

        public IEnumerable<EventData> GetAllEvents()
        {
            var clients = dataLayer.GetAllEvents();
            var result = new List<EventData>();

            foreach (var client in clients)
            {
                result.Add(Map(client));
            }

            return result;
        }
    }

}
