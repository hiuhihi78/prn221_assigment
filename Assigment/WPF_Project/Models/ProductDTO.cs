using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Project.Models
{
    public class ProductDTO
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

        private Category categoryName;
        public Category CategoryName
        {
            get { return categoryName; }
            set { categoryName = value; NotifyPropertyChanged(); }
        }

        

    }
}
