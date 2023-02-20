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
    public class SupplierService
    {
        private ShopDbContext context = new ShopDbContext();
        public SupplierService() { }

        public ObservableCollection<SupplierDTO> GetAllSupplier()
        {
            var suppliers = context.Suppliers.ToList();
            var result = new ObservableCollection<SupplierDTO>();
            foreach (var item in suppliers)
            {
                SupplierDTO supplierDTO = SupplierDTO.FromProduct(item);
                result.Add(supplierDTO);
            }
            return result;
        }

        public ObservableCollection<SupplierDTO> GetSuppliersByCondition(string name, string phone) 
        {
            if (name == string.Empty && phone == string.Empty) return new ObservableCollection<SupplierDTO>();
            var suppliers = context.Suppliers.Where(x => x.Name.Contains(name) && x.Phone.Contains(phone)).ToList();
            var result = new ObservableCollection<SupplierDTO>();
            foreach (var item in suppliers)
            {
                SupplierDTO supplierDTO = SupplierDTO.FromProduct(item);
                result.Add(supplierDTO);
            }
            return result;
        }

    }
}
