using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WPF_Project.Command;
using WPF_Project.DTOs;
using WPF_Project.Navigation;
using WPF_Project.Services;
using WPF_Project.Views;

namespace WPF_Project.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private StaffService staffService;

        private StaffDTO staff;

        public StaffDTO Staff
        {
            get { return staff; }
            set { staff = value; OnPropertyChanged(); }
        }
        private string message;
        public String Message
        {
            get { return message; }
            set { message = value; OnPropertyChanged(); }
        }

        private bool isOpenPopupRegister;

        public bool IsOpenPopupRegister
        {
            get { return isOpenPopupRegister; }
            set { isOpenPopupRegister = value; OnPropertyChanged(); }
        }


        public LoginViewModel()
        {
            Staff = new StaffDTO();
            staffService = new StaffService();
            loginCommand = new RelayCommand(Login);
            isOpenPopupRegister = false;
        }


        #region Login

        private RelayCommand loginCommand;

        public RelayCommand LoginCommand
        {
            get { return loginCommand; }
            set { loginCommand = value; OnPropertyChanged();}
        }

        public void Login()
        {
            try
            {
                var user = staffService.GetUser(Staff);
                if (user != null)
                {
                    NavigationParameters.Parameters.Add("currentUser", user);
                    NavigationService.NavigateTo(new Home());
                }
                else
                {
                    Message = "Login fail!";
                }
            }
            catch (Exception ex)
            {
                Message = "Sorry! Something was wrong!";
            }
        }
        #endregion

    }
}
