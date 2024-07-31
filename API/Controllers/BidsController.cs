using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;
using MediatR;
using Application.Bids;

using System;
using System.Threading.Tasks;
using Application.Core;
using Microsoft.AspNetCore.Authorization;




namespace API.Controllers
{
    [AllowAnonymous]
    public class BidsController : BaseApiController
    {

    [HttpPost("/e-auction/api/v1/seller/add-bid/")]
    public async Task<IActionResult> CreateBid(Bid bid){
        Response.Headers.Add("Access-Control-Allow-Origin","*");
        return HandleResult(await Mediator.Send(new Create.Command {Bid=bid}));
    }



    [HttpGet("/e-auction/api/v1/seller/show-bids/")]
    public async Task<IActionResult> GetBids()
    {
         Response.Headers.Add("Access-Control-Allow-Origin","*");
        return HandleResult(await Mediator.Send(new List.Query()));

        
    } 

    [HttpGet("/e-auction/api/v1/seller/show-bids/{id}")]
    public async Task<IActionResult> GetBid(Guid id)
        {
                     
                     
                     
            Response.Headers.Add("Access-Control-Allow-Origin","*");
            var result= await Mediator.Send(new Details.Query{Id = id});
            return HandleResult(result);

        }

    [HttpPut("/e-auction/api/v1/buyer/update-bid/{productId}/{buyerEmailId}/{bidAmount}")]
    public async Task <IActionResult> EditBidByProductIdSellerId(string productId,string buyerEmailId,double bidAmount)
        {
        Bid bid=new Bid();
        bid.ProductId=productId;
        bid.BuyerId=buyerEmailId;
        bid.BidAmount=bidAmount;
        
        Response.Headers.Add("Access-Control-Allow-Origin","*");
        return Ok(await Mediator.Send(new EditCombined.Command{Bid=bid}));     
        }

    

    [HttpPut("/e-auction/api/v1/buyer/update-bid/{id}")]
    public async Task <IActionResult> EditBid(Guid id, Bid bid)
    {
        bid.Id=id;
        Response.Headers.Add("Access-Control-Allow-Origin","*");
        return HandleResult(await Mediator.Send(new Edit.Command{Bid=bid}));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBid(Guid id)
    {
        Response.Headers.Add("Access-Control-Allow-Origin","*");
        return HandleResult(await Mediator.Send(new Delete.Command{Id=id}));
    }


    }
    
}