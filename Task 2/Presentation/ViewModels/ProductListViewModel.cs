  using Presentation.ViewModels.MVVNLight;
using Service.CRUD;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Presentation.ViewModels
{
    public class ProductListViewModel : ViewModelBase
    {
        private int productID;
        private decimal price;
        private string category;

        private ICommand addCommand;
        private ICommand deleteCommand;

        private ProductCRUD service;
        private ObservableCollection<ProductItemViewModel> productViewModels;
        private ProductItemViewModel selectedViewModel;
        private bool isProductViewModelSelected;

        public ProductListViewModel()
        {
            service = new ProductCRUD();
            productViewModels = new ObservableCollection<ProductItemViewModel>();

            addCommand = new RelayCommand(e => { AddProduct(); },
                condition => CanAdd);

            deleteCommand = new RelayCommand(e => { DeleteProduct(); },
                condition => ProductViewModelIsSelected());

            isProductViewModelSelected = false;

            GetProducts();
        }

        private void AddProduct()
        {
            service.AddProduct(price, category);
            GetProducts();
        }

        private void DeleteProduct()
        {
            service.DeleteProduct(SelectedVM.ProductID);

            GetProducts();
            OnPropertyChanged(nameof(productViewModels));
        }

        private void GetProducts()
        {
            productViewModels.Clear();

            foreach (var e in service.GetAllProducts())
            {
                productViewModels.Add(new ProductItemViewModel(e.ProductID, e.Price, e.Category));
            }

            OnPropertyChanged(nameof(productViewModels));
        }

        private bool ProductViewModelIsSelected()
        {
            return !(selectedViewModel is null);
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

        public ICommand AddCommand
        {
            get => addCommand;
        }

        public ICommand DeleteCommand
        {
            get => deleteCommand;
        }

        public bool IsProductViewModelSelected
        {
            get => isProductViewModelSelected;
            set
            {
                isProductViewModelSelectedVisibility = value ? Visibility.Visible : Visibility.Hidden;
                isProductViewModelSelected = value;
                OnPropertyChanged(nameof(isProductViewModelSelected));
            }
        }

        private Visibility isProductViewModelSelectedVisibility;

        public Visibility IsProductViewModelSelectedVisibility
        {
            get => isProductViewModelSelectedVisibility;
            set
            {
                isProductViewModelSelectedVisibility = value;
                OnPropertyChanged(nameof(isProductViewModelSelectedVisibility));
            }
        }

        public ObservableCollection<ProductItemViewModel> ProductViewModels
        {
            get => productViewModels;

            set
            {
                productViewModels = value;
                OnPropertyChanged(nameof(productViewModels));
            }
        }

        public ProductItemViewModel SelectedVM
        {
            get => selectedViewModel;
            set
            {
                selectedViewModel = value;
                isProductViewModelSelected = true;
                OnPropertyChanged(nameof(SelectedVM));
            }
        }

        public bool CanAdd => !(
            string.IsNullOrWhiteSpace(productID.ToString()) ||
            string.IsNullOrWhiteSpace(price.ToString()) ||
            string.IsNullOrWhiteSpace(category)
        );
    }
}