using System;
using System.Collections.Generic;
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
    public class DialogSupplierInfoViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private SupplierDTO supplier;

        public SupplierDTO Supplier
        {
            get { return supplier; }
            set { supplier = value; OnPropertyChanged(); }
        }


        private DialogSupplierInfo _dialogSupplierInfo;
        private object _viewModelParentScreen;
        private SupplierDTO _supplier;
        public bool CanEdit { get; set; }
        private string initialPhone;

        private SupplierService supplierService = new SupplierService();
        public DialogSupplierInfoViewModel(DialogSupplierInfo dialogSupplierInfo, object viewModelParentScreen, SupplierDTO supplier, bool canEdit)
        {
            _dialogSupplierInfo = dialogSupplierInfo;
            _viewModelParentScreen = viewModelParentScreen;
            _supplier = supplier;
            CanEdit = canEdit;

            initialPhone = supplier == null ? "" : supplier.Phone;
            Supplier = supplier == null ? new SupplierDTO() { Address = "", Phone = "", Name = "" } : supplier;
            saveCommand = new RelayCommand(ExecuteSaveCommand);
        }

        #region SaveCommand
        private RelayCommand saveCommand;

        public RelayCommand SaveCommand
        {
            get { return saveCommand; }
            set { saveCommand = value; }
        }

        private void ExecuteSaveCommand()
        {
            if (_supplier == null)
            {
                if (string.IsNullOrEmpty(Supplier.Name) || string.IsNullOrEmpty(Supplier.Phone) || string.IsNullOrEmpty(Supplier.Address))
                {
                    MessageBox.Show("You must fill all fields!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                else if (Supplier.Phone.Length != 10)
                {
                    MessageBox.Show("Phone number must be 10 charactor!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                else
                {
                    if (supplierService.SupplierPhoneExisted(Supplier.Phone))
                    {
                        MessageBox.Show("This phone number was use by other supplier!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }
                    supplierService.AddSupplier(Supplier);
                    MessageBox.Show("Success!", "Alter", MessageBoxButton.OK, MessageBoxImage.Information);
                    ((SuppliermanagementViewModel)_viewModelParentScreen).LoadSupplier();
                    _dialogSupplierInfo.Close();
                }
            }
            else
            {
                if (string.IsNullOrEmpty(Supplier.Name) || string.IsNullOrEmpty(Supplier.Phone) || string.IsNullOrEmpty(Supplier.Address))
                {
                    MessageBox.Show("You must fill all fields!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                else if (Supplier.Phone.Length != 10)
                {
                    MessageBox.Show("Phone number must be 10 charactor!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                else
                {
                    if (supplierService.SupplierPhoneExisted(Supplier.Phone) && Supplier.Phone != initialPhone)
                    {
                        MessageBox.Show("This phone number was use by other supplier!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }
                    supplierService.UpdateSupplier(Supplier);
                    MessageBox.Show("Success!", "Alter", MessageBoxButton.OK, MessageBoxImage.Information);
                    ((SuppliermanagementViewModel)_viewModelParentScreen).LoadSupplier();
                    _dialogSupplierInfo.Close();
                }
            }

        }

        #endregion
        
    }
}
