using System;
using System.Linq;
using TJS.VIMS.Models;

namespace TJS.VIMS.DAL
{
    public class EmployeeRepository : IEmployeeRepository, IDisposable
    {
        private VIMSDBContext vimsDBContext;
        private bool disposed = false;

        public VIMSDBContext Context
        {
            get { return vimsDBContext; }
        }

        public EmployeeRepository(VIMSDBContext vimsDBContext)
        {
            this.vimsDBContext = vimsDBContext;
        }

        public Employee GetEmployee(String userName, String password)
        {
            return vimsDBContext.Employees
                .Where(m => m.UserName.ToLower() == userName.ToLower() && m.Password == password)
                .SingleOrDefault();
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