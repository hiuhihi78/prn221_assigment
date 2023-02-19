using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WPF_Project.Command;
using WPF_Project.DTOs;
using WPF_Project.Services;
using WPF_Project.Navigation;
using WPF_Project.Views;

namespace WPF_Project.ViewModels
{
    public class OrderViewModel : INotifyPropertyChanged
    {

        #region Declare variables

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
            set { listOrderProduct = value; OnPropertyChanged(); }
        }

        private ObservableCollection<CategoryDTO> categorys;

        public ObservableCollection<CategoryDTO> Categorys
        {
            get { return categorys; }
            set { categorys = value; OnPropertyChanged(); }
        }

        private ProductDTO selectedProduct;
        public ProductDTO SelectedProduct
        {
            get { return selectedProduct; }
            set { selectedProduct = value; OnPropertyChanged(); }
        }

        private ProductDTO selectedRemoveProduct;
        public ProductDTO SelectedRemoveProduct
        {
            get { return selectedRemoveProduct; }
            set { selectedRemoveProduct = value; OnPropertyChanged(); }
        }


        private int selectedCategory;
        public int SelectedCategory
        {
            get { return selectedCategory; }
            set { selectedCategory = value; OnPropertyChanged(); }
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


        #endregion

        #region Contructor

        public OrderViewModel()
        {
            productService = new ProductService();
            products = new ObservableCollection<ProductDTO>();
            listOrderProduct = new ObservableCollection<ProductDTO>();
            addToCart = new RelayCommand<ProductDTO>(ExecuteAddProductToListOrder, CanExecuteAddProductToListOrder);
            selectedProduct = new ProductDTO();
            selectedRemoveProduct = new ProductDTO();
            removeProductInCart = new RelayCommand<ProductDTO>(ExecuteDeleteProductInCart, CanExecuteDeleteProductInCart);
            categoryService = new CategoryService();
            selectedCategory = 0;
            searchProductName = "";
            searchProduct = new RelayCommand(ExecuteSearchProduct);
            totalPriceOrder = 0;
            enableButtonCheckout = false;
            checkoutOrder = new RelayCommand(ExecuteCheckoutOrder);
            LoadListProductOrderd();
            LoadAllCategorys();
            LoadAllProducts();
        }
        #endregion

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

        #region Load list product ordered

        public void LoadListProductOrderd()
        {
            try
            {
                var productsOrdered = (ObservableCollection<ProductDTO>)NavigationParameters.Parameters["listOrder"];
                listOrderProduct = productsOrdered;
            }
            catch(Exception ex) //-- not found
            {
                listOrderProduct = new ObservableCollection<ProductDTO>();
            }
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
            bool productExsited = listOrderProduct.FirstOrDefault(x => x.Id == productSelected.Id) != null;
            if (productExsited)
            {
                for (int i = 0; i < listOrderProduct.Count(); i++)
                {
                    if (listOrderProduct[i].Id == productSelected.Id)
                    {
                        listOrderProduct[i].Quantity = listOrderProduct[i].Quantity + 1;
                    }
                }
            }
            else
            {
                ProductDTO product = productService.GetProductById(productSelected.Id);
                if (product == null)
                {

                }
                else if (product.Quantity == 0)
                {

                }
                else
                {
                    product.Quantity = 1;
                    listOrderProduct.Add(product);
                }
            }

            UpdateTotalPriceOrder();
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
        }

        private bool CanExecuteDeleteProductInCart(ProductDTO selectedRemoveProduct)
        {
            bool productExisted = listOrderProduct.FirstOrDefault(x => x.Id == selectedRemoveProduct.Id) != null;
            UpdateTotalPriceOrder();
            UpdateStatusCheckoutOrder();
            return productExisted;
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
            }else if(selectedCategory == flagGetAllProducts && !String.IsNullOrEmpty(SearchProductName))
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

        #region Update total price order
        public void UpdateTotalPriceOrder()
        {
            double total = 0;
            foreach (var product in ListOrderProduct) 
            {
                total += (product.Quantity * product.Price) - (product.Quantity * product.Price) * product.Discount/100;
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

        #region Checkout Order (Navigation to screen checkout order)

        private RelayCommand checkoutOrder;

        public RelayCommand CheckoutOrder
        {
            get { return checkoutOrder; }
            set { checkoutOrder = value; OnPropertyChanged(); }
        }

        private void ExecuteCheckoutOrder()
        {
            if (!NavigationParameters.Parameters.ContainsKey("listOrder"))
            {
                NavigationParameters.Parameters.Add("listOrder", ListOrderProduct);
            }
            if (!NavigationParameters.Parameters.ContainsKey("totalPriceOrder"))
            {
                NavigationParameters.Parameters.Add("totalPriceOrder", TotalPriceOrder);
            }
            NavigationFrameContentHomeScreen.NavigateTo(new CheckoutOrder());
        }
        #endregion
    }
}


