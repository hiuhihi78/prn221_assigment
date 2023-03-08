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
using WPF_Project.Models;
using System.Windows;

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
            clickAccountManageCommand = new RelayCommand(HandleOpenAccountManageScreen);
            clickLogoutCommand = new RelayCommand(HandleLogout);
            clickHistoryOrderCommand = new RelayCommand(HandleOpenHistoryOrderScreen);
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
            NavigationFrameContentHomeScreen.NavigateTo(new Views.Order());
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
            NavigationFrameContentHomeScreen.NavigateTo(new Views.Import());
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
            NavigationFrameContentHomeScreen.NavigateTo(new Views.ProductManagement());
        }

        #endregion

        #region handle click tabItem Product management

        private RelayCommand clickAccountManageCommand;

        public RelayCommand ClickAccountManageCommand
        {
            get { return clickAccountManageCommand; }
            set { clickAccountManageCommand = value; OnPropertyChanged(); }
        }

        public void HandleOpenAccountManageScreen()
        {
            NavigationFrameContentHomeScreen.NavigateTo(new Views.StaffManagement());
        }

        #endregion

        #region Logout
        private RelayCommand clickLogoutCommand;

        public RelayCommand ClickLogoutCommand
        {
            get { return clickLogoutCommand; }
            set { clickLogoutCommand = value; }
        }

        public void HandleLogout()
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to log out?", "Log Out", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                Navigation.NavigationParameters.Parameters.Remove("currentUser");
                Navigation.NavigationService.NavigateTo(new Login());
            }
        }

        #endregion


        #region handle click tabItem Product management

        private RelayCommand clickHistoryOrderCommand;

        public RelayCommand ClickHistoryOrderCommand
        {
            get { return clickHistoryOrderCommand; }
            set { clickHistoryOrderCommand = value; OnPropertyChanged(); }
        }

        public void HandleOpenHistoryOrderScreen()
        {
            NavigationFrameContentHomeScreen.NavigateTo(new Views.HistoryOrder());
        }

        #endregion


        
    }
}
