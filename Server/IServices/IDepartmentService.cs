using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.IServices
{
    public interface IDepartmentService
    {
        public Task<List<Department>> GetAllDepartments();
        public Task<Department> GetDepartment(int id);
        public Task<bool> AddDepartment(Department department);
        public Task<bool> UpdateDepartment(Department department);
        public Task<bool> DeleteDepartment(int id);
    }
}
