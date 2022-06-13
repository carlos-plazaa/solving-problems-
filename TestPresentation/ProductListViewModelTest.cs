using Microsoft.VisualStudio.TestTools.UnitTesting;
using Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TestPresentation
{
    [TestClass]
    public class ProductListViewModelTest
    {
        private ProductListViewModel SetViewModel()
        {
            return new ProductListViewModel()
            {
                ProductViewModels = new ObservableCollection<ProductItemViewModel>
                {
                    new ProductItemViewModel(1, 10, "Food"),
                    new ProductItemViewModel(2, 100, "Clothes"),
                    new ProductItemViewModel(3, 1000, "TV")
                }
            };
        }

        [TestMethod]
        public void InitialModelTest()
        {
            try
            {
                ProductListViewModel productListViewModel = SetViewModel();

                Assert.IsNull(productListViewModel.SelectedVM);
                Assert.IsNotNull(productListViewModel.AddCommand);
                Assert.IsNotNull(productListViewModel.DeleteCommand);
            }
            catch (NullReferenceException) { }
        }

        [TestMethod]
        public void CountModelTest()
        {
            try
            {
                ProductListViewModel productListViewModel = SetViewModel();

                Assert.IsNotNull(productListViewModel.ProductViewModels);
                Assert.AreEqual(productListViewModel.ProductViewModels.Count, 2);
            }
            catch (NullReferenceException) { }

        }

        [TestMethod]
        public void DeleteTest()
        {
            try
            {
                ProductListViewModel productListViewModel = SetViewModel();
                productListViewModel.SelectedVM = null;

                ICommand deleteCommand = productListViewModel.DeleteCommand;
                bool can = productListViewModel.IsProductViewModelSelected;

                Assert.IsFalse(deleteCommand.CanExecute(can));
            }
            catch (NullReferenceException) { }

        }
    }
}
