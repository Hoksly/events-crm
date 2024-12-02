using System.Collections.Generic;
using Microsoft.eShopWeb.ApplicationCore.Entities;
using Microsoft.eShopWeb.PublicApi.EventTypeEndpoints;

namespace Microsoft.eShopWeb.PublicApi.EventEndpoints
{
    public class EventDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUri { get; set; }
        public List<EventTypeDto> EventTypes { get; set; }
        public int CatalogBrandId { get; set; }
    }
}
