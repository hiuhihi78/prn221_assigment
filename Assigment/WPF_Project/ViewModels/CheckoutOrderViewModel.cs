using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;
using WPF_Project.Command;
using WPF_Project.DTOs;
using WPF_Project.Navigation;
using WPF_Project.Services;
using WPF_Project.Views;

namespace WPF_Project.ViewModels
{
    public class CheckoutOrderViewModel :  INotifyPropertyChanged
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

        private string  fullName;

        public string FullName
        {
            get { return fullName; }
            set { fullName = value; OnPropertyChanged(); }
        }

        private string phone;

        public string Phone
        {
            get { return phone; }
            set { phone = value; OnPropertyChanged(); }
        }

        private string address;

        public string Address
        {
            get { return address; }
            set { address = value; OnPropertyChanged(); }
        }

        private double totalPriceOrder;

        public double TotalPriceOrder
        {
            get { return totalPriceOrder; }
            set { totalPriceOrder = value; OnPropertyChanged(); }
        }


        #endregion

        #region Contructor

        public CheckoutOrderViewModel() 
        {
            GetDataOfPreviousScreen();
            fullName= string.Empty; 
            phone= string.Empty;
            address= string.Empty;
            backToPreviousScreen = new RelayCommand(HandleBackToPreviousScreen);
            checkoutOrderProduct = new RelayCommand(HandleChecoutOrderProducts);
        }
        #endregion

        #region Get data in Order screen (products ordered, total price order)
        public void GetDataOfPreviousScreen()
        {
            ListOrderProduct = (ObservableCollection<ProductDTO>)NavigationParameters.Parameters["listOrder"];
            TotalPriceOrder = (double)NavigationParameters.Parameters["totalPriceOrder"];
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
            NavigationFrameContentHomeScreen.NavigateTo(new Order());
        }

        #endregion

        #region Handle click checkout

        private RelayCommand checkoutOrderProduct;

        public RelayCommand CheckoutOrderProduct
        {
            get { return checkoutOrderProduct; }
            set { checkoutOrderProduct = value; }
        }

        public void HandleChecoutOrderProducts()
        {
            MessageBoxResult comfrim = MessageBox.Show("Are you sure you want to do this?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if(comfrim == MessageBoxResult.Yes) 
            {
                Models.Order orderInfo = new Models.Order()
                {
                    OrderDate = DateTime.Now,
                    CustomerName = FullName,
                    CustomerPhone = Phone,
                    CustomerAddress = Address,
                    TotalAmount = TotalPriceOrder,
                    StaffId = ((Models.Staff)NavigationParameters.Parameters["currentUser"]).Id,
                };
                
                OrderService orderService = new OrderService();
                if(orderService.AddNewOrder(ListOrderProduct, orderInfo) == true) 
                {
                    MessageBox.Show("Success!", "Alter", MessageBoxButton.OK, MessageBoxImage.Information);
                    // remove cart
                    NavigationParameters.Parameters.Remove("listOrder");
                    NavigationParameters.Parameters.Remove("totalPriceOrder");
                    // navigation Order screen
                    NavigationFrameContentHomeScreen.NavigateTo(new Order());  
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
