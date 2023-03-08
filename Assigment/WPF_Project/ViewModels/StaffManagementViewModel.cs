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
    public class StaffManagementViewModel : INotifyPropertyChanged
    {
        #region Declare varible
        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private ObservableCollection<StaffDTO> staffs;

        public ObservableCollection<StaffDTO> Staffs
        {
            get { return staffs; }
            set { staffs = value; OnPropertyChanged(); }
        }

        private ObservableCollection<RoleDTO> roles;

        public ObservableCollection<RoleDTO> Roles
        {
            get { return roles; }
            set { roles = value; OnPropertyChanged(); }
        }

        private string searchStaff;

        public string SearchStaff
        {
            get { return searchStaff; }
            set { searchStaff = value; OnPropertyChanged(); SearchStaffs(); }
        }

        private int selectedRole;

        public int SelectedRole
        {
            get { return selectedRole; }
            set { selectedRole = value; OnPropertyChanged(); SearchStaffs(); }
        }


        #endregion


        private StaffService staffService;
        private RoleService roleService;
        public StaffManagementViewModel() 
        {
            staffService = new StaffService();
            roleService= new RoleService();

            staffs = new ObservableCollection<StaffDTO>();
            roles = new ObservableCollection<RoleDTO>();
            searchStaff = string.Empty;
            selectedRole = 0;

            createNewStaff = new RelayCommand(ExecuteCreateNewStaff);
            changeStaffStatus = new RelayCommand<StaffDTO>(ExecuteChnageStaffStatus, s => true);

            LoadAllRoleStaff();
            SearchStaffs();
        }

        #region Load all role
        public void LoadAllRoleStaff()
        {
            Roles = roleService.GetAllRole();
            Roles.Add(new RoleDTO() { Id = 0, Name= "All role" });
            var admin = Roles.FirstOrDefault(x => x.Id == 1);
            Roles.Remove(admin);
        }
        #endregion

        #region Search staff
        public void SearchStaffs()
        {
            Staffs = staffService.GetStaffByCondition(SearchStaff, SelectedRole);
        }
        #endregion

        #region Create new staff
        private RelayCommand createNewStaff;

        public RelayCommand  CreateNewStaff
        {
            get { return createNewStaff; }
            set { createNewStaff = value; }
        }

        public void ExecuteCreateNewStaff()
        {
            DialogStaffs dialogStaffs = new DialogStaffs();
            dialogStaffs.DataContext = new DialogStaffsViewModel(dialogStaffs, this, null, true);
            dialogStaffs.ShowDialog();
        }

        #endregion


        #region Change Status Staff's account
        private RelayCommand<StaffDTO> changeStaffStatus;

        public RelayCommand<StaffDTO> ChangeStaffStatus
        {
            get { return changeStaffStatus; }
            set { changeStaffStatus = value; }
        }

        private void ExecuteChnageStaffStatus(StaffDTO staff)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure change status?", "Log Out", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                staffService.SwitchStatusStaff(staff);
                SearchStaffs();
            }
        }

        #endregion

    }
}
