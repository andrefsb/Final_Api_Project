using Application.Context;
using Application.Entities;


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
        public List<Employee> GetByName(string name)
        {
            return context.Employee
                .Where(x => x.First_name.Contains(name) || x.Last_name.Contains(name))
                .OrderBy(x => x.Id)
                .ToList();
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

        public void Edit(int id, Employee employee)
        {
            var valor = Get(id);
            valor.First_name = employee.First_name;
            valor.Last_name = employee.Last_name;
            valor.Email = employee.Email;
            valor.Gender = employee.Gender;
            valor.Ip_address = employee.Ip_address;
            context.Employee.Update(valor);
            context.SaveChanges();
        }
    }
}
