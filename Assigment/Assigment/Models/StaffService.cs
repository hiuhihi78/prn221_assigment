using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assigment.Models
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

    }
}
