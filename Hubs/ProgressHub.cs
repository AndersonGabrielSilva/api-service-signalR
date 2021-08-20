using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace ApiServiceHub.Hubs
{
    /// <summary>
    /// Um Hub tipado permite que eu tenha eu consiga acessar os Metodos por meio da interface
    /// </summary>
    public class ProgressHub : Hub<IProgressHubClientFunctions>
    {
        public async Task<int> SubscribeForNotifications(string operationId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, operationId);
            return LongRunningOperation.GetCurrentProgress(operationId);
        }

        public Task CancelProcessing(string operationId)
        {
            Clients.Group(operationId).SetMessage("Cancellation Requested...");
            LongRunningOperation.CancelProcessing(operationId);
            return Task.CompletedTask;
        }
    }

    public interface IProgressHubClientFunctions
    {
        Task SetProgress(int progress);
        Task SetMessage(string message);
    }
}

