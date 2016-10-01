using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TJS.VIMS.Models;

namespace TJS.VIMS.DAL
{
    public interface IEmployeeRepository :IDisposable
    {
        Employee GetEmployee(String userName, String password);
    }
}
