using Domain;
using FluentValidation;

namespace Application.Bids
{
    public class BidValidator:AbstractValidator<Bid>
    {
        public BidValidator()
        {
           
              RuleFor(x=>x.BidAmount).NotEmpty().WithMessage("BidAmount could not be empty");


        }
    }
}