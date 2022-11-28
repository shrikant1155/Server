using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.IServices;
using Server.Models;
using System;
using System.Threading.Tasks;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> Login([FromBody] LoginViewModel loginViewModel)
        {
            try
            {
                var response = await _accountService.Login(loginViewModel);
                if (response == false)
                    return NotFound(response);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error occured " + ex.ToString());
            }
        }

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult> Register([FromBody] AdminUser adminUser)
        {
            try
            {
                var response = await _accountService.Register(adminUser);
                if (response == false)
                    return BadRequest(response);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error occured " + ex.ToString());
            }
        }
    }
}
