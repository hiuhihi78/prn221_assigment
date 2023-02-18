using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;
using WPF_Project.DTOs;
using WPF_Project.Navigation;

namespace WPF_Project.ViewModels
{
    public class CheckoutOrderViewModel :  INotifyPropertyChanged
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


        #endregion

        #region Contructor

        public CheckoutOrderViewModel() 
        {
            GetDataOfPreviousScreen();
        }
        #endregion

        #region Get list order product in Order screen
        public void GetDataOfPreviousScreen()
        {
            ListOrderProduct = (ObservableCollection<ProductDTO>)NavigationParameters.Parameters["listOrder"];
        }
        #endregion
    }
}
