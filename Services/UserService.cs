using FunGameAPI.Data;
using FunGameAPI.DTOs;
using Microsoft.EntityFrameworkCore;

namespace FunGameAPI.Services
{
    public class UserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<UserResponse>> GetNicknamesAscendingAsync()
        {
            var users = await _context.Users
                .OrderBy(u => u.Nickname)
                .Select(u => new UserResponse
                {
                    Id = u.Id,
                    Nickname = u.Nickname,
                    NumberOfGames = u.NumberOfGames,
                    NumberOfWins = u.NumberOfWins
                }).ToListAsync();

            return users ?? [];
        }

        public async Task<List<UserResponse>> GetNicknamesDescendingAsync()
        {
            var users = await _context.Users
                .OrderByDescending(u => u.Nickname)
                .Select(u => new UserResponse
                {
                    Id = u.Id,
                    Nickname = u.Nickname,
                    NumberOfGames = u.NumberOfGames,
                    NumberOfWins = u.NumberOfWins
                }).ToListAsync();

            return users ?? [];
        }

        public async Task<List<UserResponse>> GetNumberOfGamesAscendingAsync()
        {
            var users = await _context.Users
                .OrderBy(u => u.NumberOfGames)
                .Select(u => new UserResponse
                {
                    Id = u.Id,
                    Nickname = u.Nickname,
                    NumberOfGames = u.NumberOfGames,
                    NumberOfWins = u.NumberOfWins
                }).ToListAsync();

            return users ?? [];
        }

        public async Task<List<UserResponse>> GetNumberOfGamesDescendingAsync()
        {
            var users = await _context.Users
                .OrderByDescending(u => u.NumberOfGames)
                .Select(u => new UserResponse
                {
                    Id = u.Id,
                    Nickname = u.Nickname,
                    NumberOfGames = u.NumberOfGames,
                    NumberOfWins = u.NumberOfWins
                }).ToListAsync();

            return users ?? [];
        }

        public async Task<List<UserResponse>> GetNumberOfWinsAscendingAsync()
        {
            var users = await _context.Users
                .OrderBy(u => u.NumberOfWins)
                .Select(u => new UserResponse
                {
                    Id = u.Id,
                    Nickname = u.Nickname,
                    NumberOfGames = u.NumberOfGames,
                    NumberOfWins = u.NumberOfWins
                }).ToListAsync();

            return users ?? [];
        }

        public async Task<List<UserResponse>> GetNumberOfWinsDescendingAsync()
        {
            var users = await _context.Users
                .OrderByDescending(u => u.NumberOfWins)
                .Select(u => new UserResponse
                {
                    Id = u.Id,
                    Nickname = u.Nickname,
                    NumberOfGames = u.NumberOfGames,
                    NumberOfWins = u.NumberOfWins
                }).ToListAsync();

            return users ?? [];
        }

        public async Task<List<UserResponse>> GetWinPercentAscendingAsync()
        {
            var users = await _context.Users
                .OrderBy(u => u.NumberOfGames == 0 ? 0 : (double)u.NumberOfWins / u.NumberOfGames)
                .Select(u => new UserResponse
                {
                    Id = u.Id,
                    Nickname = u.Nickname,
                    NumberOfGames = u.NumberOfGames,
                    NumberOfWins = u.NumberOfWins
                }).ToListAsync();

            return users ?? [];
        }

        public async Task<List<UserResponse>> GetWinPercentDescendingAsync()
        {
            var users = await _context.Users
                .OrderByDescending(u => u.NumberOfGames == 0 ? 0 : (double)u.NumberOfWins / u.NumberOfGames)
                .Select(u => new UserResponse
                {
                    Id = u.Id,
                    Nickname = u.Nickname,
                    NumberOfGames = u.NumberOfGames,
                    NumberOfWins = u.NumberOfWins
                }).ToListAsync();

            return users ?? [];
        }

        public async Task<bool> CreateNewGameResultAsync(int myUserId, GameResultRequest request)
        {
            var myUser = await _context.Users.FindAsync(myUserId);

            if (myUser == null)
                return false;

            myUser.NumberOfGames++;

            if (request.IsWinner)
                myUser.NumberOfWins++;

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
