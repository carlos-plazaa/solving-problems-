using Presentation.ViewModels.MVVNLight;
using Service.CRUD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Presentation.ViewModels
{
    public class ProductItemViewModel : ViewModelBase
    {
        private int productID;
        private decimal price;
        private string category;

        private ProductCRUD service;
        private ICommand updateCommand;

        public ProductItemViewModel(int productID, decimal price, string category)
        {
            this.productID = productID;
            this.price = price;
            this.category = category;
        }

        public ProductItemViewModel()
        {
            service = new ProductCRUD();
            updateCommand = new RelayCommand(e => { UpdateProduct(); }, c => CanUpdate);
        }

        public int ProductID
        {
            get => productID;

            set
            {
                productID = value;
                OnPropertyChanged(nameof(productID));
            }
        }

        public decimal Price
        {
            get => price;
            set
            {
                price = value;

                OnPropertyChanged(nameof(price));
            }
        }

        public string Category
        {
            get => category;
            set
            {
                category = value;

                OnPropertyChanged(nameof(category));
            }
        }

        public ICommand UpdateCommand
        {
            get => updateCommand;
        }

        public bool CanUpdate => !(
            string.IsNullOrWhiteSpace(productID.ToString()) ||
            string.IsNullOrWhiteSpace(price.ToString()) ||
            string.IsNullOrWhiteSpace(category)
        );

        private void UpdateProduct()
        {
            service.UpdateProductPrice(productID, price);
            service.UpdateProductCategory(productID, category);
        }
    }
}
