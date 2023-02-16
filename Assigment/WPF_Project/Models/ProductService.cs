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

        public ObservableCollection<ProductDTO> GetAllProduct()
        {
            var products = context.Products.Include(x => x.Category).ToList();
            var result = new ObservableCollection<ProductDTO>();
            foreach (var item in products)
            {
                ProductDTO productDTO = ProductDTO.FromProduct(item);
                result.Add(productDTO);
            }
            return result;
        }

        public ProductDTO GetProductById(int id)
        {
            Product product = context.Products.Where(x => x.Id == id).FirstOrDefault();
            if (product == null) return null;
            return ProductDTO.FromProduct(product);
        }

        public ObservableCollection<ProductDTO> GetListProductByNameAndCategory(string productName, int categoryId)
        {
            var products = context.Products.Where(x => x.Name.Contains(productName) && x.Id == categoryId).ToList();
            if(products == null) return new ObservableCollection<ProductDTO> { };
            return ProductDTO.FromListProductToObservableProductDTO(products);
        }

        public ObservableCollection<ProductDTO> GetListProductByName(string productName)
        {
            var products = context.Products.Where(x => x.Name.Contains(productName)).ToList();
            if (products == null) return new ObservableCollection<ProductDTO> { };
            return ProductDTO.FromListProductToObservableProductDTO(products);
        }
    }
}
