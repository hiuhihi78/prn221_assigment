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
    public class ImportService
    {
        private ShopDbContext context = new ShopDbContext();
        public ImportService() { }


        public bool AddNewImport(ObservableCollection<ProductDTO> listOrderProduct, Import importInfo)
        {
            var transaction = context.Database.BeginTransaction();
            try
            {
                // add import
                context.Imports.Add(importInfo);
                context.SaveChanges();

                var importId = importInfo.Id;

                // add order detail
                foreach (ProductDTO item in listOrderProduct)
                {
                    ImportDetail importDetail = new ImportDetail()
                    {
                        ImportId= importId,
                        PriceImport = item.Price,
                        Quantity = item.Quantity,
                        ProductId  = item.Id
                    };

                    context.ImportDetails.Add(importDetail);    

                    // increase product's quantity
                    var product = context.Products.Where(x => x.Id == item.Id).FirstOrDefault();
                    if (product != null)
                    {
                        product.Quantity = product.Quantity + item.Quantity;
                    }
                    else
                    {
                        transaction.Rollback();
                        return false;
                    }
                }
                context.SaveChanges();
                transaction.Commit();

                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                return false;
            }
        }

        public ObservableCollection<ImportDTO> GetImportsByCondition(string searchImportInfo, DateTime? startDate, DateTime endDate)
        {
            ObservableCollection<ImportDTO> result = new ObservableCollection<ImportDTO>();

            if (endDate == null)
            {
                return result;
            }

            List<Import> imports = new List<Import>();
            var isAdmin = ((Staff)Navigation.NavigationParameters.Parameters["currentUser"]).Role == 1;
            var currentUser = ((Staff)Navigation.NavigationParameters.Parameters["currentUser"]);



            if (startDate == null)
            {
                imports = context.Imports
                                .Include(x => x.Staff)
                                .Include(x => x.Supplier)
                                .Where(p =>
                                           (
                                               p.ImportDate <= endDate.AddDays(1)
                                           ) &&
                                           (
                                              p.Supplier.Name.Contains(searchImportInfo) ||
                                              p.Supplier.Phone.Contains(searchImportInfo) ||
                                              p.Staff.Username.Contains(searchImportInfo) ||
                                              p.Staff.Fullname.Contains(searchImportInfo)
                                           ) &&
                                           (
                                                isAdmin == true ? true : p.StaffId == currentUser.Id
                                           )
                                       )
                                .OrderByDescending(x => x.ImportDate)
                                .ToList();
            }
            else
            {
                imports = context.Imports
                                .Include(x => x.Staff)
                                .Include(x => x.Supplier)
                                .Where(p =>
                                           (
                                               p.ImportDate <= endDate.AddDays(1) &&
                                               p.ImportDate >= startDate
                                           ) &&
                                           (
                                              p.Supplier.Name.Contains(searchImportInfo) ||
                                              p.Supplier.Phone.Contains(searchImportInfo) ||
                                              p.Staff.Username.Contains(searchImportInfo) ||
                                              p.Staff.Fullname.Contains(searchImportInfo)
                                           ) &&
                                           (
                                                isAdmin == true ? true : p.StaffId == currentUser.Id
                                           )
                                       )
                                .OrderByDescending(x => x.ImportDate)
                                .ToList();
            }

            foreach (var item in imports)
            {
                result.Add(ImportDTO.FromImport(item));
            }
            return result;
        }

        internal ObservableCollection<ImportDetail> GetImportDetails(int importId)
        {
            ObservableCollection<ImportDetail> result = new ObservableCollection<ImportDetail>();
            var list = context.ImportDetails.Include(o => o.Product).Where(o => o.ImportId == importId).ToList();

            foreach (var item in list)
            {
                result.Add(item);
            }

            return result;
        }
    }
}
