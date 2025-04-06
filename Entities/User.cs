using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace FunGameAPI.Entities
{
    [Index(nameof(Email), IsUnique = true)]
    [Index(nameof(Nickname), IsUnique = true)]
    public class User
    {
        public int Id { get; set; }

        [MaxLength(30)]
        public required string Nickname { get; set; }

        [MaxLength(50)]
        public required string Email { get; set; }

        [MaxLength(50)]
        public required string Password { get; set; }

        public int NumberOfGames { get; set; } = 0;

        public int NumberOfWins { get; set; } = 0;
    }
}
