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

        public Employee GetEmployee(string userName, string password)
        {
            return SingleOrDefault(m => m.UserName.ToLower() == userName.ToLower() && m.Password == password);
        }



        public bool CreateEmployee(int admin_id, Employee employee)
        {
            //Employee current_employee = context.Employees.Find(employee.Id);
            //if (employee != null && (bool)employee.Active) // BKP fix should not be nullable
            //{
            //    int count = context.Employees.
            //        Where(m => m.UserName == employee.UserName && m.Id != employee.Id).
            //        Count();

            //    if (count == 0)
            //    {
            //        employee.UpdatedBy = admin_id;
            //        employee.UpdatedDt = System.DateTime.Now;
            //        context.Entry(current_employee).CurrentValues.SetValues(employee);
            //        context.SaveChanges();
            //        return View("EditemployeeConfirmation", employee);
            //    }
            //}
            return false;
        }


    }
}