using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Project.Models
{
    public class ProductService
    {
        private ShopTestContext context = new ShopTestContext();
        public ProductService() { }

        public ObservableCollection<Product> GetAllProduct()
        {
            var products = context.Products.Include(x => x.Category);   
            return new ObservableCollection<Product>(products);
        }

        public Product GetProductById(int id) 
        {
            var product = context.Products.FirstOrDefault(x => x.Id == id);
            return product;
        }
    }
}
