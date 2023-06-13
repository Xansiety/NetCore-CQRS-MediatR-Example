﻿using CQRSMediatRExample.MediatR.Queries;
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

        public ProductsController(ISender sender) => _sender = sender;

        [HttpGet]
        public async Task<ActionResult> GetProducts()
        {
            var products = await _sender.Send(new GetProductQuery());
            return Ok(products);
        }
    }
}
