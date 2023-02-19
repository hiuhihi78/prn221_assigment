using System;
using System.Collections.Generic;
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
                    Role = 1,
                    Phone = staffDTO.Phone,
                    Status = false
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

    }
}
