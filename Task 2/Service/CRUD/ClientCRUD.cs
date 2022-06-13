using Data;
using Service.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.CRUD
{
    public class ClientCRUD
    {
        private DataLayerAbstractAPI dataLayer;

        public ClientCRUD()
        {
            dataLayer = DataLayerAbstractAPI.CreateLayer();
        }

        public ClientCRUD(DataLayerAbstractAPI dataLayer)
        {
            this.dataLayer = dataLayer;
        }

        private ClientData Map(InterfaceUser client)
        {
            if (client == null)
            {
                return null;
            }

            return new ClientData
            {
                UserID = client.UserID,
                Name = client.Name,
                Surname = client.Surname
            };
        }

        public void AddClient(string name, string surname)
        {
            dataLayer.AddClient(name, surname);
        }

        public void DeleteClient(int id)
        {
            dataLayer.DeleteClient(id);
        }

        public void UpdateClientName(int id, string name)
        {
            dataLayer.UpdateClientName(id, name);
        }

        public void UpdateClientSurname(int id, string surname)
        {
            dataLayer.UpdateClientSurname(id, surname);
        }

        public ClientData GetClient(int id)
        {
            return Map(dataLayer.GetClient(id));
        }

        public IEnumerable<ClientData> GetAllClients()
        {
            var clients = dataLayer.GetAllClients();
            var result = new List<ClientData>();

            foreach (var client in clients)
            {
                result.Add(Map(client));
            }

            return result;
        }
    }
}
