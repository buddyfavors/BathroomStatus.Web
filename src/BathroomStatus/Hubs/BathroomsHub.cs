using BathroomStatus.Models;
using Microsoft.AspNetCore.SignalR;

namespace BathroomStatus.Hubs
{
    public class BathroomsHub : Hub
    {
        public void Update(Bathroom bathroom)
        {
            Clients.All.Update(bathroom);
        }
    }
}
