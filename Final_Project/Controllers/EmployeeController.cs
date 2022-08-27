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
        [HttpGet()]
        [Route("/getall/{name}")]
        public List<Employee> GetByName(string name)
        {
            return repository.GetByName(name);
        }
        [HttpGet()]
        [Route("/getallg/{gender}")]
        public List<Employee> GetByGender(string gender)
        {
            return repository.GetByGender(gender);
        }
        [HttpGet()]
        [Route("/getalle/{email}")]
        public List<Employee> GetByEmail(string email)
        {
            return repository.GetByEmail(email);
        }
        [HttpGet()]
        [Route("/getallip/{ip}")]
        public List<Employee> GetByIp(string ip)
        {
            return repository.GetByIp(ip);
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