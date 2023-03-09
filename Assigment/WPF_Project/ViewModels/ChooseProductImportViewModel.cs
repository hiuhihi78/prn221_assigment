using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPF_Project.Command;
using WPF_Project.DTOs;
using WPF_Project.Navigation;
using WPF_Project.Services;
using WPF_Project.Views;

namespace WPF_Project.ViewModels
{
    public class ChooseProductImportViewModel : INotifyPropertyChanged
    {
        #region Declare varible

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        private ProductDTO product;

        public ProductDTO Product
        {
            get { return product; }
            set { product = value; OnPropertyChanged(); UpdateTotalPrice(); }
        }

        private ObservableCollection<ProductDTO> listProduct;

        public ObservableCollection<ProductDTO> ListProduct
        {
            get { return listProduct; }
            set { listProduct = value; OnPropertyChanged(); }
        }

        private string searchProduct;

        public string SearchProduct
        {
            get { return searchProduct; }
            set { searchProduct = value; OnPropertyChanged(); LoadListProduct(); }
        }


        public string Total { get; set; }


        #endregion


        private ChooseProductImport _chooseProductImport;
        private object _viewModelParentScreen;
        private ProductService productService = new ProductService();
        public ChooseProductImportViewModel(ChooseProductImport chooseProductImport, object viewModelParentScreen)
        {
            _chooseProductImport = chooseProductImport;
            _viewModelParentScreen = viewModelParentScreen;

            product = new ProductDTO()
            {
                Quantity = 10,
                Price = 1000,
                Discount = 0,
            };
            Total = "0";
            searchProduct = string.Empty;
            listProduct = new ObservableCollection<ProductDTO>();
            LoadListProduct();
            UpdateTotalPrice(); 

            chooseProductCommand = new RelayCommand<ProductDTO>(ExecuteChooseProductCommand);
            saveCommand = new RelayCommand(ExecuteSaveCommand);
        }

        #region Load list product
        private void LoadListProduct()
        {
            ListProduct = productService.GetListProductByName(SearchProduct);
        }
        #endregion

        #region Choose Product Command
        private RelayCommand<ProductDTO> chooseProductCommand;

        public RelayCommand<ProductDTO> ChooseProductCommand
        {
            get { return chooseProductCommand; }
            set { chooseProductCommand = value; }
        }

        public void ExecuteChooseProductCommand(ProductDTO productSelected)
        {
            Product.Id = productSelected.Id;
            Product.Name = productSelected.Name;
            product.Category = productSelected.Category;
            UpdateTotalPrice();
        }

        #endregion

        #region Save command
        private RelayCommand saveCommand;

        public RelayCommand SaveCommand
        {
            get { return saveCommand; }
            set { saveCommand = value; }
        }

        public void ExecuteSaveCommand()
        {
            if (Product.Name == null)
            {
                MessageBox.Show("You must choose a product!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            else
            {
                MessageBoxResult comfrim = MessageBox.Show("Are you sure you want to do this?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (comfrim == MessageBoxResult.Yes)
                {
                    var productImport = new ProductDTO()
                    {
                        Id = Product.Id,
                        Name = Product.Name,
                        Quantity = Product.Quantity,
                        Price = Product.Price,
                        Discount = Product.Discount,
                        Category =  Product.Category,
                    };

                    if (Navigation.NavigationParameters.Parameters.ContainsKey("listImported"))
                    {

                        var ListImportProduct = ((ObservableCollection<ProductDTO>)NavigationParameters.Parameters["listImported"]);
                        ListImportProduct.Add(productImport);
                        NavigationParameters.Parameters.Remove("listImported");
                        NavigationParameters.Parameters.Add("listImported", ListImportProduct);
                    }
                    
                    ((ImportViewModel)_viewModelParentScreen).UpdateListProductImport();
                    ((ImportViewModel)_viewModelParentScreen).UpdateTotalPriceImport();
                    ((ImportViewModel)_viewModelParentScreen).UpdateStatusCheckoutImport();
                    _chooseProductImport.Close();
                }
            }
        }

        #endregion

        #region Update total price
        public void UpdateTotalPrice()
        {
            if(Product.Price.ToString().Length == 0 || Product.Quantity.ToString().Length == 0 || Product.Discount.ToString().Length == 0)
            {
                Total = "0";
            }
            else
            {
                var totalPrice = Product.Price * Product.Quantity - (Product.Price * Product.Quantity) * Product.Discount;
                Total = totalPrice.ToString();
            }
        }
        #endregion
    }
}
