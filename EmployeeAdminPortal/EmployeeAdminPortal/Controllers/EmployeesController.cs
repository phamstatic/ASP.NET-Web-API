using EmployeeAdminPortal.Data;
using EmployeeAdminPortal.Models;
using EmployeeAdminPortal.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAdminPortal.Controllers
{
    [Route("api/[controller]")] // localhost:xxxx/api/employees
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        public EmployeesController(ApplicationDbContext dbContext)
        {
            this.DbContext = dbContext;
        }

        public ApplicationDbContext DbContext { get; }

        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            var allEmployees = DbContext.Employees.ToList();

            return Ok(allEmployees);
        }

        [HttpGet]
        [Route("{id:guid")]
        public IActionResult GetEmployeeById(Guid id)
        {
            var employee = DbContext.Employees.Find(id);

            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpPost]
        public IActionResult AddEmployee(AddEmployeeDto addEmployeeDto)
        {
            var employeeEntity = new Employee()
            { 
                Name = addEmployeeDto.Name, 
                Email = addEmployeeDto.Email,
                Phone = addEmployeeDto.Phone,
                Salary = addEmployeeDto.Salary
            };

            DbContext.Employees.Add(employeeEntity);
            DbContext.SaveChanges();

            return Ok(employeeEntity);
        }
    }
}
