using Data;
using Data.DataBase;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestData
{
    [TestClass]
    public class DataTest
    {
        private DataLayerAbstractAPI dataLayer;


        [TestMethod]
        public void GetAllClientsTest()
        {
            dataLayer = DataLayerAbstractAPI.CreateLayer();

            Assert.AreEqual(2, dataLayer.GetAllClients().Count());
        }

        [TestMethod]
        public void GetAllEventsTest()
        {
            dataLayer = DataLayerAbstractAPI.CreateLayer();

            Assert.AreEqual(2, dataLayer.GetAllEvents().Count());
        }

        [TestMethod]
        public void GetAllProductsTest()
        {
            dataLayer = DataLayerAbstractAPI.CreateLayer();

            Assert.AreEqual(2, dataLayer.GetAllProducts().Count());
        }
    }
}
