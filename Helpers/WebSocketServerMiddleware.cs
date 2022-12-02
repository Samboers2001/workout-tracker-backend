using System;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;


namespace workout_tracker_backend.Helpers
{
    public class WebSocketServerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly WebSocketServerConnectionManager _manager;

        public WebSocketServerMiddleware(RequestDelegate next, WebSocketServerConnectionManager manager)
        {
            _next = next;
            _manager = manager;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.WebSockets.IsWebSocketRequest)
            {
                WebSocket webSocket = await context.WebSockets.AcceptWebSocketAsync();
                Console.WriteLine("Websocket Connected");

                string ConnId = _manager.AddSocket(webSocket);
                await SendConnIdAsync(webSocket, ConnId);

                await ReceiveMessage(webSocket, async (result, buffer) =>
                {
                    if (result.MessageType == WebSocketMessageType.Text)
                    {
                        Console.WriteLine("Message Reveived");
                        Console.WriteLine($"Message: {Encoding.UTF8.GetString(buffer, 0, result.Count)}");
                        await RouteJSONMessageAsync(Encoding.UTF8.GetString(buffer, 0, result.Count));
                        return;
                    }
                    else if (result.MessageType == WebSocketMessageType.Close)
                    {
                        string Id = _manager.GetAllSockets().FirstOrDefault(s => s.Value == webSocket).Key;
                        System.Console.WriteLine("Received Close Message");
                        _manager.GetAllSockets().TryRemove(Id, out WebSocket sock);

                        await sock.CloseAsync(result.CloseStatus.Value, result.CloseStatusDescription, CancellationToken.None);
                        return;
                    }
                });
            }
            else
            {
                await _next(context);
            }
        }

        private async Task SendConnIdAsync(WebSocket socket, string connId)
        {
            var buffer = Encoding.UTF8.GetBytes("ConnId: " + connId);
            await socket.SendAsync(buffer, WebSocketMessageType.Text, true, CancellationToken.None);
        }

        private async Task ReceiveMessage(WebSocket socket, Action<WebSocketReceiveResult, byte[]> handleMessage)
        {
            var buffer = new byte[1024 * 4];

            while (socket.State == WebSocketState.Open)
            {
                var result = await socket.ReceiveAsync(buffer: new ArraySegment<byte>(buffer), cancellationToken: CancellationToken.None);

                handleMessage(result, buffer);
            }
        }

        public async Task RouteJSONMessageAsync(string message)
        {
            var routeOb = JsonSerializer.Deserialize<dynamic>(message);

            if (Guid.TryParse(routeOb.To.ToString(), out Guid guidOutput))
            {
                System.Console.WriteLine("Targeted");
                var socket = _manager.GetAllSockets().FirstOrDefault(s => s.Key == routeOb.To.ToString());

                if (socket.Value != null)
                {
                    if (socket.Value.State == WebSocketState.Open)
                    {
                        await socket.Value.SendAsync(Encoding.UTF8.GetBytes(routeOb.Message.ToString()),
                        WebSocketMessageType.Text, true, CancellationToken.None);
                    }

                }
                else
                {
                    System.Console.WriteLine("Invalid Recipient");
                }
            }
            else
            {
                System.Console.WriteLine("Broadcast");
                foreach (var socket in _manager.GetAllSockets())
                {
                    if (socket.Value.State == WebSocketState.Open)
                    {
                        await socket.Value.SendAsync(Encoding.UTF8.GetBytes(routeOb.Message.ToString()),
                        WebSocketMessageType.Text, true, CancellationToken.None);
                    }
                }
            }
        }
    }
}