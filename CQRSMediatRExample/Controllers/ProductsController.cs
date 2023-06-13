using CQRSMediatRExample.Entities;
using CQRSMediatRExample.MediatR.Commands;
using CQRSMediatRExample.MediatR.Notifications;
using CQRSMediatRExample.MediatR.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRSMediatRExample.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        //private readonly IMediator _mediator;
        private readonly ISender _sender;
        private readonly IPublisher _publisher;

        public ProductsController(ISender sender, IPublisher publisher)
        {
            _sender = sender;
            _publisher = publisher;
        }

        [HttpGet]
        public async Task<ActionResult> GetProducts()
        {
            var products = await _sender.Send(new GetProductQuery());
            return Ok(products);
        }

        [HttpPost]
        public async Task<ActionResult> AddProduct([FromBody] Product product)
        {
            var productToReturn = await _sender.Send(new AddProductCommand(product));
            //return StatusCode(201);
            await _publisher.Publish(new ProductAddedNotificacion(productToReturn));

            return CreatedAtRoute("GetProductById", new { id = productToReturn.Id }, productToReturn);
        }

        [HttpGet("{id:int}", Name = "GetProductById")]
        public async Task<ActionResult> GetProductById(int Id)
        {
            var product = await _sender.Send(new GetProductByIdQuery(Id));
            return Ok(product);
        }
    }
}
