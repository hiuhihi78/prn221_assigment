using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Project.DTOs;
using WPF_Project.Models;
using WPF_Project.Navigation;

namespace WPF_Project.Services
{
    public class OrderService
    {
        private ShopDbContext context = new ShopDbContext();
        public OrderService() { }

        public bool AddNewOrder(ObservableCollection<ProductDTO> listOrder, Order orderInfo)
        {
            var transaction = context.Database.BeginTransaction();
            try
            {
                // add order
                context.Orders.Add(orderInfo);
                context.SaveChanges();

                var orderId = orderInfo.Id;

                // add order detail
                foreach(ProductDTO item in listOrder) 
                {
                     OrderDetail orderDetail = new OrderDetail()
                     {
                         OrderId = orderId,
                         ProductId = item.Id,
                         SellPrice = item.Price,
                         Quantity = item.Quantity,  
                         Discount= item.Discount,   
                     };
                    context.OrderDetails.Add(orderDetail);

                    // decrease product's quantity
                    var product = context.Products.Where(x => x.Id == item.Id).FirstOrDefault();    
                    if (product != null) 
                    {
                        if(product.Quantity >= orderDetail.Quantity)
                        {
                            product.Quantity = product.Quantity - item.Quantity;
                        }
                        else 
                        {
                            transaction.Rollback();
                            return false;
                        }
                    }
                    else
                    {
                        transaction.Rollback();
                        return false;
                    }
                }
                context.SaveChanges();
                transaction.Commit();

                return true;
            }catch (Exception ex) 
            {
                transaction.Rollback();
                return false;
            }
        }

        public ObservableCollection<OrderDTO> GetOrdersByCondition(string searchOrderInfo, DateTime? startDate, DateTime endDate)
        {
            ObservableCollection<OrderDTO> result = new ObservableCollection<OrderDTO>();

            if (endDate == null)
            {
                return result;
            }

            List<Order> orders = new List<Order>();
            var isAdmin = ((Staff)Navigation.NavigationParameters.Parameters["currentUser"]).Role == 1;
            var currentUser = ((Staff)Navigation.NavigationParameters.Parameters["currentUser"]);

           

            if (startDate == null)
            {
                orders = context.Orders
                                .Include(x => x.Staff)
                                .Where(p =>   
                                           (
                                               p.OrderDate <= endDate.AddDays(1) 
                                           ) &&
                                           (
                                               p.CustomerAddress.Contains(searchOrderInfo) ||
                                               p.CustomerName.Contains(searchOrderInfo)    ||
                                               p.CustomerPhone.Contains(searchOrderInfo)
                                           ) &&
                                           (
                                                isAdmin == true ? true : p.StaffId == currentUser.Id
                                           )
                                       )
                                .ToList();
            }
            else
            {
                orders = context.Orders
                                .Include(x => x.Staff)
                                .Where(p =>
                                           (
                                               p.OrderDate <= endDate.AddDays(1) &&
                                               p.OrderDate >= startDate
                                           ) &&
                                           (
                                               p.CustomerAddress.Contains(searchOrderInfo) ||
                                               p.CustomerName.Contains(searchOrderInfo) ||
                                               p.CustomerPhone.Contains(searchOrderInfo)
                                           ) &&
                                           (
                                                isAdmin == true ? true : p.StaffId == currentUser.Id
                                           )
                                       )
                                .ToList();
            }
             
            foreach (var item in orders)
            {
                result.Add(OrderDTO.FromOrder(item));
            }
            return result;

        }

        public ObservableCollection<OrderDetail> GetOrderDetails(int orderId)
        {
            ObservableCollection<OrderDetail> result = new ObservableCollection<OrderDetail>();
            var list = context.OrderDetails.Include(o => o.Product).Where(o => o.OrderId == orderId).ToList();  

            foreach (var item in list) 
            {
                result.Add(item);
            }

            return result;
        }

        public string? GetStaffNameOrder(int id)
        {
            var staff = context.Staff.FirstOrDefault(x => x.Id == id);
            return staff == null ? "" : staff.Fullname;
        }
    }
}
