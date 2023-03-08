using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
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

        private DateTime? endDate = DateTime.Now;

        public DateTime? EndDate
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


        private ObservableCollection<Models.Order> orders;

        public ObservableCollection<Models.Order> Orders
        {
            get { return orders; }
            set { orders = value; }
        }

        #endregion

        private OrderService orderService = new OrderService();
        public OrderHistoryViewModel()
        {
            Orders = new ObservableCollection<Models.Order>();
            SearchOrderInfo = string.Empty;
            SearchOrder();
        }

        #region Search order
        private void SearchOrder()
        {
            Orders = orderService.GetOrdersByCondition(SearchOrderInfo,StartDate,EndDate);
        }
        #endregion

    }
}
