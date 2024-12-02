using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.eShopWeb.ApplicationCore.Entities;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using Microsoft.eShopWeb.PublicApi.CatalogTypeEndpoints;
using MinimalApi.Endpoint;

namespace Microsoft.eShopWeb.PublicApi.EventLocationEndpoints
{
    public class EventLocationListEndpoint : IEndpoint<IResult, IRepository<EventLocation>>
    {
        private readonly IMapper _mapper;

        public EventLocationListEndpoint(IMapper mapper)
        {
            _mapper = mapper;
        }

        public void AddRoute(IEndpointRouteBuilder app)
        {
            app.MapGet("api/event-locations",
                    async (IRepository<EventLocation> eventLocationRepository) =>
                    {
                        return await HandleAsync(eventLocationRepository);
                    })
                .Produces<ListEventLocationsResponse>()
                .WithTags("EventLocationEndpoints");
        }

        public async Task<IResult> HandleAsync(IRepository<EventLocation> eventLocationRepository)
        {
            var response = new ListEventLocationsResponse();

            var items = await eventLocationRepository.ListAsync();

            response.CatalogTypes.AddRange(items.Select(_mapper.Map<EventLocationDto>));

            return Results.Ok(response);
        }
    }
}
