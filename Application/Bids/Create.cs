using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence;
using MediatR;
using static MediatR.IMediator;
using FluentValidation;
using Application.Core;

namespace Application.Bids
{
    public class Create
    {
        public class Command: IRequest<Result<Unit>>
        {
            public Bid Bid {get;set;}
        }


        public class CommandValidator:AbstractValidator<Command>
        {
            public CommandValidator()
            {

                RuleFor(x => x.Bid).SetValidator(new BidValidator());

                
            }

        }


        public class Handler:  IRequestHandler<Command,Result<Unit>>
        {
        private readonly DataContext _context;
            public Handler (DataContext context){
                _context=context;
            }
        

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                _context.Bids.AddAsync(request.Bid);
                var result= await _context.SaveChangesAsync()>0;
                if(!result) return Result<Unit>.Failure("Failed to create Bid");
                return Result<Unit>.Success(Unit.Value);
            }
        }
  }
}