using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Project.Models
{
    public class ProductService
    {
        private ShopTestContext context = new ShopTestContext();
        public ProductService() { }

        public List<Product> GetAllProduct()
        {
            var products = context.Products.Include(x => x.Category).ToList();   
            return products;
        }
    }
}
