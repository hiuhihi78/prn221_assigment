using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPF_Project.Command;
using WPF_Project.DTOs;
using WPF_Project.Navigation;
using WPF_Project.Services;
using WPF_Project.Views;

namespace WPF_Project.ViewModels
{
    public class DialogSuppierViewModel : INotifyPropertyChanged
    {
        #region Declare varibles

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private ObservableCollection<ProductDTO> listOrderProduct;

        public ObservableCollection<ProductDTO> ListOrderProduct
        {
            get { return listOrderProduct; }
            set { listOrderProduct = value; OnPropertyChanged(); }
        }

        private double totalPriceOrder;

        public double TotalPriceOrder
        {
            get { return totalPriceOrder; }
            set { totalPriceOrder = value; OnPropertyChanged(); }
        }

        private ObservableCollection<SupplierDTO> listSupplier;

        public ObservableCollection<SupplierDTO> ListSupplier
        {
            get { return listSupplier; }
            set { listSupplier = value; OnPropertyChanged(); }
        }

        private string searchSupplier;

        public string SearchSupplier
        {
            get { return searchSupplier; }
            set { searchSupplier = value; OnPropertyChanged(); GetListSupplier(); }
        }

        private DialogSuppliers _dialogSuppliers;
        private object _viewModelParentScreen;

        public DialogSuppierViewModel(DialogSuppliers dialogSuppliers, object viewModelParentScreen) 
        {
            _dialogSuppliers = dialogSuppliers;
            _viewModelParentScreen = viewModelParentScreen;
            selectedSupplier = new RelayCommand<SupplierDTO>(ExecutSelectedSupplier, non => true);
            GetListSupplier();
        }


        #endregion

        #region Get list suppliers
        public void GetListSupplier()
        {
            SupplierService supplierService = new SupplierService();
            ListSupplier = supplierService.GetSuppliersByCondition(SearchSupplier);
        }
        #endregion

        #region Select Supplier

        private RelayCommand<SupplierDTO> selectedSupplier;

        public RelayCommand<SupplierDTO> SelectedSupplier
        {
            get { return selectedSupplier; }
            set { selectedSupplier = value; }
        }

        public void ExecutSelectedSupplier(SupplierDTO supplier)
        {

            MessageBoxResult comfrim = MessageBox.Show("Are you sure you want to do this?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (comfrim == MessageBoxResult.Yes)
            {
                if (Navigation.NavigationParameters.Parameters.ContainsKey("supplier"))
                {
                    Navigation.NavigationParameters.Parameters.Remove("supplier");
                    Navigation.NavigationParameters.Parameters.Add("supplier", supplier);
                }
                else
                {
                    Navigation.NavigationParameters.Parameters.Add("supplier", supplier);
                }
                
                if(_viewModelParentScreen is CheckoutImportViewModel)
                {
                    ((CheckoutImportViewModel)_viewModelParentScreen).UpdateSupplierInfo();
                }

                _dialogSuppliers.Close();
            }

            
        }


        #endregion

    }
}
