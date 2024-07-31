using MediatR;
using Domain;
using System.Collections.Generic;
using Persistence;
using Microsoft.EntityFrameworkCore;
using Application.Core;

namespace Application.Bids
{
    public class List
    {
        public class Query :IRequest<Result<List<Bid>>>{


        }
        public class Handler: IRequestHandler<Query,Result<List<Bid>>>
        {
        private readonly DataContext _context;
            public Handler(DataContext context){
            _context = context;

            }
            public async Task<Result<List<Bid>>> Handle(Query request, CancellationToken cancellationToken){
                return Result<List<Bid>>.Success(await _context.Bids.ToListAsync(cancellationToken));
            }
        }
    }
}