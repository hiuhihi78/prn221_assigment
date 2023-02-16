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
using WPF_Project.Models;

namespace WPF_Project.ViewModels
{
    public class OrderViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #region Declare

        private ObservableCollection<Product> products;

        private ProductService productService;

        public ObservableCollection<Product> Products
        {
            get { return products; }
            set { products = value; OnPropertyChanged(); }
        }

        private ObservableCollection<Product> listOrderProduct;

        public ObservableCollection<Product> ListOrderProduct
        {
            get { return listOrderProduct; }
            set {  listOrderProduct= value; OnPropertyChanged(); }
        }

        private Product selectedProduct;
        public Product SelectedProduct
        {
            get { return selectedProduct; }
            set { selectedProduct = value; OnPropertyChanged(); }
        }

        private Product selectedRemoveProduct;
        public Product SelectedRemoveProduct
        {
            get { return selectedRemoveProduct; }
            set { selectedRemoveProduct = value; OnPropertyChanged(); }
        }

        #endregion

        public OrderViewModel() 
        {
            productService = new ProductService();
            products = new ObservableCollection<Product>();
            listOrderProduct = new ObservableCollection<Product>();
            addToCart = new RelayCommand<Product>(ExecuteAddProductToListOrder, CanExecuteAddProductToListOrder);
            selectedProduct = new Product();
            selectedRemoveProduct= new Product();
            removeProductInCart = new RelayCommand<Product>(ExecuteDeleteProductInCart, CanExecuteDeleteProductInCart);
            LoadProducts();
        }

        #region Load list product
        public void LoadProducts()
        {
            products = productService.GetAllProduct();
        }
        #endregion


        #region
        private RelayCommand<Product> addToCart;

        public RelayCommand<Product> AddToCart
        {
            get { return addToCart; }
            set { addToCart = value; OnPropertyChanged(); }
        }

        private void ExecuteAddProductToListOrder(Product productSelected)
        {
            bool productExsited = listOrderProduct.FirstOrDefault(x => x.Id == productSelected.Id) != null;
            if (productExsited) 
            {
                Product product = listOrderProduct.FirstOrDefault(x =>x.Id == productSelected.Id);
                product.Quantity = product.Quantity + 1;
            }
            else
            {
                Product product = productService.GetProductById(productSelected.Id);
                if(product == null)
                {

                }else if(product.Quantity == 0) 
                {

                }
                else
                {
                    product.Quantity = 1;
                    listOrderProduct.Add(product);
                }
            }
        }

        private bool CanExecuteAddProductToListOrder(Product product)
        {
            // Return true or false to enable/disable the command
            return true;
        }
        #endregion


        #region Remove a Product In Cart

        private RelayCommand<Product> removeProductInCart;

        public RelayCommand<Product> RemoveProductInCart
        {
            get { return removeProductInCart; }
            set { removeProductInCart = value; }
        }

        private void ExecuteDeleteProductInCart(Product selectedRemoveProduct)
        {
            listOrderProduct.Remove(selectedRemoveProduct);
        }

        private bool CanExecuteDeleteProductInCart(Product selectedRemoveProduct)
        {
            bool productExisted = listOrderProduct.FirstOrDefault(x => x.Id == selectedRemoveProduct.Id) != null;
            return productExisted;
        }

        #endregion

    }
}


