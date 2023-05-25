using EmployeeManagement.API.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.API.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly employeeEntities _context; 
        private EmployeeRepository _employeeRepository; 
        public UnitOfWork(employeeEntities context)
        {
            _context = context;
        }

        public EmployeeRepository EmployeeRepository
        {
            get
            {
                if (_employeeRepository == null)
                {
                    _employeeRepository = new EmployeeRepository(_context);
                }
                return _employeeRepository;
            }
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }


}
