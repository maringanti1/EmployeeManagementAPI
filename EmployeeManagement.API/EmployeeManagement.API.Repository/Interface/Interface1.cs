using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.API.Repository.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        EmployeeRepository EmployeeRepository { get; } 

        void Commit();
    }

}
