using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Project.Models;

namespace WPF_Project.DTOs
{
    public class CategoryDTO : INotifyPropertyChanged
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

        public static CategoryDTO FromCategory(Category category)
        {
            return new CategoryDTO { Id = category.Id, Name = category.Name };
        }
    }
}
