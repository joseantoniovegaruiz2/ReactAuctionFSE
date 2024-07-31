using System;
using System.Collections.Generic;

using System.Collections.Generic;

namespace Application.Bids
{
    public class BidDto
    {
      
        public string Id  { get; set; }
        public double BidAmount { get; set; }

        public string? ProductId { get; set; }

        public string? SellerId { get; set; }
    }
}
