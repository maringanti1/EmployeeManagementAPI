using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EmployeeManagement.API.Model;
using EmployeeManagement.API.Service.Common;
using EmployeeManagement.API.Service.Interfaces;
using EmployeeManagementLookup.API.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementLookup.API.Controllers
{
    [EnableCors("AllowOrigin")]
    [ApiController]
    [Route("api/[controller]")]    
    public class EmployeeManagementController : IEmployeeManagementController
    { 
        private readonly IEmployeeManagementService _service;
        private readonly ILogger _logger; 
        public EmployeeManagementController(ILogger logger, 
            IEmployeeManagementService service )  
        {
            _logger = logger;
            _service = service; 
        }

        [HttpGet("getallemployees")]
        public async Task<ActionResult<List<EmployeeManagementResult>>> GetAllEmployees()
        {
            _logger.LogInformation("Lookup EmployeeManagement execution is started");
            try
            { 
                var result = _service.GetAllEmployees();
                return result;
            }
            catch (CustomException ex)
            {
                throw new CustomException(_logger, ex.StatusCode, ex.Message); ;
            }
            finally
            {
                _logger.LogInformation("Lookup EmployeeManagement execution is completed");

            }
        }

        [HttpGet("getallmanagers")]
        public async Task<ActionResult<List<EmployeeManagementResult>>> GetAllManagers()
        {
            _logger.LogInformation("Lookup EmployeeManagement execution is started");
            try
            {
                var result = _service.GetAllManagers();
                return result;
            }
            catch (CustomException ex)
            {
                throw new CustomException(_logger, ex.StatusCode, ex.Message); ;
            }
            finally
            {
                _logger.LogInformation("Lookup EmployeeManagement execution is completed");

            }
        }

        [HttpGet("lookup")]
        public async Task<ActionResult<List<EmployeeManagementResult>>> LookupEmployeeManagementAsync(int EmployeeManagerID)
        {
            _logger.LogInformation("Lookup EmployeeManagement execution is started");
            try
            {
                 
                if (EmployeeManagerID <= 0 )
                {
                    // Handle missing or empty config value
                    throw new Exception("Manager is missing or empty!");
                }
                var result = _service.LookupEmployeeManagement(EmployeeManagerID);
                return result;
            }
            catch (CustomException ex)
            {
                throw new CustomException(_logger, ex.StatusCode, ex.Message); ;
            }
            finally
            {
                _logger.LogInformation("Lookup EmployeeManagement execution is completed");
            
            }
        }
    }
}
