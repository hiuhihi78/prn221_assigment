using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Project.Models;

namespace WPF_Project.DTOs
{
    public class SupplierDTO : INotifyPropertyChanged
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

        private string phone;
        public string Phone
        {
            get { return phone; }
            set { phone = value; NotifyPropertyChanged(); }
        }

        private string address;
        public string Address
        {
            get { return address; }
            set { address = value; NotifyPropertyChanged(); }
        }

        public static SupplierDTO FromProduct(Supplier supplier)
        {
            return new SupplierDTO
            {
                Id = supplier.Id,
                Name = supplier.Name,
                Phone= supplier.Phone,
                Address = supplier.Address,
            };
        }
    }
}
