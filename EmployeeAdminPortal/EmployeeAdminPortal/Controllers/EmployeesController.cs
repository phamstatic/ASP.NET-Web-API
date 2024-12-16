using EmployeeAdminPortal.Data;
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
    }
}
