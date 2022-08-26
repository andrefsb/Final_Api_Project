using Application.Entities;


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
