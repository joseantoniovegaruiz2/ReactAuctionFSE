using Domain;
using MediatR;
using System;
using Persistence;
using Application.Core;

namespace Application.Products
{
    public class Details
    {
        public class Query: IRequest<Result<Product>>
        {
            public Guid Id {get;set;} 
        }  
        public class Handler: IRequestHandler <Query,Result<Product>>
        {
        private readonly DataContext _context;
            public Handler(DataContext context){
            _context = context;

            }
            public async Task<Result<Product>> Handle(Query request, CancellationToken cancellationToken){
                     var product=await _context.Products.FindAsync(request.Id);
                     return Result<Product>.Success(product); 
            }
        }
    }
}