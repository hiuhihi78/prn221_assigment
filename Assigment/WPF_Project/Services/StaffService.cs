using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Project.DTOs;
using WPF_Project.Models;

namespace WPF_Project.Services
{
    public class StaffService
    {
        public ShopDbContext context;

        public StaffService()
        {
            context = new ShopDbContext();
        }

        public Staff GetUser(StaffDTO staff)
        {
            Staff user = context.Staff.Where(x => x.Username == staff.Username && x.Password == staff.Password).FirstOrDefault();
            return user;
        }

        public Staff GetUserInfoByUserName(string userName)
        {
            Staff user = context.Staff.Where(x => x.Username == userName).FirstOrDefault();
            return user;
        }

        public bool AddStaff(StaffDTO staffDTO)
        {
            try
            {
                Staff user = new Staff()
                {
                    Username = staffDTO.Username,
                    Password = staffDTO.Password,
                    Address = staffDTO.Address,
                    Fullname = staffDTO.Fullname,
                    Role = staffDTO.Role,
                    Phone = staffDTO.Phone,
                    Status = true
                };
                context.Staff.Add(user);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public ObservableCollection<StaffDTO> GetStaffByCondition(string paramSearch, int role)
        {
            ObservableCollection<StaffDTO> result = new ObservableCollection<StaffDTO>(); 
            List<Staff> listStaff= new List<Staff>();
            if (role == 0)
            {
                listStaff = context.Staff
                                    .Include(x => x.RoleNavigation)
                                   .Where
                                   (x => (
                                         x.Username.Contains(paramSearch) ||
                                         x.Fullname.Contains(paramSearch) ||
                                         x.Phone.Contains(paramSearch)
                                         )  &&
                                         x.Role != 1
                                   )
                                   .ToList();
            }
            else
            {
                listStaff = context.Staff
                                   .Include(x => x.RoleNavigation)
                                   .Where
                                   (x => (
                                         x.Username.Contains(paramSearch) ||
                                         x.Fullname.Contains(paramSearch)  ||
                                         x.Phone.Contains(paramSearch)
                                         )  &&
                                         x.Role == role  &&
                                         x.Role != 1
                                   )
                                   .ToList();
            }

            foreach (var item in listStaff)
            {
                result.Add(StaffDTO.FromStaff(item));
            }

            return result;
        }

        public Staff GetStaffByPhone(string phone) 
        {
            return context.Staff.FirstOrDefault(x => x.Phone == phone);
        }

        public Staff GetStaffByUsername(string username)
        {
            return context.Staff.FirstOrDefault(x => x.Username == username);
        }

        public void UpdateStaff(StaffDTO staffUpdate) 
        {
            var staff = context.Staff.FirstOrDefault(x => x.Id == staffUpdate.Id);
            if (staff != null) 
            {
                staff.Address = staffUpdate.Address;
                staff.Status = staffUpdate.Status;
                staff.Role = staffUpdate.Role;  
                staff.Username = staffUpdate.Username;
                staff.Fullname= staffUpdate.Fullname;
                staff.Phone = staffUpdate.Phone;
            }
            context.SaveChanges();
        }

        public void SwitchStatusStaff(StaffDTO staff)
        {
            var staffUpdate = context.Staff.FirstOrDefault(x => x.Id == staff.Id);
            if (staffUpdate != null) 
            {
                staffUpdate.Status = !staffUpdate.Status;
                context.SaveChanges();
            }
        }

        public bool CheckStaffIsEnable(StaffDTO staff)
        {
            var user = GetUser(staff);
            return  context.Staff.FirstOrDefault(x => x.Username == user.Username && x.Password == user.Password && user.Status == true)!=null;
        }

    }
}
