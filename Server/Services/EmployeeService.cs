using Microsoft.EntityFrameworkCore;
using Server.IServices;
using Server.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Server.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ServerDBContext _context;
        public EmployeeService(ServerDBContext context)
        {
            _context = context;
        }

        public async Task<bool> AddEmployee(Employee employee)
        {
            try
            {
                var result = await _context.Employee.AddAsync(employee);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteEmployee(int id)
        {
            try
            {
                var user = _context.Employee.SingleOrDefault(emp => emp.ID == id);
                _context.Employee.Remove(user);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            var res = await _context.Employee.ToListAsync();
            return res;
        }

        public async Task<Employee> GetEmployee(int id)
        {
            return await _context.Employee.FindAsync(id);
        }

        public async Task<bool> UpdateEmployee(Employee employee)
        {
            try
            {
                var user = await (from s in _context.Employee
                                  where s.ID == employee.ID
                                  join cd in _context.Department on s.DepartmentID equals cd.ID
                                  select s
                     ).FirstOrDefaultAsync();
                if (user != null)
                {
                    user.Name = employee.Name;
                    user.Email = employee.Email;
                    user.DepartmentID = employee.DepartmentID;
                    await _context.SaveChangesAsync();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
