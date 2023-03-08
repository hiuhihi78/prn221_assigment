using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Project.DTOs;
using WPF_Project.Models;

namespace WPF_Project.Services
{
    public class RoleService
    {
        private ShopDbContext context = new ShopDbContext();
        public RoleService() { }

        public ObservableCollection<RoleDTO> GetAllRole()
        {
            var roles = context.Roles.ToList();
            var result = new ObservableCollection<RoleDTO>();
            foreach (var item in roles)
            {
                RoleDTO roleDTO = RoleDTO.FromRole(item);
                result.Add(roleDTO);
            }
            return result;
        }
    }
}
