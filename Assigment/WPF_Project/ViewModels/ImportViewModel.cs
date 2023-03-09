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

        private ObservableCollection<ProductDTO> listImportProduct;

        public ObservableCollection<ProductDTO> ListImportProduct
        {
            get { return listImportProduct; }
            set { listImportProduct = value; OnPropertyChanged(); }
        }

        private string searchProductName;

        public string SearchProductName
        {
            get { return searchProductName; }
            set { searchProductName = value; }
        }

        private bool enableButtonCheckout;

        public bool EnableButtonCheckout
        {
            get { return enableButtonCheckout; }
            set { enableButtonCheckout = value; OnPropertyChanged(); }
        }

        private double totalPriceOrder;

        public double TotalPriceOrder
        {
            get { return totalPriceOrder; }
            set { totalPriceOrder = value; OnPropertyChanged(); }
        }


        #endregion

        public ImportViewModel()
        {
            enableButtonCheckout = false;
            totalPriceOrder = 0;
            checkoutImport = new RelayCommand(ExecuteCheckoutImport);
            chooseProductImport = new RelayCommand(ExecuteChooseProductImport);
            listImportProduct = new ObservableCollection<ProductDTO>();
            removeProduct = new RelayCommand<ProductDTO>(ExecuteRemoveProduct, p => true);
            UpdateListProductImport();
            UpdateTotalPriceImport();
        }




        #region Checkout Order (Navigation to screen checkout order)

        private RelayCommand checkoutImport;

        public RelayCommand CheckoutImport
        {
            get { return checkoutImport; }
            set { checkoutImport = value; OnPropertyChanged(); }
        }

        private void ExecuteCheckoutImport()
        {
            if (!NavigationParameters.Parameters.ContainsKey("listImported"))
            {
                NavigationParameters.Parameters.Add("listImported", ListImportProduct);
            }
            if (!NavigationParameters.Parameters.ContainsKey("totalPriceImport"))
            {
                NavigationParameters.Parameters.Add("totalPriceImport", TotalPriceOrder);
            }
            NavigationFrameContentHomeScreen.NavigateTo(new CheckoutImport());
        }
        #endregion



        #region Update status button checkout order
        public void UpdateStatusCheckoutImport()
        {
            EnableButtonCheckout = TotalPriceOrder > 0;
        }
        #endregion


        #region Update total price order
        public void UpdateTotalPriceImport()
        {
            double total = 0;
            foreach (var product in ListImportProduct)
            {
                total += (product.Quantity * product.Price);
            }
            TotalPriceOrder = total;
        }
        #endregion

        #region Update List product import
        public void UpdateListProductImport()
        {
            if (NavigationParameters.Parameters.ContainsKey("listImportedCopy"))
            {
                ListImportProduct = ((ObservableCollection<ProductDTO>)NavigationParameters.Parameters["listImportedCopy"]);
                NavigationParameters.Parameters.Remove("listImportedCopy");
                return;
            }

            if (!NavigationParameters.Parameters.ContainsKey("listImported"))
            {
                NavigationParameters.Parameters.Add("listImported", ListImportProduct);
            }
            else
            {
                NavigationParameters.Parameters.Remove("listImported");
                NavigationParameters.Parameters.Add("listImported", ListImportProduct);
            }
            ListImportProduct = ((ObservableCollection<ProductDTO>)NavigationParameters.Parameters["listImported"]);
        }
        #endregion

        #region Choose product button
        private RelayCommand chooseProductImport;

        public RelayCommand ChooseProductImport
        {
            get { return chooseProductImport; }
            set { chooseProductImport = value; }
        }

        public void ExecuteChooseProductImport()
        {
            Views.ChooseProductImport chooseProductImport = new Views.ChooseProductImport();
            chooseProductImport.DataContext = new ChooseProductImportViewModel(chooseProductImport, this);
            chooseProductImport.ShowDialog();
        }

        #endregion

        #region Remove product
        private RelayCommand<ProductDTO> removeProduct;

        public RelayCommand<ProductDTO> RemoveProduct
        {
            get { return removeProduct; }
            set { removeProduct = value; }
        }

        private void ExecuteRemoveProduct(ProductDTO product)
        {
            MessageBoxResult comfrim = MessageBox.Show("Are you sure you want to do this?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (comfrim == MessageBoxResult.Yes)
            {
                ObservableCollection<ProductDTO> result = new ObservableCollection<ProductDTO>();
                var list = ListImportProduct.Where(p => p.Id != product.Id).ToList();
                foreach (var item in list)
                {
                    result.Add(item);
                }
                ListImportProduct = result;
                if (NavigationParameters.Parameters.ContainsKey("listImported"))
                {
                    NavigationParameters.Parameters.Remove("listImported");
                    NavigationParameters.Parameters.Add("listImported", ListImportProduct);
                }
                UpdateTotalPriceImport();
                UpdateStatusCheckoutImport();
            }

            #endregion

        }
    }
}
