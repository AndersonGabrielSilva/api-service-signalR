using ApiServiceHub.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using ApiServiceHub.SignalR;

namespace ApiServiceHub.Controllers
{
    public class ExempleHubController : BaseHubController
    {
        #region Atributos Auxiliares
        private readonly IHubContext<ExampleHub> hubContext;
        #endregion

        #region Construtor
        public ExempleHubController(IHubContext<ExampleHub> hubContext)
        {
            this.hubContext = hubContext;
        }
        #endregion

        #region Metodos
        /* hub/DashBoardCra?group=sermagri&safra=2021-22  */
        [HttpGet]
        public async Task<IActionResult> Get(string group, string mensagem)
        {
            //Notifica todos os hubs conectados
            await hubContext.Clients.All.SendAsync(group + SignalRName.ExampleHub, mensagem);

            return Ok();
        }
        #endregion
    }
}
