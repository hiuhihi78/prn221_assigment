using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Project.DTOs;
using WPF_Project.Models;
using WPF_Project.Services;
using WPF_Project.Views;

namespace WPF_Project.ViewModels
{
    public class DialogImportViewModel
    {


        private ObservableCollection<ImportDetail> importDetails;

        public ObservableCollection<ImportDetail> ImportDetails
        {
            get { return importDetails; }
            set { importDetails = value; }
        }


        private ImportDTO importDTO;

        public ImportDTO ImportDTO
        {
            get { return importDTO; }
            set { importDTO = value; }
        }


        private string staffImport;

        public string StaffImport
        {
            get { return staffImport; }
            set { staffImport = value; }
        }

        private Supplier supplier;

        public Supplier Supplier
        {
            get { return supplier; }
            set { supplier = value; }
        }


        private readonly DialogImportDetail _dialogImportDetail;
        private object _viewModelParentScreen;
        private ImportDTO _import;

        private OrderService orderService = new OrderService();
        private ImportService importService = new ImportService();
        private SupplierService supplierService = new SupplierService();
        public DialogImportViewModel(DialogImportDetail dialogImportDetail, object viewModelParentScreen, ImportDTO import)
        {
            _dialogImportDetail= dialogImportDetail;
            _viewModelParentScreen= viewModelParentScreen;
            _import = import;


            supplier = supplierService.GetSupplierById(import.SupplierId);
            importDTO = ((ImportDTO)import);
            staffImport = orderService.GetStaffNameOrder(import.Id);
            LoadOrderDetail();
        }

        #region Load order detail
        public void LoadOrderDetail()
        {
            var importId = ((ImportDTO)_import).Id;
            ImportDetails = importService.GetImportDetails(importId);
        }
        #endregion

    }
}
