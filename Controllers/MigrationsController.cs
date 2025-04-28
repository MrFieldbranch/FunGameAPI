using Microsoft.AspNetCore.Mvc;
using FunGameAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace FunGameAPI.Controllers
{
    [ApiController]
    [Route("migrations")]
    public class MigrationsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MigrationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> ApplyMigrations()
        {
            await _context.Database.MigrateAsync();
            return Ok("Migrations applied successfully!");
        }
    }
}

