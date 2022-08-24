using Application.Context;
using Application.Entities;
using Application.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Final_Project.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {

        public EmployeeController(IEmployeeRepository repository)
        {
            this.repository = repository;
        }

        private readonly IEmployeeRepository repository;

        [HttpGet()]
        [Route("/{id}")]
        public Employee Get(int id)
        {
            return repository.Get(id);
        }
        [HttpDelete()]
        [Route("/delete/{id}")]
        public void Delete(int id)
        {
            repository.Remove(id);
        }
        [HttpGet()]
        [Route("/getall")]
        public List<Employee> GetAll()
        {
            return repository.GetAll();
        }
        [HttpPost()]
        [Route("/add")]
        public Employee Add(Employee employee)
        {
            return repository.Add(employee);
        }
        //[HttpGet()]
        //[Route("/genders")]
        //public List<string> GetGenders()
        //{
        //    return repository.GetAll().Select(x => x.Gender).Distinct().ToList();
        //}
    }
}