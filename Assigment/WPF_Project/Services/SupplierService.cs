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

        public ObservableCollection<SupplierDTO> GetSuppliersByCondition(string nameOrPhone)
        {
            List<Supplier> suppliers = new List<Supplier>();
            if (nameOrPhone == string.Empty || nameOrPhone == null)
            {
                suppliers = context.Suppliers.ToList();
            }
            else
            {
                suppliers = context.Suppliers.Where(x => x.Name.Contains(nameOrPhone) || x.Phone.Contains(nameOrPhone) || x.Address.Contains(nameOrPhone)).ToList();
            }
            var result = new ObservableCollection<SupplierDTO>();
            foreach (var item in suppliers)
            {
                SupplierDTO supplierDTO = SupplierDTO.FromProduct(item);
                result.Add(supplierDTO);
            }
            return result;
        }

        internal Supplier? GetSupplierById(int supplierId)
        {
            return context.Suppliers.FirstOrDefault(x => x.Id== supplierId);
        }

        public bool SupplierPhoneExisted(string phone)
        {
            return context.Suppliers.Any(x => x.Phone == phone);  
        }

        public void AddSupplier(SupplierDTO supplier)
        {
            var result = new Supplier()
            {
                Name= supplier.Name,
                Phone= supplier.Phone,
                Address= supplier.Address,  
            };

            context.Suppliers.Add(result);
            context.SaveChanges();
        }


        public void UpdateSupplier(SupplierDTO supplier)
        {
            var supplierEdit = context.Suppliers.FirstOrDefault(x => x.Id == supplier.Id);  
            if (supplierEdit != null) 
            {
                supplierEdit.Name = supplier.Name;  
                supplierEdit.Phone = supplier.Phone;
                supplierEdit.Address = supplier.Address;
                context.SaveChanges();
            }
        }
    }
}
