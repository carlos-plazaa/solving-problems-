using Microsoft.VisualStudio.TestTools.UnitTesting;
using Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPresentation
{
    [TestClass]
    public class EventItemViewModelTest
    {
        [TestMethod]
        public void ConstructorTest()
        {
            DateTime date = new DateTime(2000, 03, 06);
            EventItemViewModel viewModel = new EventItemViewModel(10, 20, 15, date);

            Assert.AreEqual(10, viewModel.EventID);
            Assert.AreEqual(20, viewModel.ClientID);
            Assert.AreEqual(date, viewModel.PurchaseDate);
        }

        [TestMethod]
        public void CanUpdateTest()
        {
            DateTime date = new DateTime(2000, 03, 06);
            EventItemViewModel viewModel = new EventItemViewModel(10, 20, 15, date);

            Assert.IsTrue(viewModel.CanUpdate);
        }

    }
}
