namespace workout_tracker_backend.Dtos
{
    public class LeaderboardItem
    {
        public string Username { get; set; }
        public decimal TotalWeight { get; set; }

    }

    public class LeaderboardDto
    {
        public List<LeaderboardItem> LeaderboardList = new List<LeaderboardItem>();
    }
}