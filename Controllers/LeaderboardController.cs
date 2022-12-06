using Microsoft.AspNetCore.Mvc;
using workout_tracker_backend.Dtos;
using workout_tracker_backend.Helpers;

namespace workout_tracker_backend.Controllers
{
    public class LeaderBoardController
    {
        public WebSocketServerConnectionManager _manager;
        public LeaderBoardController(WebSocketServerConnectionManager manager)

        {
            _manager = manager;
        }
        public async void UpdateLeaderboardWihUserData()
        {
            Random random = new Random();
            LeaderboardItem leaderboardItem = new LeaderboardItem
            {
                Username = "Sam",
                TotalWeight = random.Next(1,1000)
            };

            LeaderboardDto leaderboardDto = new LeaderboardDto();
            leaderboardDto.LeaderboardList.Add(leaderboardItem);
            _manager.Broadcast(leaderboardDto.LeaderboardList);
        }
    }
}