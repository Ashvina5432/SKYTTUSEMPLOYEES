using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkyEmployees.BL;
using SkyEmployees.Core;

namespace SkyEmployees.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        EmployeeBL _bl;

        public EmployeeController(EmployeeBL employeeBL)
        {
            _bl = employeeBL;
        }
        [HttpGet]

        public List<Employee> GetAllEmployee()
        {
            return _bl.GetAllEmployee();
        }
        [HttpGet]
        public Employee? Get(string? empCode )
        {
            return _bl.Search(new Employee { EmpCode= empCode });
        }


        [HttpPost]
        public Employee? AddEmployee(Employee employee)
        {
            // if ((_bl.EmailChecker(employee.Email)) == true)
            //{
            //    return BadRequest(new { message = "Email already register!" });
            //}
             return _bl.AddEmployee(employee);
            //return Ok(new { message = "User register Succesfully!" });
        }
        [HttpPut]

        public Employee? Update(Guid id, Employee employee)
        {
            return _bl.Update(id, employee);
        }
        [HttpDelete]
        public bool Delete(Guid id)
        {
            return _bl.Delete(id);
        }
        

    }
}
