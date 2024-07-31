using Domain;
using MediatR;
using Persistence;
using AutoMapper;
using Application.Core;

namespace Application.Bids
{
    public class Delete
    {
            public class Command:IRequest<Result<Unit>>
            {
                public Guid Id {get;set;}
            }


            public class Handler: IRequestHandler<Command,Result<Unit>>
            {
            private readonly DataContext _context;
                    public Handler(DataContext context)
                    {
                _context = context;

                    }

            public async Task <Result<Unit>> Handle (Command request, CancellationToken cancellationToken)
            {
                var bid= await _context.Bids.FindAsync(request.Id);
                 if (bid==null) return null;

                _context.Remove(bid);
                var result=await _context.SaveChangesAsync()>0;
                if (!result) return Result<Unit>.Failure("Failure to delete the bid");
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}