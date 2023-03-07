using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WPF_Project.Command;
using WPF_Project.DTOs;
using WPF_Project.Navigation;
using WPF_Project.Services;
using WPF_Project.Views;

namespace WPF_Project.ViewModels
{
    public class ImportViewModel : INotifyPropertyChanged
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

        private ObservableCollection<ProductDTO> listOrderProduct;

        public ObservableCollection<ProductDTO> ListOrderProduct
        {
            get { return listOrderProduct; }
            set { listOrderProduct = value; OnPropertyChanged(); UpdateTotalPriceOrder(); UpdateStatusCheckoutOrder(); }
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
            set { searchProductName = value; OnPropertyChanged(); }
        }

        private double totalPriceOrder;

        public double TotalPriceOrder
        {
            get { return totalPriceOrder; }
            set { totalPriceOrder = value; OnPropertyChanged(); }
        }

        private bool enableButtonCheckout;

        public bool EnableButtonCheckout
        {
            get { return enableButtonCheckout; }
            set { enableButtonCheckout = value; OnPropertyChanged(); }
        }

        private int selectedCategory;
        public int SelectedCategory
        {
            get { return selectedCategory; }
            set { selectedCategory = value; OnPropertyChanged(); }
        }


        #endregion

        #region Contructor
        public ImportViewModel()
        {
            productService = new ProductService();
            products = new ObservableCollection<ProductDTO>();
            listOrderProduct = new ObservableCollection<ProductDTO>();
            addToCart = new RelayCommand<ProductDTO>(ExecuteAddProductToListOrder, CanExecuteAddProductToListOrder);
            removeProductInCart = new RelayCommand<ProductDTO>(ExecuteDeleteProductInCart, CanExecuteDeleteProductInCart);
            categoryService = new CategoryService();
            selectedCategory = 0;
            searchProductName = "";
            searchProduct = new RelayCommand(ExecuteSearchProduct);
            totalPriceOrder = 0;
            enableButtonCheckout = false;
            checkoutOrder = new RelayCommand(ExecuteCheckoutOrder);
            priceChangedCommand = new RelayCommand<ProductDTO>(ExecutePriceChangedCommand, p => true);
            passwordChangedCommand = new RelayCommand<object>(HandleGetPassword, p => true);
            LoadListProductOrderd();
            LoadAllCategorys();
            LoadAllProducts();
            UpdateTotalPriceOrder();
            UpdateStatusCheckoutOrder();
        }
        #endregion

        #region Load all list product
        public void LoadAllProducts()
        {
            Products = productService.GetAllProduct();
        }
        #endregion

        #region Load list product ordered

        public void LoadListProductOrderd()
        {
            if (NavigationParameters.Parameters.ContainsKey("listImported"))
            {
                var productsOrdered = (ObservableCollection<ProductDTO>)NavigationParameters.Parameters["listImported"];
                listOrderProduct = productsOrdered;
            }
            else
            {
                listOrderProduct = new ObservableCollection<ProductDTO>();
            }
        }

        #endregion

        #region Load all category
        public void LoadAllCategorys()
        {
            Categorys = categoryService.GetAllCategory();
            Categorys.Add(new CategoryDTO { Id = 0, Name = "All Category" });
        }
        #endregion

        #region Add to cart

        private RelayCommand<ProductDTO> addToCart;

        public RelayCommand<ProductDTO> AddToCart
        {
            get { return addToCart; }
            set { addToCart = value; OnPropertyChanged(); }
        }

        private void ExecuteAddProductToListOrder(ProductDTO productSelected)
        {
            bool productExsited = ListOrderProduct.FirstOrDefault(x => x.Id == productSelected.Id) != null;
            if (productExsited)
            {
                for (int i = 0; i < ListOrderProduct.Count(); i++)
                {
                    if (ListOrderProduct[i].Id == productSelected.Id)
                    {
                        ListOrderProduct[i].Quantity = ListOrderProduct[i].Quantity + 1;
                    }
                }
            }
            else
            {
                ProductDTO product = productService.GetProductById(productSelected.Id);
                if (product == null)
                {

                }
                else
                {
                    product.Quantity = 1;
                    ListOrderProduct.Add(product);
                }
            }

            UpdateTotalPriceOrder();
            UpdateStatusCheckoutOrder();
            UpdateValueNavigationParameter();
        }

