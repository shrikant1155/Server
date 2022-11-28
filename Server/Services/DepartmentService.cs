using Microsoft.EntityFrameworkCore;
using Server.IServices;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly ServerDBContext _context;
        public DepartmentService(ServerDBContext context)
        {
            _context = context;
        }

        public async Task<bool> AddDepartment(Department department)
        {
            try
            {
                var result = await _context.Department.AddAsync(department);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteDepartment(int id)
        {
            try
            {
                var user = _context.Department.SingleOrDefault(dep => dep.ID == id);
                _context.Department.Remove(user);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<Department>> GetAllDepartments()
        {
            var res = await _context.Department.ToListAsync();
            return res;
        }

        public async Task<Department> GetDepartment(int id)
        {
            return await _context.Department.FindAsync(id);
        }

        public async  Task<bool> UpdateDepartment(Department department)
        {
            try
            {
                var user = await(from s in _context.Department
                                 where s.ID == department.ID
                                 select s
                     ).FirstOrDefaultAsync();
                if (user != null)
                {
                    user.Name = department.Name;
                    user.Email = department.Email;
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
