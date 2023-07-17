using Microsoft.EntityFrameworkCore.Migrations.Operations;
using SkyEmployees.Core;
using SkyEmployees.DAL;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace SkyEmployees.BL
{
    public class EmployeeBL
    {
        EmployeeRepository _repository;

        public EmployeeBL(EmployeeRepository repository)
        {
            _repository = repository;
        }
        public Employee? AddEmployee(Employee employee)
        {
            var existingEmployee = Search(new Employee() { EmpCode = employee.EmpCode });
            if(existingEmployee != null)
            {
                throw new Exception("Employee Code Already Exist");
            }
            var id = _repository.AddEmployee(employee);
            Employee? returnValue = null;
            if (id != null)
            {
                returnValue = new Employee();
                returnValue=Search(new Employee() { Id = id });
            }
            return returnValue;
        }

        

        public List<Employee> GetAllEmployee()
        {
            return _repository.GetAllEmployee();

        }
        public Employee Search(Employee employee)
        {
          return  _repository.Search(employee);

        }
       
        public Employee? Update(Guid id,Employee employee)
        {
             return _repository.Update(id,employee);
            //var existingEmployee = Search(new Employee() { Id = employee.Id });
            //    if (existingEmployee != null)
            //{
            //    throw new Exception("Please enter correct Id");

            //}
            //var UpdateDate = _repository.Update(employee);
            //return UpdateDate;


        }

        public bool Delete(Guid id)
        {
             return _repository.Delete(id);

        }
        public bool EmailChecker(string email)
        {
            return _repository.CheckEmailExistance(email);
        }
    }


}