        private bool CanExecuteAddProductToListOrder(ProductDTO product)
        {
            // Return true or false to enable/disable the command
            return true;
        }
        #endregion

        #region Remove a Product In Cart

        private RelayCommand<ProductDTO> removeProductInCart;

        public RelayCommand<ProductDTO> RemoveProductInCart
        {
            get { return removeProductInCart; }
            set { removeProductInCart = value; }
        }

        private void ExecuteDeleteProductInCart(ProductDTO selectedRemoveProduct)
        {
            listOrderProduct.Remove(selectedRemoveProduct);
            UpdateTotalPriceOrder();
            UpdateStatusCheckoutOrder();
            UpdateValueNavigationParameter();
        }

        private bool CanExecuteDeleteProductInCart(ProductDTO selectedRemoveProduct)
        {
            bool productExisted = listOrderProduct.FirstOrDefault(x => x.Id == selectedRemoveProduct.Id) != null;
            return productExisted;
        }

        #endregion

        #region Update total price order
        public void UpdateTotalPriceOrder()
        {
            double total = 0;
            foreach (var product in ListOrderProduct)
            {
                total += (product.Quantity * product.Price);
            }
            TotalPriceOrder = total;
        }
        #endregion

        #region Update status button checkout order
        public void UpdateStatusCheckoutOrder()
        {
            EnableButtonCheckout = TotalPriceOrder > 0;
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

        #region Checkout Order (Navigation to screen checkout order)

        private RelayCommand checkoutOrder;

        public RelayCommand CheckoutOrder
        {
            get { return checkoutOrder; }
            set { checkoutOrder = value; OnPropertyChanged(); }
        }

        private void ExecuteCheckoutOrder()
        {
            if (!NavigationParameters.Parameters.ContainsKey("listImported"))
            {
                NavigationParameters.Parameters.Add("listImported", ListOrderProduct);
            }
            if (!NavigationParameters.Parameters.ContainsKey("totalPriceImport"))
            {
                NavigationParameters.Parameters.Add("totalPriceImport", TotalPriceOrder);
            }
            NavigationFrameContentHomeScreen.NavigateTo(new CheckoutImport());
        }
        #endregion

        #region Update value Navigation Parameter

        public void UpdateValueNavigationParameter()
        {
            if (!NavigationParameters.Parameters.ContainsKey("listImported"))
            {
                NavigationParameters.Parameters.Add("listImported", ListOrderProduct);
            }
            else
            {
                NavigationParameters.Parameters.Remove("listImported");
                NavigationParameters.Parameters.Add("listImported", ListOrderProduct);
            }
            if (!NavigationParameters.Parameters.ContainsKey("totalPriceImport"))
            {
                NavigationParameters.Parameters.Add("totalPriceImport", TotalPriceOrder);
            }
            else
            {
                NavigationParameters.Parameters.Remove("totalPriceImport");
                NavigationParameters.Parameters.Add("totalPriceImport", TotalPriceOrder);
            }
        }

        #endregion

        #region PriceChangedCommand

        private RelayCommand<ProductDTO> priceChangedCommand;

        public RelayCommand<ProductDTO> PriceChangedCommand
        {
            get { return priceChangedCommand; }
            set { priceChangedCommand = value; OnPropertyChanged(); }
        }

        public void ExecutePriceChangedCommand(ProductDTO product)
        {

        }

        public bool CanExecutePriceChangedCommand(ProductDTO product)
        {
            return true;
        }


        #endregion


        #region PasswordChangedCommand test
        private RelayCommand<object> passwordChangedCommand;

        public RelayCommand<object> PasswordChangedCommand
        {
            get { return passwordChangedCommand; }
            set { passwordChangedCommand = value; }
        }

        private void HandleGetPassword(object passwordBox)
        {
            
        }

        #endregion

    }
}
