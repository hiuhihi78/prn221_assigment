using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WPF_Project.DTOs;
using WPF_Project.Services;
using WPF_Project.Command;
using WPF_Project.Models;
using WPF_Project.Views;

namespace WPF_Project.ViewModels
{
    class ProductManagementViewModel : INotifyPropertyChanged
    {
        #region Declare varibles

        
        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private ProductService productService;

        private CategoryService categoryService;


        private ObservableCollection<ProductDTO> products;

        public ObservableCollection<ProductDTO> Products
        {
            get { return products; }
            set { products = value; OnPropertyChanged(); }
        }

        private ObservableCollection<CategoryDTO> categorys;

        public ObservableCollection<CategoryDTO> Categorys
        {
            get { return categorys; }
            set { categorys = value; OnPropertyChanged(); }
        }

        private string searchProductName;

        public string SearchProductName
        {
            get { return searchProductName; }
            set { searchProductName = value; OnPropertyChanged(); ExecuteSearchProduct(); }
        }

        private int selectedCategory;
        public int SelectedCategory
        {
            get { return selectedCategory; }
            set { selectedCategory = value; OnPropertyChanged(); ExecuteSearchProduct(); }
        }

        public bool IsAdmin { get; set; }

        #endregion

        public ProductManagementViewModel() 
        {
            productService = new ProductService();
            products = new ObservableCollection<ProductDTO>();
            categoryService = new CategoryService();
            selectedCategory = 0;
            searchProductName = "";
            IsAdmin = CheckCurrentUserIsAdmin();
            LoadAllProducts();
            LoadAllCategorys();

            createNewProduct = new RelayCommand(ExecuteCreateNewProduct);
            updateProduct = new RelayCommand<ProductDTO>(ExecuteUpdateProduct, p => true);
            viewProduct = new RelayCommand<ProductDTO>(ExecuteViewProduct, p => true);
        }

        #region Load all list product
        public void LoadAllProducts()
        {
            Products = productService.GetAllProduct();
        }
        #endregion

        #region Load all category
        public void LoadAllCategorys()
        {
            Categorys = categoryService.GetAllCategory();
            Categorys.Add(new CategoryDTO { Id = 0, Name = "All Category" });
        }
        #endregion

        #region Search product

        private RelayCommand searchProduct;

        public RelayCommand SearchProduct
        {
            get { return searchProduct; }
            set { searchProduct = value; OnPropertyChanged(); }
        }

        public void ExecuteSearchProduct()
        {
            ObservableCollection<ProductDTO> result = new ObservableCollection<ProductDTO>();
            var flagGetAllProducts = 0;

            if (selectedCategory == flagGetAllProducts && String.IsNullOrEmpty(SearchProductName))
            {
                LoadAllProducts();
                return;
            }
            else if (selectedCategory == flagGetAllProducts && !String.IsNullOrEmpty(SearchProductName))
            {
                var searchResult = productService.GetListProductByName(SearchProductName);
                foreach (var product in searchResult)
                {
                    result.Add(product);
                }
            }
            else
            {
                var searchResult = productService.GetListProductByNameAndCategory(SearchProductName, SelectedCategory);
                foreach (var product in searchResult)
                {
                    result.Add(product);
                }
            }

            Products = result;
        }
        #endregion

        #region Check current user is Admin
        public bool CheckCurrentUserIsAdmin()
        {
            return ((Staff)(Navigation.NavigationParameters.Parameters["currentUser"])).Role == 1;
        }
        #endregion

        #region Command create new product
        private RelayCommand createNewProduct;

        public RelayCommand CreateNewProduct
        {
            get { return createNewProduct; }
            set { createNewProduct = value; }
        }

        public void ExecuteCreateNewProduct()
        {
            DialogProducts dialogProducts = new DialogProducts();
            dialogProducts.DataContext = new DialogProductsViewModel(dialogProducts, this, null, true);
            dialogProducts.ShowDialog();
        }

        #endregion

        #region Update product commad
        private RelayCommand<ProductDTO> updateProduct;

        public RelayCommand<ProductDTO> UpdateProduct
        {
            get { return updateProduct; }
            set { updateProduct = value; }
        }

        public void ExecuteUpdateProduct(ProductDTO product)
        {
            DialogProducts dialogProducts = new DialogProducts();
            dialogProducts.DataContext = new DialogProductsViewModel(dialogProducts, this, product, true);
            dialogProducts.ShowDialog();
        }

        #endregion

        #region View product commad
        private RelayCommand<ProductDTO> viewProduct;

        public RelayCommand<ProductDTO> ViewProduct
        {
            get { return viewProduct; }
            set { viewProduct = value; }
        }

        public void ExecuteViewProduct(ProductDTO product)
        {
            DialogProducts dialogProducts = new DialogProducts();
            dialogProducts.DataContext = new DialogProductsViewModel(dialogProducts, this, product, false);
            dialogProducts.ShowDialog();
        }

        #endregion


        
        #region Set default selectedCategory
        public void SetDefaultSelectedCategory()
        {
            SelectedCategory = 0;
        }
        #endregion
    }
}
