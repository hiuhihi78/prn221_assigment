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
    }
}
