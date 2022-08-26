using Application.Entities;
using Application.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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
        [HttpPut()]
        [Route("/edit/{id:int}")]
        public void Edit(int id, Employee employee)
        {
            //if (id != employee.Id)
            //{
            //HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            //}
            //else
            //{
          
            repository.Edit(id,employee);
            HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;
            //}

        }
    }
}