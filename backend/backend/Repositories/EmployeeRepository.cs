using backend.Data;
using backend.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace backend.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext? appDbContext;

        public EmployeeRepository(AppDbContext appDbContext) 
        {
            this.appDbContext = appDbContext;
        }

        public async Task AddEmployeeAsync(Employee employee)
        {
            if (appDbContext == null || appDbContext.Employees == null) throw new System.Exception("Db Context error");
            await appDbContext.Employees.AddAsync(employee);
            await appDbContext.SaveChangesAsync();
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            if (appDbContext == null || appDbContext.Employees == null) throw new System.Exception("Db Context error");
            var employeeInDb = await appDbContext.Employees.FindAsync(id);
            if(employeeInDb == null) throw new System.Exception($"Employee with id {id} was not find");
            appDbContext.Employees.Remove(employeeInDb);
            await appDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            if (appDbContext == null || appDbContext.Employees == null) throw new System.Exception("Db Context error");
            return await appDbContext.Employees.ToListAsync();
        }

        public async Task<Employee?> GetEmployeeByIdAsync(int id)
        {
            if (appDbContext == null || appDbContext.Employees == null) throw new System.Exception("Db Context error");
            return await appDbContext.Employees.FindAsync(id);

        }

        public async Task UpdateEmployeeAsync(Employee employee)
        {
            if (appDbContext == null || appDbContext.Employees == null) throw new System.Exception("Db Context error");
            appDbContext.Employees.Update(employee);
            await appDbContext.SaveChangesAsync();
        }
    }
}
