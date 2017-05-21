using System;
using System.Linq;
using TJS.VIMS.Models;

namespace TJS.VIMS.DAL
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(VIMSDBContext context) : base(context)
        {
        }

        public Employee GetEmployee(String userName, String password)
        {
            //return context.Employees
            //    .Where(m => m.UserName.ToLower() == userName.ToLower() && m.Password == password)
            //    .SingleOrDefault();

            return SingleOrDefault(m => m.UserName.ToLower() == userName.ToLower() && m.Password == password);
        }
    }
}