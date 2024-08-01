﻿using ApiSln.Application.Features.Products.Queries.GettAllProducts;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiSln.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProductController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GettALlProducts()
        {
            var response = await mediator.Send(new GettAllProductsQueryRequest());

            return Ok(response);
        }
    }
}