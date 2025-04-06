using FunGameAPI.Data;
using FunGameAPI.DTOs;
using FunGameAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace FunGameAPI.Services
{
    public class RegistrationService
    {
        private readonly ApplicationDbContext _context;

        public RegistrationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> RegisterNewUserAsync(CreateNewUserRequest request)
        {
            // Check if the user already exists
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == request.Email || u.Nickname == request.Nickname);
            if (existingUser != null)            
                return false; // User already exists            

            try
            {
                var newUser = new User
                {
                    Nickname = request.Nickname,
                    Email = request.Email,
                    Password = request.Password
                };

                _context.Users.Add(newUser);

                await _context.SaveChangesAsync();

                return true; // User created successfully
            }
            catch
            {
                throw new ArgumentException("Nickname can be max 30 characters, Email max 50 characters, and Password max 50 characters.");
            }
        }
    }
}
