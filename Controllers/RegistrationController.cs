using FunGameAPI.DTOs;
using FunGameAPI.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace FunGameAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegistrationController : ControllerBase
    {
        private readonly RegistrationService _registrationService;
        public RegistrationController(RegistrationService registrationService)
        {
            _registrationService = registrationService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewUser(CreateNewUserRequest request)
        {
            try
            {
                bool newUserResponse = await _registrationService.RegisterNewUserAsync(request);

                if (!newUserResponse)                
                    return BadRequest("There is already a user with this email and/or nickname registered.");                

                return Created();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
    
}
