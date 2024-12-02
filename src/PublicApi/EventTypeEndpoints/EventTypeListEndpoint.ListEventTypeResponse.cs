using System;
using System.Collections.Generic;

namespace Microsoft.eShopWeb.PublicApi.EventTypeEndpoints
{
    public class ListEventTypeResponse : BaseResponse
    {
        public ListEventTypeResponse(Guid correlationId) : base(correlationId)
        {
        }

        public ListEventTypeResponse()
        {
        }

        public List<EventTypeDto> EventTypes { get; set; } = new List<EventTypeDto>();
    }
}
