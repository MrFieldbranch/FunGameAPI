using FunGameAPI.DTOs;
using FunGameAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FunGameAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
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
            var users = await _userService.GetNicknamesAscendingAsync();

            return Ok(users);
        }

        [HttpGet("nicknamesdescending")]
        public async Task<ActionResult<List<UserResponse>>> GetNicknamesDescending()
        {
            var users = await _userService.GetNicknamesDescendingAsync();

            return Ok(users);
        }

        [HttpGet("numberofgamesascending")]
        public async Task<ActionResult<List<UserResponse>>> GetNumberOfGamesAscending()
        {
            var users = await _userService.GetNumberOfGamesAscendingAsync();

            return Ok(users);
        }

        [HttpGet("numberofgamesdescending")]
        public async Task<ActionResult<List<UserResponse>>> GetNumberOfGamesDescending()
        {
            var users = await _userService.GetNumberOfGamesDescendingAsync();

            return Ok(users);
        }

        [HttpGet("numberofwinsascending")]
        public async Task<ActionResult<List<UserResponse>>> GetNumberOfWinsAscending()
        {
            var users = await _userService.GetNumberOfWinsAscendingAsync();

            return Ok(users);
        }

        [HttpGet("numberofwinsdescending")]
        public async Task<ActionResult<List<UserResponse>>> GetNumberOfWinsDescending()
        {
            var users = await _userService.GetNumberOfWinsDescendingAsync();

            return Ok(users);
        }

        [HttpGet("winpercentascending")]
        public async Task<ActionResult<List<UserResponse>>> GetWinPercentAscending()
        {
            var users = await _userService.GetWinPercentAscendingAsync();

            return Ok(users);
        }

        [HttpGet("winpercentdescending")]
        public async Task<ActionResult<List<UserResponse>>> GetWinPercentDescending()
        {
            var users = await _userService.GetWinPercentDescendingAsync();

            return Ok(users);
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
