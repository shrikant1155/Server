using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.IServices
{
    public interface IAccountService
    {
        public Task<bool> Login(LoginViewModel loginViewModel);
        public Task<bool> Register(AdminUser adminUser);
    }
}
