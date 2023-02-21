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
    public class CheckoutImportViewModel : INotifyPropertyChanged
    {
        #region Declare varibles

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private ObservableCollection<ProductDTO> listOrderProduct;

        public ObservableCollection<ProductDTO> ListOrderProduct
        {
            get { return listOrderProduct; }
            set { listOrderProduct = value; OnPropertyChanged(); }
        }

        private double totalPriceOrder;

        public double TotalPriceOrder
        {
            get { return totalPriceOrder; }
            set { totalPriceOrder = value; OnPropertyChanged(); }
        }

        private ObservableCollection<SupplierDTO> listSupplier;

        public ObservableCollection<SupplierDTO> ListSupplier
        {
            get { return listSupplier; }
            set { listSupplier = value; OnPropertyChanged(); }
        }

        private string searchSupplier;

        public string SearchSupplier
        {
            get { return searchSupplier; }
            set { searchSupplier = value; OnPropertyChanged(); GetListSupplier(); }
        }


        #endregion

        #region Contructor

        public CheckoutImportViewModel()
        {
            GetDataOfPreviousScreen();
            SearchSupplier = string.Empty;
            backToPreviousScreen = new RelayCommand(HandleBackToPreviousScreen);
            checkoutImportProduct = new RelayCommand(HandleChecoutImportProducts);
            GetListSupplier();
        }
        #endregion

        #region Get data in Order screen (products ordered, total price order)
        public void GetDataOfPreviousScreen()
        {
            ListOrderProduct = (ObservableCollection<ProductDTO>)NavigationParameters.Parameters["listImported"];
            TotalPriceOrder = (double)NavigationParameters.Parameters["totalPriceImport"];
        }
        #endregion

        #region Get list suppliers
        public void GetListSupplier()
        {
            SupplierService supplierService = new SupplierService();
            ListSupplier = supplierService.GetSuppliersByCondition(SearchSupplier);
        }
        #endregion

        #region Handle click back to Order screen

        private RelayCommand backToPreviousScreen;

        public RelayCommand BackToPreviousScreen
        {
            get { return backToPreviousScreen; }
            set { backToPreviousScreen = value; }
        }

        public void HandleBackToPreviousScreen()
        {
            NavigationFrameContentHomeScreen.NavigateTo(new Import());
        }

        #endregion

        #region Handle click checkout

        private RelayCommand checkoutImportProduct;

        public RelayCommand CheckoutOrderProduct
        {
            get { return checkoutImportProduct; }
            set { checkoutImportProduct = value; }
        }

        public void HandleChecoutImportProducts()
        {
            MessageBoxResult comfrim = MessageBox.Show("Are you sure you want to do this?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (comfrim == MessageBoxResult.Yes)
            {
                Models.Order orderInfo = new Models.Order()
                {
                    StaffId = ((Models.Staff)NavigationParameters.Parameters["currentUser"]).Id,
                };

                OrderService orderService = new OrderService();
                if (true)
                {
                    MessageBox.Show("Success!", "Alter", MessageBoxButton.OK, MessageBoxImage.Information);
                    // remove cart
                    NavigationParameters.Parameters.Remove("listImported");
                    NavigationParameters.Parameters.Remove("totalPriceImport");
                    // navigation Order screen
                    NavigationFrameContentHomeScreen.NavigateTo(new Import());
                }
                else
                {
                    MessageBox.Show("Something was wrong!\nPlease ask administrator!", "Alter", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }
        #endregion
    }
}
