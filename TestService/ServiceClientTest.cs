using Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Service.Data;
using Service.CRUD;
using System;
using System.Linq;

namespace TestService
{
    [TestClass]
    public class ServiceClientTest
    {
        [TestMethod]
        public void AddDeleteClientTest()
        {
            ClientCRUD clientService = new ClientCRUD(new TestDataLayerAPI());

            clientService.AddClient("Carlos", "Plaza");
            clientService.GetClient(1);
            clientService.DeleteClient(1);
        }

        [TestMethod]
        public void UpdateClientTest()
        {
            ClientCRUD clientService = new ClientCRUD(new TestDataLayerAPI());

            clientService.AddClient("Carlos", "Plaza");
            clientService.UpdateClientName(1, "Victor");

            Assert.AreEqual(clientService.GetClient(1).Name, "Victor");

            clientService.DeleteClient(1);
        }

        [TestMethod]
        public void GetUsersTest()
        {
            ClientCRUD clientService = new ClientCRUD(new TestDataLayerAPI());

            Assert.AreEqual(clientService.GetAllClients().Count(), 0);
        }

    }
}
