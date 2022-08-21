using Microsoft.AspNetCore.SignalR;

namespace SignalRDemo.Hubs
{
    public class ViewerHub : Hub
    {
        private static int ViewerCount { get; set; } = 0;

        public async override Task<Task> OnConnectedAsync()
        {
            await Clients.All.SendAsync("updateViewerCount", ++ViewerCount);
            return base.OnConnectedAsync();
        }

        public async override Task<Task> OnDisconnectedAsync(Exception? exception)
        {
            await Clients.All.SendAsync("updateViewerCount", --ViewerCount);
            return base.OnDisconnectedAsync(exception);
        }
    }
}
