using backend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace backend.Repositories
{
    public interface IEmployeeRepository
    {
        public Task<IEnumerable<Employee>> GetAllEmployeesAsync();
        public Task<Employee?> GetEmployeeByIdAsync(int id);
        public Task AddEmployeeAsync(Employee employee);
        public Task UpdateEmployeeAsync(Employee employee);
        public Task DeleteEmployeeAsync(int id);
    }
}
