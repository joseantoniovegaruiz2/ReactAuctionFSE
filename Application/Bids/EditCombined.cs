using Domain;
using MediatR;
using Persistence;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Application.Bids
{
    public class EditCombined
    {
              public class Command : IRequest
        {
            public Bid Bid {get;set;}

        }
        public class Handler: IRequestHandler<Command>
        {
            private readonly DataContext _context;
            public Handler (DataContext context,IMapper mapper)
            {
                _context =context;
            }
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
               var bid = await _context.Bids.Where(x =>(( x.ProductId == request.Bid.ProductId)&&( x.ProductId == request.Bid.ProductId)) ).FirstOrDefaultAsync();
               bid.BidAmount= request.Bid.BidAmount ;

                 await _context.SaveChangesAsync();
                return Unit.Value;
            }
        }
    }
    
}
