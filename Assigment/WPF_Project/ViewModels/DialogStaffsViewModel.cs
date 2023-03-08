using Microsoft.EntityFrameworkCore.Infrastructure;
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
    public class DialogStaffsViewModel : INotifyPropertyChanged
    {
        #region Declare varibles
        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private StaffDTO staff;

        public StaffDTO Staff
        {
            get { return staff; }
            set { staff = value; OnPropertyChanged(); }
        }

        private ObservableCollection<RoleDTO> roles;

        public ObservableCollection<RoleDTO> Roles
        {
            get { return roles; }
            set { roles = value; OnPropertyChanged(); }
        }


        #endregion

        public bool IsEnableItem { get; set; }

        private DialogStaffs _dialogStaffs;
        private object _viewModelParentScreen;
        private object _staffInfo;
        private bool _isUpdate;


        private StaffService staffService;
        private RoleService roleService;
        public DialogStaffsViewModel(DialogStaffs dialogStaffs, object viewModelParentScreen, object staffInfo, bool isUpadate)
        {

            staffService = new StaffService();
            roleService = new RoleService();

            _dialogStaffs = dialogStaffs;
            _viewModelParentScreen = viewModelParentScreen;
            _staffInfo = staffInfo;
            _isUpdate = isUpadate;

            staff = new StaffDTO();

            
            staff = new StaffDTO() { Role = 1, Password = "123" };
            Roles = new ObservableCollection<RoleDTO>();

            IsEnableItem = false;
            CheckItemEnable();
            LoadAllRoleStaff();

            saveCommand = new RelayCommand(ExecuteSaveCommand);
            

        }

        public DialogStaffsViewModel() { }

        #region Check Item Enable
        public void CheckItemEnable()
        {
            if (_isUpdate || _staffInfo == null)
            {
                IsEnableItem = true;
            }
            else
            {
                IsEnableItem = false;
            }
        }
        #endregion

        #region Load all role
        public void LoadAllRoleStaff()
        {
            Roles = roleService.GetAllRole();
        }
        #endregion

        #region Save command
        private RelayCommand saveCommand;

        public RelayCommand SaveCommand
        {
            get { return saveCommand; }
            set { saveCommand = value; }
        }

        public void ExecuteSaveCommand()
        {

            MessageBoxResult result = MessageBox.Show("Are you sure to create new staff's account?", "Log Out", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.No)
            {
                return;
            }
            ShopDbContext context = new ShopDbContext();

            if (string.IsNullOrEmpty(Staff.Fullname) ||
                string.IsNullOrEmpty(Staff.Username) ||
                string.IsNullOrEmpty(Staff.Address) ||
                string.IsNullOrEmpty(Staff.Phone)
                )
            {
                MessageBox.Show("You must input all field!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            if (!(Int32.TryParse(Staff.Phone, out var a) && Staff.Phone.Length == 10))
            {
                MessageBox.Show("Phone must be a number", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (staffService.GetStaffByPhone(Staff.Phone) != null)
            {
                MessageBox.Show("Phone number was existed", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (staffService.GetStaffByUsername(Staff.Username) != null)
            {
                MessageBox.Show("Username was existed", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            if (_staffInfo == null) //create 
            {
                staffService.AddStaff(Staff);
            }
            else
            {
                staffService.UpdateStaff(Staff);
            }

            MessageBox.Show("Success!", "Alter", MessageBoxButton.OK, MessageBoxImage.Information);

            ((StaffManagementViewModel)_viewModelParentScreen).SearchStaffs();
            ((StaffManagementViewModel)_viewModelParentScreen).LoadAllRoleStaff();
            _dialogStaffs.Close();
        }

        #endregion




    }
}
