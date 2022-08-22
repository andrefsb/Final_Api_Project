using Application.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository
{
    public interface IEmployeeRepository
    {
        Employee Create(Employee employee);
        Employee Read(int id);
        Employee Update (Employee employee);
        void Delete(int id);

    }
}
