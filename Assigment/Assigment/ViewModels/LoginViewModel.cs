using Assigment.Command;
using Assigment.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Assigment.ViewModels
{
    public partial class LoginViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        StaffService staffService;

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

      
        public LoginViewModel() 
        {
            Staff = new StaffDTO();
            staffService = new StaffService();
            loginCommand = new RelayCommand(Login); 
        }

        private RelayCommand loginCommand;
        public RelayCommand LoginCommand
        {
            get { return loginCommand; }
        }

        public void Login()
        {
            try
            {
                var user = staffService.GetUser(Staff);    
                if(user != null)
                {
                    Message = "Login success!";
                }
                else
                {
                    Message = "Login fail!";
                }
            }catch(Exception ex) {
                Message = "Exceptopm!";
            }
        }



    }
}
