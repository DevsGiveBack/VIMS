using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TJS.VIMS.Models;

namespace TJS.VIMS.Business
{
    interface IAdministration
    {
        bool CreateOrganization(Organization organization);
        bool EditOrganization(Organization organization);
        bool UpdateOrganization(Organization organization);
        bool DeleteOrganization(long id);
        bool UnDeleteOrganization(long id);
        bool CreateEmployee(Employee employee);
        bool EditEmployee(Employee employee);
        bool DeleteEmployee(long id);
        bool UnDeleteEmployee(long id);
    }
}
