using Microsoft.AspNetCore.Mvc;
using EmployeeManagement.API.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagementLookup.API.Interfaces
{
    public interface IEmployeeManagementController
    {
        Task<ActionResult<List<EmployeeManagementResult>>> GetAllEmployees();

        Task<ActionResult<List<EmployeeManagementResult>>> GetAllManagers();
        Task<ActionResult<List<EmployeeManagementResult>>> LookupEmployeeManagementAsync(int EmployeeManagerID);


    }
}
