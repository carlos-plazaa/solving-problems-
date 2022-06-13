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
    public class ProductItemViewModelTest
    {
        [TestMethod]
        public void ConstructorTest()
        {
            ProductItemViewModel viewModel = new ProductItemViewModel(10, (decimal) 22.22, "Food");

            Assert.AreEqual(10, viewModel.ProductID);
            Assert.AreEqual((decimal) 22.22, viewModel.Price);
            Assert.AreEqual("Food", viewModel.Category);
        }

        [TestMethod]
        public void CanUpdateTest()
        {
            ProductItemViewModel viewModel = new ProductItemViewModel(5, (decimal)111.1, "Clothes");

            Assert.IsTrue(viewModel.CanUpdate);
        }

    }
}
