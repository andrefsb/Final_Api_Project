using Application.Context;
using Application.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository
{
    public class Repository_Db : IEmployeeRepository
    {
        private readonly SQLiteContext context;

        public Repository_Db(SQLiteContext context)
        {
            this.context = context;
        }
        public Employee Add(Employee employee)
        {
            employee = context.Employee.Add(employee).Entity;
            context.SaveChanges();
            return employee;
        }

        public Employee Get(int id)
        {
            return context.Employee.FirstOrDefault(x => x.Id == id);
        }

        public List<Employee> GetAll()
        {
            return context.Employee.ToList();
        }

        public void Remove(int id)
        {
            var employee = Get(id);
            context.Employee.Remove(employee);
            context.SaveChanges();
        }
    }
}
