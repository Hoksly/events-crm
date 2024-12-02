using System;
using System.Collections.Generic;
using Microsoft.eShopWeb.ApplicationCore.Entities;
using Microsoft.eShopWeb.PublicApi.EventLocationEndpoints;

namespace Microsoft.eShopWeb.PublicApi.EventLocationEndpoints 
{
    public class ListEventLocationsResponse: BaseResponse
    {
        public ListEventLocationsResponse(Guid correlationId) : base(correlationId)
        {
        }

        public ListEventLocationsResponse()
        {
        }

        public List<EventLocationDto> CatalogTypes { get; set; } = new List<EventLocationDto>();
    }
}
