using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPF_Project.Command;
using WPF_Project.DTOs;
using WPF_Project.Models;
using WPF_Project.Services;
using WPF_Project.Views;

namespace WPF_Project.ViewModels
{
    public class SuppliermanagementViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        private ObservableCollection<SupplierDTO> suppliers;

        public ObservableCollection<SupplierDTO> Suppliers
        {
            get { return suppliers; }
            set { suppliers = value; OnPropertyChanged(); }
        }

        private string searchSupplier;

        public string SearchSupplier
        {
            get { return searchSupplier; }
            set { searchSupplier = value; OnPropertyChanged(); LoadSupplier(); }
        }

        private SupplierService supplierService = new SupplierService();
        public SuppliermanagementViewModel() 
        {
            Suppliers = new ObservableCollection<SupplierDTO>();
            searchSupplier = string.Empty;

            createNewSupplier = new RelayCommand(ExecuteCreateNewSupplier);
            updateSupplier = new RelayCommand<SupplierDTO>(ExecuteUpdateSupplier);
            viewSupplier = new RelayCommand<SupplierDTO>(ExecuteViewSupplier);
            LoadSupplier();

        }

        #region Load Suppliers
        public void LoadSupplier()
        {
            Suppliers = supplierService.GetSuppliersByCondition(SearchSupplier);
        }
        #endregion

        #region create new supplier
        private RelayCommand createNewSupplier;

        public RelayCommand CreateNewSupplier
        {
            get { return createNewSupplier; }
            set { createNewSupplier = value; }
        }

        private void ExecuteCreateNewSupplier()
        {
            DialogSupplierInfo dialogSupplierInfo = new DialogSupplierInfo();
            dialogSupplierInfo.DataContext = new DialogSupplierInfoViewModel(dialogSupplierInfo, this, null, true);
            dialogSupplierInfo.ShowDialog();
        }

        #endregion

        #region Update supplier info
        private RelayCommand<SupplierDTO> updateSupplier;

        public RelayCommand<SupplierDTO> UpdateSupplier
        {
            get { return updateSupplier; }
            set { updateSupplier = value; }
        }

        private void ExecuteUpdateSupplier(SupplierDTO supplier)
        {
            DialogSupplierInfo dialogSupplierInfo = new DialogSupplierInfo();
            dialogSupplierInfo.DataContext = new DialogSupplierInfoViewModel(dialogSupplierInfo, this, supplier, true);
            dialogSupplierInfo.ShowDialog();
        }

        #endregion


        #region View Supplier
        private RelayCommand<SupplierDTO> viewSupplier;

        public RelayCommand<SupplierDTO> ViewSupplier
        {
            get { return viewSupplier; }
            set { viewSupplier = value; }
        }

        private void ExecuteViewSupplier(SupplierDTO supplier)
        {
            DialogSupplierInfo dialogSupplierInfo = new DialogSupplierInfo();
            dialogSupplierInfo.DataContext = new DialogSupplierInfoViewModel(dialogSupplierInfo, this, supplier, false);
            dialogSupplierInfo.ShowDialog();
        }
        #endregion
    }
}
