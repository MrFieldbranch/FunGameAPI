namespace FunGameAPI.DTOs
{
    public class UserResponse
    {
        public int Id { get; set; }
        public required string Nickname { get; set; }        
        public int NumberOfGames { get; set; } 
        public int NumberOfWins { get; set; }

        public double WinPercent
        {
            get
            {
                if (NumberOfGames == 0)
                    return 0;
                
                return ((double)NumberOfWins / NumberOfGames) * 100;
            }
        }
    }
}
