using Application.Entities;


namespace Application.Repository
{
    public interface IEmployeeRepository
    {
        Employee Add(Employee employee);
        Employee Get(int id);
        List<Employee> GetByName(string name);
        List<Employee> GetByGender(string gender);
        List<Employee> GetAll();
        void Remove(int id);
        void Edit(int id, Employee employee);



    }
}
