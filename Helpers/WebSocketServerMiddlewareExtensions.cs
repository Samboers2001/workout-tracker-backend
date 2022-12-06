using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using workout_tracker_backend.Controllers;

namespace workout_tracker_backend.Helpers
{
    public static class WebSocketServerMiddlewareExtensions
    {
        public static IApplicationBuilder UseWebSocketServer(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<WebSocketServerMiddleware>();
        }

        public static IServiceCollection AddWebSocketManager(this IServiceCollection services)
        {
            services.AddSingleton<WebSocketServerConnectionManager>();
            return services;
        }
        public static IServiceCollection AddLeaderboardController(this IServiceCollection services)
        {
            services.AddSingleton<LeaderBoardController>();
            return services;
        }
    }
}