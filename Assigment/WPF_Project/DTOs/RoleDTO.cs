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
    public class RoleDTO : INotifyPropertyChanged
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

		private string name;

		public string Name
		{
			get { return name; }
			set { name = value; OnPropertyChanged(); }
        }

		public static RoleDTO FromRole(Role role)
		{
			return new RoleDTO { Id = role.Id,Name = role.Name };	
		}

	}
}
