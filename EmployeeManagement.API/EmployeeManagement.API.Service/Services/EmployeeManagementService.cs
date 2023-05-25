using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using EmployeeManagement.API.Model;
using EmployeeManagement.API.Service.Common;
using EmployeeManagement.API.Service.Interfaces;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using EmployeeManagement.API.Repository;

namespace EmployeeManagement.API.Service
{
    public class EmployeeManagementService : IEmployeeManagementService
    {
        private readonly IHttpClientRepository _repository;
        private readonly EmployeeManagementConfig _EmployeeManagementConfig;
        private readonly ILogger _logger;
        private readonly JsonSerializerOptions _options;
        public EmployeeManagementService(IHttpClientRepository repository,
            EmployeeManagementConfig EmployeeManagementConfig, ILogger logger)
        { 
            _options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            _repository = repository;
            _logger = logger;
            _EmployeeManagementConfig = EmployeeManagementConfig;
        }

        public List<EmployeeManagementResult> GetAllEmployees()
        {
            List<EmployeeManagementResult> employeeManagementResults = new List<EmployeeManagementResult>();
            employeeEntities employee = new employeeEntities();
            UnitOfWork unitOfWork = new UnitOfWork(employee);
            var employees = unitOfWork.EmployeeRepository.GetAllEmployees();
            unitOfWork.Commit();
            foreach (var i in employees)
            {
                EmployeeManagementResult employeeManagementResult = new EmployeeManagementResult();
                employeeManagementResult.FirstName = i.FirstName;
                employeeManagementResult.LastName = i.LastName;
                employeeManagementResult.Email = i.Email;
                employeeManagementResult.Phone = i.Phone;
                employeeManagementResult.ManagerId = i.ManagerId;
                employeeManagementResult.EmployeeId = i.EmployeeId;
                employeeManagementResults.Add(employeeManagementResult);
            }
            return employeeManagementResults;
        }

        public List<EmployeeManagementResult> GetAllManagers()
        {
            List<EmployeeManagementResult> employeeManagementResults = new List<EmployeeManagementResult>();
            employeeEntities employee = new employeeEntities();
            UnitOfWork unitOfWork = new UnitOfWork(employee);
            var managers = unitOfWork.EmployeeRepository.GetAllManagers();
            unitOfWork.Commit();
            foreach (var i in managers)
            {
                EmployeeManagementResult employeeManagementResult = new EmployeeManagementResult();
                employeeManagementResult.FirstName = i.FirstName;
                employeeManagementResult.LastName = i.LastName;
                employeeManagementResult.Email = i.Email;
                employeeManagementResult.Phone = i.Phone;
                employeeManagementResult.ManagerId = i.ManagerId;
                employeeManagementResult.EmployeeId = i.ManagerId;
                employeeManagementResults.Add(employeeManagementResult);
            }
            return employeeManagementResults;
        }


        public List<EmployeeManagementResult> LookupEmployeeManagement(int EmployeeManagerID)
        {
            List<EmployeeManagementResult> employeeManagementResults = new List<EmployeeManagementResult>();
            employeeEntities employee = new employeeEntities();
            UnitOfWork unitOfWork = new UnitOfWork(employee);
            var employees =  unitOfWork.EmployeeRepository.GetEmployeesByManagerId(EmployeeManagerID);
            unitOfWork.Commit();
            foreach(var i in employees) {
                EmployeeManagementResult employeeManagementResult= new EmployeeManagementResult();
                employeeManagementResult.FirstName = i.FirstName;
                employeeManagementResult.LastName = i.LastName;
                employeeManagementResult.Email = i.Email;
                employeeManagementResult.Phone = i.Phone;
                employeeManagementResult.ManagerId = i.ManagerId;
                employeeManagementResult.EmployeeId = i.EmployeeId;
                employeeManagementResults.Add(employeeManagementResult);
            }

            
            return employeeManagementResults; 
             
        }
    }

}
