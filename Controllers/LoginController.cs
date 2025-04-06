using FunGameAPI.DTOs;
using FunGameAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace FunGameAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly LoginService _loginService;
        public LoginController(LoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var tokenResponse = await _loginService.AuthenticateAsync(request);

            if (tokenResponse == null)            
                return Unauthorized("Incorrect login credentials");
            
            return Ok(tokenResponse);
        }
    }
} 