using Domain;
using MediatR;
using Persistence;
using AutoMapper;
using FluentValidation;

namespace Application.Products
{
    public class Edit
    {
        public class Command : IRequest
        {
            public Product Product {get;set;}

        }


        public class CommandValidator:AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x=>x.Product.ProductName)
                .NotEmpty()
                .WithMessage("ProductName Should Not be Empty")
                .DependentRules(() =>
                {
                    RuleFor(x => x.Product).SetValidator(new ProductValidator());
                });
                
            }

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
                var product= await _context.Products.FindAsync(request.Product.Id);
                product.ProductName= request.Product.ProductName;
                product.ShortDescription= request.Product.ShortDescription ;
                product.DetailedDescription= request.Product.DetailedDescription;
                product.Category= request.Product.Category;
                product.StartingPrice=request.Product.StartingPrice;
                product.BidEnDate=request.Product.BidEnDate;
                 await _context.SaveChangesAsync();
                return Unit.Value;
            }
        }
    }
}