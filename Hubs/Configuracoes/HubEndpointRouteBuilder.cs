using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using ApiServiceHub.SignalR;

namespace ApiServiceHub.Hubs.Configuracoes
{
    public static class HubEndpointRouteBuilder
    {
        public static void MapHubRoute(this IEndpointRouteBuilder endpoints)
        {            
            endpoints.MapHub<ExampleHub>(SignalRName.RouteExemploHub);
        }
    }
}
