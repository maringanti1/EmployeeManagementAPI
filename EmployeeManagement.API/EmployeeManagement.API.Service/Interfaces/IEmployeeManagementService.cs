using EmployeeManagement.API.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagement.API.Service.Interfaces
{
    public interface IEmployeeManagementService
    {
        List<EmployeeManagementResult> LookupEmployeeManagement(int  EmployeeManagerID);
        List<EmployeeManagementResult> GetAllEmployees();
        List<EmployeeManagementResult> GetAllManagers();


    }
}
