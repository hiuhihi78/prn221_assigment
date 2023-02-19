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
        private ShopTestContext context = new ShopTestContext();
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
        
        
    }
}
