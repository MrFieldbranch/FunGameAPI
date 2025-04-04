using Microsoft.EntityFrameworkCore;

namespace FunGameAPI.Entities
{
    [Index(nameof(Email), IsUnique = true)]
    [Index(nameof(Nickname), IsUnique = true)]
    public class User
    {
        public int Id { get; set; }

        public required string Nickname { get; set; }

        public required string Email { get; set; }

        public required string Password { get; set; }

        public int NumberOfGames { get; set; } = 0;

        public int NumberOfWins { get; set; } = 0;
    }
}
