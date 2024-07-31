using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence;
using MediatR;
using Application.Products;
using static MediatR.IMediator;
using FluentValidation;
using Microsoft.Extensions.Localization;
namespace Application.Products
{
    public class Create
    {
        public class Command: IRequest
        {
            public Product Product {get;set;}
        }


        public class CommandValidator:AbstractValidator<Command>
        {
            public CommandValidator()
            {
                            RuleFor(x => x.Product).SetValidator(new ProductValidator());

                
            }

        }


        public class Handler:  IRequestHandler<Command>
        {
        private readonly DataContext _context;
            public Handler (DataContext context){
                _context=context;
            }
        

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                _context.Products.AddAsync(request.Product);
                await _context.SaveChangesAsync();
                return Unit.Value;
            }
        }
  }
}