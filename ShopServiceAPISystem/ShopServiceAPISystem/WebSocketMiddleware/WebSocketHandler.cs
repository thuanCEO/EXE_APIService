using BusinessObjects.Models;
using Newtonsoft.Json;
using System.Collections.Concurrent;
using System.Net.WebSockets;
using System.Text;

namespace ShopServiceAPISystem.WebSocketMiddleware
{
    public static class WebSocketHandler
    {
        private static readonly ConcurrentDictionary<string, WebSocket> _sockets = new ConcurrentDictionary<string, WebSocket>();
        private static bs6ow0djyzdo8teyhoz4Context _context;


        public static async Task HandleWebSocket(HttpContext context)
        {
            if (context.WebSockets.IsWebSocketRequest)
            {
                var webSocket = await context.WebSockets.AcceptWebSocketAsync();
                var socketId = Guid.NewGuid().ToString();
                _sockets.TryAdd(socketId, webSocket);

                await ReceiveMessagesAsync(webSocket, socketId);
            }
            else
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
            }
        }

        private static async Task ReceiveMessagesAsync(WebSocket webSocket, string socketId)
        {
            var buffer = new byte[1024 * 4];
            WebSocketReceiveResult result;

            do
            {
                result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                if (result.MessageType == WebSocketMessageType.Text)
                {
                    var message = Encoding.UTF8.GetString(buffer, 0, result.Count);
                    await HandleMessage(message, webSocket);
                }
            } while (!result.CloseStatus.HasValue);

            _sockets.TryRemove(socketId, out _);
            await webSocket.CloseAsync(result.CloseStatus.Value, result.CloseStatusDescription, CancellationToken.None);
        }

        private static async Task HandleMessage(string message, WebSocket senderSocket)
        {
            var chatMessage = JsonConvert.DeserializeObject<ChatMessage>(message);
            _context = new bs6ow0djyzdo8teyhoz4Context();
            // Save message to database
            if (_context != null)
            {
                chatMessage.Timestamp = DateTime.Now;
                _context.ChatMessages.Add(chatMessage);
                await _context.SaveChangesAsync();
            }

            // Send message to receiver
            var receiverSocket = _sockets.FirstOrDefault(x => x.Key == chatMessage.ReceiverId.ToString()).Value;
            if (receiverSocket != null)
            {
                var messageBytes = Encoding.UTF8.GetBytes(message);
                await receiverSocket.SendAsync(new ArraySegment<byte>(messageBytes), WebSocketMessageType.Text, true, CancellationToken.None);
            }
        }
    }
}
