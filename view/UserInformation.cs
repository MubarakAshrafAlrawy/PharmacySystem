using PharmacyProject1Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy_project
{
     static class   UserInformation
    {
        public static int employee_id { get; set; }
        public static string name { get; set; }
        public static string phone { get; set; }
        public static string email { get; set; }
        public static string adress { get; set; }
        public static string password { get; set; }
        public static int salary { get; set; }
        public static System.DateTime hire_date { get; set; }
        public static byte[] image { get; set; }
        public static string type { get; set; }

        public static void set_UserInformation(employee emp)
        {
            employee_id = emp.employee_id;
            name = emp.name;
            phone = emp.phone;
            email = emp.email;
            adress = emp.adress;
            password = emp.password;
            salary = emp.salary;
            hire_date = emp.hire_date;
            image = emp.image;
            type = emp.type;
        }
    }           
}
