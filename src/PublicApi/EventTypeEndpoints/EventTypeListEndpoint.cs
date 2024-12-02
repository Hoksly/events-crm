using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.eShopWeb.ApplicationCore.Entities;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using MinimalApi.Endpoint;

namespace Microsoft.eShopWeb.PublicApi.EventTypeEndpoints
{
    public class EventTypeListEndpoint:  IEndpoint<IResult, IRepository<EventType>>
    {
        private readonly IMapper _mapper;

        public EventTypeListEndpoint(IMapper mapper)
        {
            _mapper = mapper;
        }

        public void AddRoute(IEndpointRouteBuilder app)
        {
            app.MapGet("api/event-types",
                    async (IRepository<EventType> eventTypeRepository) =>
                    {
                        return await HandleAsync(eventTypeRepository);
                    })
                .Produces<ListEventTypeResponse>()
                .WithTags("EventTypeEndpoints");
        }

        public async Task<IResult> HandleAsync(IRepository<EventType> eventTypeRepository)
        {
            var response = new ListEventTypeResponse();

            var items = await eventTypeRepository.ListAsync();

            foreach (var item in items)
            {
                Console.WriteLine(item.Name + " " + item.Id);
            }

            var dtos = items.Select(_mapper.Map<EventTypeDto>);

            foreach (var item in dtos)
            {
                Console.WriteLine(item.Name + " " + item.Id + "dto");
            }

            response.EventTypes.AddRange(dtos);

            return Results.Ok(response);
        }
    }
}
