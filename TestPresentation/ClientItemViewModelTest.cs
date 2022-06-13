using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Presentation.ViewModels;
using System.Windows.Input;

namespace TestPresentation
{
    [TestClass]
    public class ClientItemViewModelTest
    {
        [TestMethod]
        public void ConstructorTest()
        {
            ClientItemViewModel viewModel = new ClientItemViewModel(10, "Carlos", "Plaza");

            Assert.AreEqual(10, viewModel.ClientID);
            Assert.AreEqual("Carlos", viewModel.Name);
            Assert.AreEqual("Plaza", viewModel.Surname);
        }

        [TestMethod]
        public void CanUpdateTest()
        {
            ClientItemViewModel viewModel = new ClientItemViewModel(20, "Victor", "Pernas");

            Assert.IsTrue(viewModel.CanUpdate);
        }

       
    }
}
