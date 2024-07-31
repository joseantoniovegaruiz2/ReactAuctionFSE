using Domain;
using MediatR;
using Persistence;
using AutoMapper;
using Application.Core;

namespace Application.Bids
{
    public class Edit
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Bid Bid {get;set;}

        }
        public class Handler: IRequestHandler<Command,Result<Unit>>
        {
            private readonly DataContext _context;
            public Handler (DataContext context,IMapper mapper)
            {
                _context =context;
            }
            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var bid= await _context.Bids.FindAsync(request.Bid.Id);
                if (bid==null) return null;
                bid.ProductId= request.Bid.ProductId ?? bid.ProductId;
                bid.BidAmount= request.Bid.BidAmount ;
                bid.SellerId= request.Bid.SellerId ?? bid.SellerId;

                var result=  await _context.SaveChangesAsync()>0;
                if (!result) return Result<Unit>.Failure("Failed to update Bid");
                return Result<Unit>.Success(Unit.Value) ;
            }
        }
    }
}