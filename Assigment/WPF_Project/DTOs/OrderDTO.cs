using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Project.Models;

namespace WPF_Project.DTOs
{
    public class OrderDTO : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; NotifyPropertyChanged(); }
        }

        private DateTime orderDate;
        public DateTime OrderDate
        {
            get { return orderDate; }
            set { orderDate = value; NotifyPropertyChanged(); }
        }

        private string? customerName;
        public string? CustomerName
        {
            get { return customerName; }
            set { customerName = value; NotifyPropertyChanged(); }
        }

        private string? customerAddress;
        public string? CustomerAddress
        {
            get { return customerAddress; }
            set { customerAddress = value; NotifyPropertyChanged(); }
        }

        private string? customerPhone;
        public string? CustomerPhone
        {
            get { return customerPhone; }
            set { customerPhone = value; NotifyPropertyChanged(); }
        }

        private double totalAmount;
        public double TotalAmount
        {
            get { return totalAmount; }
            set { totalAmount = value; NotifyPropertyChanged(); }
        }

        private DateTime? deliverDate;
        public DateTime? DeliverDate
        {
            get { return deliverDate; }
            set { deliverDate = value; NotifyPropertyChanged(); }
        }


        private int staffId;
        public int StaffId
        {
            get { return staffId; }
            set { staffId = value; NotifyPropertyChanged(); }
        }

        private Staff staff;
        public Staff Staff
        {
            get { return staff; }
            set { staff = value; NotifyPropertyChanged(); }
        }

        public static OrderDTO FromOrder(Order order)
        {
            return new OrderDTO()
            {
                customerAddress = order.CustomerAddress,
                customerName = order.CustomerName,
                customerPhone = order.CustomerPhone,
                id = order.Id,
                deliverDate = order.DeliverDate,
                orderDate = order.OrderDate,
                staffId = order.StaffId,
                staff= order.Staff,
                totalAmount = order.TotalAmount,
                canCancel = DateTime.Now.Date.Subtract(order.OrderDate.Date).Days < 1,
            };
        }

        private bool? canCancel;

        public bool? CanCancel
        {
            get { return canCancel; }
            set { canCancel = value; NotifyPropertyChanged(); }
        }


    }
}
