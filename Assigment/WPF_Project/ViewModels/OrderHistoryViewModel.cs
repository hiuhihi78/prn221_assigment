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
using WPF_Project.Services;
using WPF_Project.Views;

namespace WPF_Project.ViewModels
{
    public class OrderHistoryViewModel : INotifyPropertyChanged
    {
        #region Declare Varible
        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private DateTime? startDate;

        public DateTime? StartDate
        {
            get { return startDate; }
            set { startDate = value; OnPropertyChanged(); SearchOrder(); }
        }

        private DateTime endDate = DateTime.Now;

        public DateTime EndDate
        {
            get { return endDate; }
            set { endDate = value; OnPropertyChanged(); SearchOrder(); }
            }

        private DateTime _currentDate = DateTime.Now;

        private string searchOrderInfo;

        public string SearchOrderInfo
        {
            get { return searchOrderInfo; }
            set { searchOrderInfo = value; OnPropertyChanged(); SearchOrder(); }
        }


        private ObservableCollection<OrderDTO> orders;

        public ObservableCollection<OrderDTO> Orders
        {
            get { return orders; }
            set { orders = value; OnPropertyChanged(); }
        }

        #endregion

        private OrderService orderService = new OrderService();
        public OrderHistoryViewModel()
        {
            Orders = new ObservableCollection<OrderDTO>();
            SearchOrderInfo = string.Empty;
            SearchOrder();
            viewOrderDetail = new RelayCommand<OrderDTO>(ExecuteViewOrderDetail, o => true);
            cancelOrder = new RelayCommand<OrderDTO>(ExecuteCancelOrder, o => true);
        }

        #region Search order
        private void SearchOrder()
        {
            Orders = orderService.GetOrdersByCondition(SearchOrderInfo,StartDate,EndDate);
        }
        #endregion

        #region View order details

        private RelayCommand<OrderDTO> viewOrderDetail;

        public RelayCommand<OrderDTO> ViewOrderDetail
        {
            get { return viewOrderDetail; }
            set { viewOrderDetail = value; }
        }
        
        private void ExecuteViewOrderDetail(OrderDTO order)
        {
            DialogOrderDetail dialogOrderDetail = new DialogOrderDetail();
            dialogOrderDetail.DataContext = new DialogOrderDetailViewModel(dialogOrderDetail, this, order);
            dialogOrderDetail.ShowDialog();
        }

        #endregion

        #region Cancel order
        private RelayCommand<OrderDTO> cancelOrder;

        public RelayCommand<OrderDTO> CancelOrder
        {
            get { return cancelOrder; }
            set { cancelOrder = value; }
        }

        private void ExecuteCancelOrder(OrderDTO order)
        {
            MessageBoxResult comfrim = MessageBox.Show("Are you sure to cancel this order?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if(comfrim == MessageBoxResult.Yes) 
            {
                orderService.RemoveOrder(order.Id);
                MessageBox.Show("Success!", "", MessageBoxButton.OK, MessageBoxImage.Information);
                SearchOrder();
            }
        }

        #endregion
    }
}
