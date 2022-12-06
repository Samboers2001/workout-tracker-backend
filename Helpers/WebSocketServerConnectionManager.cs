using System;
using System.Collections.Concurrent;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;

namespace workout_tracker_backend.Helpers
{
    public class WebSocketServerConnectionManager
    {
        private ConcurrentDictionary<string, WebSocket> _sockets = new ConcurrentDictionary<string, WebSocket>();

        public ConcurrentDictionary<string, WebSocket> GetAllSockets()
        {
            return _sockets;
        }

        public string AddSocket(WebSocket socket)
        {
            string ConnId = Guid.NewGuid().ToString();

            _sockets.TryAdd(ConnId, socket);
            Console.WriteLine("Connection Added: " + ConnId);
            return ConnId;
        }

        public async Task Broadcast(object message)
        {
            var serializedMessage = JsonSerializer.Serialize<dynamic>(message);
            foreach (var socket in _sockets)
            {
                if (socket.Value.State == WebSocketState.Open)
                {
                    await socket.Value.SendAsync(Encoding.UTF8.GetBytes(serializedMessage),
                    WebSocketMessageType.Text, true, CancellationToken.None);
                }
            }
        }
    }
}