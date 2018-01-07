using System;

namespace TJS.VIMS.DAL
{
    public interface IEmployeeRepository : IDisposable
    {
        Employee GetEmployee(String userName, String password);
    }
}
