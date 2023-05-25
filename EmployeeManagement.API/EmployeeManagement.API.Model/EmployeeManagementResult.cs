using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace EmployeeManagement.API.Model
{
    public class EmployeeManagementResult
    {
        public int? ManagerId { get; set; } 
        public int? EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; } 
    }     
}
