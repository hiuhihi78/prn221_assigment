using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Project.Models
{
    public class StaffService
    {
        public ShopTestContext context;

        public StaffService()
        {
            context = new ShopTestContext();
        }

        public Staff GetUser(StaffDTO staff)
        {
            Staff user = context.Staff.Where(x => x.Username== staff.Username && x.Password == staff.Password).FirstOrDefault();
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
                    IsManager = false,
                    Phone = staffDTO.Phone,
                    Status = false
                };
                context.Staff.Add(user);
                context.SaveChanges();
                return true;
            }catch(Exception ex) 
            {
                return false;
            }
        }

    }
}
