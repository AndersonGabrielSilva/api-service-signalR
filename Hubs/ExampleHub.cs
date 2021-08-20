using ApiServiceHub.SignalR;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace ApiServiceHub.Hubs
{
    public class ExampleHub : BaseHub
    {
        #region Gerenciador de grupos
        public override Task JoinGroup(string groupName)
        {
            return Groups.AddToGroupAsync(Context.ConnectionId, (groupName + SignalRName.ExemploHub));
        }

        public override Task LeaveGroup(string groupName)
        {
            return Groups.RemoveFromGroupAsync(Context.ConnectionId, (groupName + SignalRName.ExemploHub));
        }
        #endregion

        #region Mensagens
        //Este método pode ser invocado pelo Client via SignalR 
        public override async Task SendMessageGroup(string groupName, string message)
        {
            //Notifica todos os Hubs conectados
            await Clients.All.SendAsync(groupName + SignalRName.ExemploHub, message);
        }
        #endregion
    }
}
