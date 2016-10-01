using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TJS.VIMS.Models;

namespace TJS.VIMS.DAL
{
    public class EmployeeRepository : IEmployeeRepository,IDisposable
    {
        private VIMSDBContext vimsDBContext;

        public EmployeeRepository(VIMSDBContext vimsDBContext)
        {
            this.vimsDBContext = vimsDBContext;
        }

        private bool disposed = false;

        public Employee GetEmployee(String userName,String password)
        {
            return vimsDBContext.Employees.Where(x => x.UserName.ToLower()
                                                    == userName.ToLower() && 
                                                 x.Password==password).SingleOrDefault();            
        }
       

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    vimsDBContext.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}