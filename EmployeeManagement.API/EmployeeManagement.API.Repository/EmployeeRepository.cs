using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.API.Repository
{
    public class EmployeeRepository
    {
        private readonly employeeEntities _context;

        public EmployeeRepository(employeeEntities context)
        {
            _context = context;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _context.Employees.ToList();
        }
        public IEnumerable<Manager> GetAllManagers()
        {
            return _context.Managers.ToList();
        }

        public List<Employee> GetEmployeesByManagerId(int id)
        {
            return _context.Employees.Where(e => e.ManagerId == id).ToList();
        }
    }

}
