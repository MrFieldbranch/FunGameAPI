using FunGameAPI.DTOs;
using FunGameAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FunGameAPI.Controllers
{
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet("nicknamesascending")]
        public async Task<ActionResult<List<UserResponse>>> GetNicknamesAscending()
        {
            var nicknames = await _userService.GetNicknamesAscendingAsync();

            return Ok(nicknames);
        }

        [HttpGet("nicknamesdescending")]
        public async Task<ActionResult<List<UserResponse>>> GetNicknamesDescending()
        {
            var nicknames = await _userService.GetNicknamesDescendingAsync();

            return Ok(nicknames);
        }

        [HttpPost]
        public async Task <IActionResult> CreateNewGameResult(GameResultRequest request)
        {
            var myUserIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);

            if (myUserIdClaim == null || !int.TryParse(myUserIdClaim.Value, out int myUserId))            
                return Unauthorized("User ID is invalid or missing from the token.");
            
            bool result = await _userService.CreateNewGameResultAsync(myUserId, request);

            if (!result)
                return Unauthorized("User not found");            

            return Created();
        }
    }
}
