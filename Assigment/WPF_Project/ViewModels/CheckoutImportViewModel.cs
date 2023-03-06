using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
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
using MaterialDesignThemes.Wpf;
using System.Diagnostics;

namespace WPF_Project.ViewModels
{
    public class CheckoutImportViewModel : INotifyPropertyChanged
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

        private SupplierDTO selectedhSupplier;

        public SupplierDTO SelectedSupplier
        {
            get { return selectedhSupplier; }
            set { selectedhSupplier = value; OnPropertyChanged(); }
        }


        #endregion

        #region Contructor

        public CheckoutImportViewModel()
        {
            GetDataOfPreviousScreen();
            selectedhSupplier = new SupplierDTO()
            {
                Name = string.Empty,
                Phone = string.Empty,
                Address = string.Empty,
            };
            backToPreviousScreen = new RelayCommand(HandleBackToPreviousScreen);
            checkoutImportProduct = new RelayCommand(HandleChecoutImportProducts);
            openDialogSuppliers = new RelayCommand(ExecuteOpenDialogSuppliers);
            UpdateSupplierInfo();
        }
        #endregion

        #region Get data in Order screen (products ordered, total price order)
        public void GetDataOfPreviousScreen()
        {
            ListOrderProduct = (ObservableCollection<ProductDTO>)NavigationParameters.Parameters["listImported"];
            TotalPriceOrder = (double)NavigationParameters.Parameters["totalPriceImport"];
        }
        #endregion

        #region Handle click back to Order screen

        private RelayCommand backToPreviousScreen;

        public RelayCommand BackToPreviousScreen
        {
            get { return backToPreviousScreen; }
            set { backToPreviousScreen = value; }
        }

        public void HandleBackToPreviousScreen()
        {
            NavigationFrameContentHomeScreen.NavigateTo(new Import());
        }

        #endregion

        #region Handle click checkout

        private RelayCommand checkoutImportProduct;

        public RelayCommand CheckoutOrderProduct
        {
            get { return checkoutImportProduct; }
            set { checkoutImportProduct = value; }
        }

        public void HandleChecoutImportProducts()
        {
            if (string.IsNullOrEmpty(SelectedSupplier.Name))
            {
                MessageBox.Show("You must choose a supplier!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            MessageBoxResult comfrim = MessageBox.Show("Are you sure you want to do this?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (comfrim == MessageBoxResult.Yes)
            {
                ImportService importService = new ImportService();  

                Models.Import importInfo = new Models.Import()
                {
                    StaffId = ((Models.Staff)NavigationParameters.Parameters["currentUser"]).Id,
                    ImportDate = DateTime.Now,
                    SupplierId = SelectedSupplier.Id,
                    TotalAmount = double.Parse(TotalPriceOrder.ToString())
                };

                var importSuccess = importService.AddNewImport(ListOrderProduct, importInfo);


                if (importSuccess)
                {
                    MessageBox.Show("Success!", "Alter", MessageBoxButton.OK, MessageBoxImage.Information);
                    // remove cart
                    NavigationParameters.Parameters.Remove("listImported");
                    NavigationParameters.Parameters.Remove("totalPriceImport");
                    NavigationParameters.Parameters.Remove("supplier");
                    // navigation Order screen
                    NavigationFrameContentHomeScreen.NavigateTo(new Import());
                }
                else
                {
                    MessageBox.Show("Something was wrong!\nPlease ask administrator!", "Alter", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }
        #endregion

        #region Open dialog Suppliers
        private RelayCommand openDialogSuppliers;

        public RelayCommand OpenDialogSuppliers
        {
            get { return openDialogSuppliers; }
            set { openDialogSuppliers = value; OnPropertyChanged(); }
        }

        public async void ExecuteOpenDialogSuppliers()
        {
            DialogSuppliers dialogSuppliers = new DialogSuppliers();
            dialogSuppliers.DataContext = new DialogSuppierViewModel(dialogSuppliers,this);
            dialogSuppliers.ShowDialog();
        }



        #endregion

        #region Get info Supplier was choose
        public void UpdateSupplierInfo()
        {
            if (Navigation.NavigationParameters.Parameters.ContainsKey("supplier"))
            {
                var supplier = (SupplierDTO)Navigation.NavigationParameters.Parameters["supplier"];
                SelectedSupplier = supplier;
            }
        }
        #endregion
    }
}
