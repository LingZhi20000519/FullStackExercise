using backend.Models;
using backend.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public readonly IEmployeeRepository employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetAllEmployeesAsync() => Ok(await employeeRepository.GetAllEmployeesAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee?>> GetEmployeeByIdAsync(int id)
        {
            Employee? employee = await employeeRepository.GetEmployeeByIdAsync(id);
            if(employee == null) return NotFound();
            return Ok(employee);
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> CreateEmployee(Employee employee)
        {
            await employeeRepository.AddEmployeeAsync(employee);
            return Ok(employee);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmployeeAsync(int id)
        {
            await employeeRepository.DeleteEmployeeAsync(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Employee>> UpdateEmployeeAsync(int id,Employee employee)
        {
            if (id != employee.Id)  return BadRequest();
            await employeeRepository.UpdateEmployeeAsync(employee);
            return Ok(employee);
        }
    }
}
