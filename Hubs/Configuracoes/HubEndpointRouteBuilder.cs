using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using ApiServiceHub.SignalR;
using Microsoft.Azure.SignalR;

namespace ApiServiceHub.Hubs.Configuracoes
{
    public static class HubEndpointRouteBuilder
    {
        public static void MapHubRoute(this IEndpointRouteBuilder endpoints)
        {            
            endpoints.MapHub<ExampleHub>(SignalRName.RouteExampleHub);
        }


        #region Configuração para quando for utilizar o azure SignalR
        public static void MapHubRouteAzure(this ServiceRouteBuilder endpoints)
        {
            endpoints.MapHub<ExampleHub>(SignalRName.RouteExampleHub);
        }
        #endregion
    }
}
