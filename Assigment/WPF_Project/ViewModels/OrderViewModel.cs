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

        private List<Product> products;

        private ProductService productService;

        public List<Product> Products
        {
            get { return products; }
            set { products = value; }
        }

        private List<Product> listOrderProduct;

        public List<Product> ListOrderProduct
        {
            get { return listOrderProduct; }
            set {  listOrderProduct= value; }
        }


        public OrderViewModel() 
        {
            productService = new ProductService();
            products = new List<Product>();
            listOrderProduct = new List<Product>();
            addToCart = new RelayCommand<string>(ExecuteAddProductToListOrder, CanExecuteAddProductToListOrder);
            LoadProducts();
        }

        #region Load list product
        public void LoadProducts()
        {
            products = productService.GetAllProduct();
        }
        #endregion

        private RelayCommand<string> addToCart;

        public RelayCommand<string> AddToCart
        {
            get { return addToCart; }
            set { addToCart = value; OnPropertyChanged(); }
        }

        private void ExecuteAddProductToListOrder(string id)
        {
            MessageBox.Show("adwa " + id);
        }

        private bool CanExecuteAddProductToListOrder(string id)
        {
            // Return true or false to enable/disable the command
            return true;
        }

    }
}


