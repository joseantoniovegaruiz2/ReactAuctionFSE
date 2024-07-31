using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;
using MediatR;
using Application.Products;
using static MediatR.IMediator;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{

[AllowAnonymous]
    public class ProductsController:BaseApiController
    {



     [HttpGet("/e-auction/api/v1/seller/show-products/")]
    public async Task<ActionResult<List<Product>>> GetProducts()
    {
        return await Mediator.Send(new List.Query());
        
    } 
    [HttpPost("/e-auction/api/v1/seller/add-product/")]
    public async Task<IActionResult> CreateProduct(Product product){
        return Ok(await Mediator.Send(new Create.Command {Product=product}));
    }




    [HttpPut("/e-auction/api/v1/seller/update-product/{id}")]
    public async Task <IActionResult> EditProduct(Guid id, Product product)
    {
        product.Id=id;
        return Ok(await Mediator.Send(new Edit.Command{Product=product}));
    }



    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(Guid id)
    {
        return Ok(await Mediator.Send(new Delete.Command{Id=id}));
    }


    }
}