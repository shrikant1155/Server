using Server.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Server.IServices
{
    public interface IEmployeeService
    {
        public Task<List<Employee>> GetAllEmployees();
        public Task<Employee> GetEmployee(int id);
        public Task<bool> AddEmployee(Employee employee);
        public Task<bool> UpdateEmployee(Employee employee);
        public Task<bool> DeleteEmployee(int id);
    }
}
