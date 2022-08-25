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
        Employee Add(Employee employee);
        Employee Get(int id);
        List<Employee> GetAll ();
        void Remove(int id);
        void Edit(int id,Employee employee);

        

    }
}
