using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Project.Models;

namespace WPF_Project.DTOs
{
    public class ProductDTO : INotifyPropertyChanged
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

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; NotifyPropertyChanged(); }
        }

        private string description;
        public string Description
        {
            get { return description; }
            set { description = value; NotifyPropertyChanged(); }
        }

        private int quantity;
        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; NotifyPropertyChanged(); }
        }

        private double price;
        public double Price
        {
            get { return price; }
            set { price = value; NotifyPropertyChanged(); }
        }

        private int discount;
        public int Discount
        {
            get { return discount; }
            set { discount = value; NotifyPropertyChanged(); }
        }

        private string country;
        public string Country
        {
            get { return country; }
            set { country = value; NotifyPropertyChanged(); }
        }

        private int categoryId;
        public int CategoryId
        {
            get { return categoryId; }
            set { categoryId = value; NotifyPropertyChanged(); }
        }

        private Category category;

        public Category Category
        {
            get { return category; }
            set { category = value; NotifyPropertyChanged(); }
        }

        public virtual ICollection<ImportDetail> ImportDetails { get; } = new List<ImportDetail>();

        public virtual ICollection<OrderDetail> OrderDetails { get; } = new List<OrderDetail>();

        public static ProductDTO FromProduct(Product product)
        {
            return new ProductDTO
            {
                Name = product.Name,
                Id = product.Id,
                Description = product.Description,
                Quantity = product.Quantity,
                Price = product.Price,
                Discount = product.Discount,
                Country = product.Country,
                CategoryId = product.CategoryId,
                Category = product.Category,
            };
        }

        public static ObservableCollection<ProductDTO> FromListProductToObservableProductDTO(List<Product> products)
        {
            var result = new ObservableCollection<ProductDTO>();
            foreach (var item in products)
            {
                ProductDTO productDTO = FromProduct(item);
                result.Add(productDTO);
            }
            return result;
        }

    }
}
