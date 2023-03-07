using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WPF_Project.Views;
using WPF_Project.Command;
using WPF_Project.Navigation;

namespace WPF_Project.ViewModels
{
    public class HomeViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        

        #region Declare varible



        #endregion


        public HomeViewModel() 
        {
            clickOrderCommand = new RelayCommand(HandleOpenOrderScreen);
            clickImportCommand = new RelayCommand(HandleOpenImportScreen);
            clickProductCommand = new RelayCommand(HandleOpenProductScreen);
        }


        #region handle click tabItem Order

        private RelayCommand clickOrderCommand;

        public RelayCommand ClickOrderCommand
        {
            get { return clickOrderCommand; }
            set { clickOrderCommand = value; OnPropertyChanged();}
        }

        public void HandleOpenOrderScreen()
        {
            NavigationFrameContentHomeScreen.NavigateTo(new Order());
        }

        #endregion


        #region handle click tabItem Import

        private RelayCommand clickImportCommand;

        public RelayCommand ClickImportCommand
        {
            get { return clickImportCommand; }
            set { clickImportCommand = value; OnPropertyChanged(); }
        }

        public void HandleOpenImportScreen()
        {
            NavigationFrameContentHomeScreen.NavigateTo(new Import());
        }

        #endregion


        #region handle click tabItem Product management

        private RelayCommand clickProductCommand;

        public RelayCommand ClickProductCommand
        {
            get { return clickProductCommand; }
            set { clickProductCommand = value; OnPropertyChanged(); }
        }

        public void HandleOpenProductScreen()
        {
            NavigationFrameContentHomeScreen.NavigateTo(new ProductManagement());
        }

        #endregion


    }
}
