using System;

using System.Linq;
using Application.Bids;
using Domain;

namespace Application.Core
{
    public class MappingProfiles: AutoMapper.Profile
    {
          public MappingProfiles()
        {
            CreateMap<Bid, Bid>();
            CreateMap<Bid,BidDto>();
            
        }
    }
}
