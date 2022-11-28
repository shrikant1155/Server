using Microsoft.EntityFrameworkCore;
using Server.IServices;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Services
{
    public class AccountService : IAccountService
    {
        private readonly ServerDBContext _context;
        public AccountService(ServerDBContext context)
        {
            _context = context;
        }
        public async Task<bool> Login(LoginViewModel loginViewModel)
        {
            
            var userdetails = await _context.AdminUser
                .SingleOrDefaultAsync(m => m.Email == loginViewModel.Email && m.Password == loginViewModel.Password);
            if (userdetails != null)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> Register(AdminUser adminUser)
        {
            try
            {
                var result = await _context.AdminUser.AddAsync(adminUser);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
