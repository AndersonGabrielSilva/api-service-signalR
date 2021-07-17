using Microsoft.AspNetCore.SignalR;
using ApiServiceHub.SignalR;
using System;
using System.Threading.Tasks;

namespace ApiServiceHub.Hubs
{
    public class BaseHub : Hub
    {
        #region Construtor
        public BaseHub()
        {

        }
        #endregion

        #region Ciclo de Vida
        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception? exceptiond)
        {
            return base.OnDisconnectedAsync(exceptiond);
        }
        #endregion

        #region Gereenciador de grupos
        public virtual Task JoinGroup(string groupName)
        {
            throw new NotImplementedException("Metódo não implementado");
        }

        public virtual Task LeaveGroup(string groupName)
        {
            throw new NotImplementedException("Metódo não implementado");
        }
        #endregion

        #region Mensagens
        public virtual async Task SendMessageGroup(string groupName, string message)
        {
            throw new NotImplementedException("Metódo não implementado");
        }
        #endregion
    }
}
