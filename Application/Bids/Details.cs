using Domain;
using MediatR;
using System;
using Persistence;
using AutoMapper;
using Application.Core;
using Microsoft.EntityFrameworkCore;

namespace Application.Bids
{
public class Details
    {
        public class Query: IRequest<Result<Bid>>
        {
            public Guid Id {get;set;} 
        }  
        public class Handler: IRequestHandler <Query,Result<Bid>>
        {
        private readonly DataContext _context;
            public Handler(DataContext context){
            _context = context;

            }
            public async Task<Result<Bid>> Handle(Query request, CancellationToken cancellationToken){
                    var bid= await _context.Bids.FindAsync(request.Id);
                    return Result<Bid>.Success(bid); 
            }
        }
    }
}