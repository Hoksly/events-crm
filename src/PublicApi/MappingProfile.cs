using AutoMapper;
using Microsoft.eShopWeb.ApplicationCore.Entities;
using Microsoft.eShopWeb.Infrastructure.Data.Queries;
using Microsoft.eShopWeb.PublicApi.CatalogBrandEndpoints;
using Microsoft.eShopWeb.PublicApi.CatalogItemEndpoints;
using Microsoft.eShopWeb.PublicApi.CatalogTypeEndpoints;
using Microsoft.eShopWeb.PublicApi.EventEndpoints;
using Microsoft.eShopWeb.PublicApi.EventLocationEndpoints;
using Microsoft.eShopWeb.PublicApi.EventTypeEndpoints;

namespace Microsoft.eShopWeb.PublicApi;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CatalogItem, CatalogItemDto>();
        CreateMap<CatalogType, CatalogTypeDto>()
            .ForMember(dto => dto.Name, options => options.MapFrom(src => src.Type));
        CreateMap<CatalogBrand, CatalogBrandDto>()
            .ForMember(dto => dto.Name, 
                options => 
                    options.MapFrom(src => src.Brand));
        CreateMap<EventType, EventTypeDto>().ForMember(dto => dto.Name, options => 
            options.MapFrom(src => src.Name)).ForMember(dto => dto.Id, options => 
            options.MapFrom(src => src.Id));
        CreateMap<Event, EventDto>();
        CreateMap<EventLocation, EventLocationDto>();
    }
}
