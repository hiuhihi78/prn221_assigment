using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Project.DTOs;
using WPF_Project.Models;
using WPF_Project.Services;
using WPF_Project.Views;

namespace WPF_Project.ViewModels
{
    public class DialogOrderDetailViewModel
    {

        private ObservableCollection<OrderDetail> orderDetails;

        public ObservableCollection<OrderDetail> OrderDetails
        {
            get { return orderDetails; }
            set { orderDetails = value; }
        }

        private OrderDTO orderDTO;

        public OrderDTO OrderDTO
        {
            get { return orderDTO; }
            set { orderDTO = value; }
        }


        private string staffOrder;

        public string StaffOrder
        {
            get { return staffOrder; }
            set { staffOrder = value; }
        }




        private DialogOrderDetail _dialogOrderDetail;
        private object _viewModelParentScreen;
        private object _order;    
        private OrderService orderService = new OrderService();

        public DialogOrderDetailViewModel(DialogOrderDetail dialogOrderDetail, object viewModelParentScreen, object order) 
        {
            _dialogOrderDetail= dialogOrderDetail;  
            _viewModelParentScreen= viewModelParentScreen;
            _order= order;

            orderDTO = ((OrderDTO)order);
            staffOrder = orderService.GetStaffNameOrder(orderDTO.Id);
            LoadImportDetail();
        }

        #region Load order detail
        public void LoadImportDetail()
        {
            var orderId = ((OrderDTO)_order).Id;
            OrderDetails = orderService.GetOrderDetails(orderId);
        }
        #endregion
    }
}
