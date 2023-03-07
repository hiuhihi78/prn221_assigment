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
using WPF_Project.Models;
using WPF_Project.Services;
using WPF_Project.Views;

namespace WPF_Project.ViewModels
{
    class DialogProductsViewModel : INotifyPropertyChanged
    {

        #region Declare varibles

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private ProductDTO product;

        public ProductDTO Product
        {
            get { return product; }
            set { product = value; OnPropertyChanged(); }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged(); }
        }


        private ObservableCollection<CategoryDTO> categorys;

        public ObservableCollection<CategoryDTO> Categorys
        {
            get { return categorys; }
            set { categorys = value; OnPropertyChanged(); }
        }

        public bool IsEnableItem { get; set; }
        public bool AllowEnableQuantityField { get; set; }  
        public string InnitProductName { get; set; }    

        private CategoryService categoryService;


        #endregion

        private DialogProducts _dialogProductts;
        private object _viewModelParentScreen;
        private object _productInfo;
        private bool _isUpdate;
        public DialogProductsViewModel(DialogProducts dialogProducts, object viewModelParentScreen, object productInfo, bool isUpadate)
        {
            _dialogProductts = dialogProducts;
            _viewModelParentScreen = viewModelParentScreen;
            _productInfo = productInfo;
            _isUpdate = isUpadate;

            categoryService = new CategoryService();
            product = new ProductDTO() { Discount = 0 , CategoryId = 1};
            IsEnableItem = false;
            LoadData();
            LoadAllCategorys();
            CheckItemEnable();
            AllowEnableQuantityField = productInfo == null;
            InnitProductName = productInfo == null ? string.Empty : ((ProductDTO)productInfo).Name;
            saveCommand = new RelayCommand(ExecuteSaveCommand);
        }

        #region Load data
        public void LoadData()
        {
            if (_productInfo != null)
            {
                Product = _productInfo as ProductDTO;
            }
            else
            {
                Product = new ProductDTO() { Discount = 0, CategoryId = 1 };
            }
        }
        #endregion

        #region Load all category
        public void LoadAllCategorys()
        {
            Categorys = categoryService.GetAllCategory();
        }
        #endregion

        #region Check Item Enable
        public void CheckItemEnable()
        {
            if (_isUpdate || _productInfo ==null)
            {
                IsEnableItem = true;
            }
            else
            {
                IsEnableItem = false;
            }
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

            ShopDbContext context = new ShopDbContext();
            
            if (string.IsNullOrEmpty(Product.Name))
            {
                MessageBox.Show("This Product's name must be not empty!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            else
            {
                bool accept = Int32.TryParse(Product.Quantity.ToString(), out var x) && double.TryParse(Product.Price.ToString(), out var y);
                if (!accept)
                {
                    MessageBox.Show("This Product's Quantity,Price must be a number!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                else
                {
                    var productNameExisted = context.Products.FirstOrDefault(x => x.Name.Equals(Product.Name)) != null;
                    if (productNameExisted == true && Product.Name != InnitProductName)
                    {
                        MessageBox.Show("This Product's name was Existed!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }
                    if (_productInfo == null) //create 
                    {
                        context.Products.Add(new Product{ 
                            Name = Product.Name,
                            CategoryId= Product.CategoryId,
                            Quantity = Product.Quantity,
                            Country = Product.Country,
                            Discount= Product.Discount,
                            Description= "",
                            Price= Product.Price,   
                        });
                        context.SaveChanges();
                    }
                    else
                    {
                        var productUpdate = context.Products.FirstOrDefault(x => x.Id == Product.Id);
                        productUpdate.Price = Product.Price;
                        productUpdate.Discount = Product.Discount;  
                        productUpdate.Description = Product.Description;
                        productUpdate.Price = Product.Price;
                        productUpdate.CategoryId = Product.CategoryId;
                        productUpdate.Quantity = Product.Quantity;
                        productUpdate.Country = Product.Country;
                        context.SaveChanges();
                    }
                    MessageBox.Show("Success!", "Alter", MessageBoxButton.OK, MessageBoxImage.Information);

                    ((ProductManagementViewModel)_viewModelParentScreen).LoadAllProducts();
                    ((ProductManagementViewModel)_viewModelParentScreen).LoadAllCategorys();
                    _dialogProductts.Close();
                }
            }
        }

        #endregion
    }
}
