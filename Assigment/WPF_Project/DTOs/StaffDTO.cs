using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WPF_Project.Models;

namespace WPF_Project.DTOs
{
    public class StaffDTO : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; OnPropertyChanged(); }
        }

        private string username;

        public string Username
        {
            get { return username; }
            set { username = value; OnPropertyChanged(); }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set { password = value; OnPropertyChanged(); }
        }

        private string fullname;
        public string Fullname
        {
            get { return fullname; }
            set { fullname = value; OnPropertyChanged(); }
        }

        private string phone;
        public string Phone
        {
            get { return phone; }
            set { phone = value; OnPropertyChanged(); }
        }

        private string address;
        public string Address
        {
            get { return address; }
            set { address = value; OnPropertyChanged(); }
        }


        private int role;
        public int Role
        {
            get { return role; }
            set { role = value; OnPropertyChanged(); }
        }

        private bool status;
        public bool Status
        {
            get { return status; }
            set { status = value; OnPropertyChanged(); }
        }

        private ICollection<Import> imports;
        public ICollection<Import> Imports
        {
            get { return imports; }
            set { imports = value; OnPropertyChanged(); }
        }

        private ICollection<Order> orders;
        public ICollection<Order> Orders
        {
            get { return orders; }
            set { orders = value; OnPropertyChanged(); }
        }

    }
}
