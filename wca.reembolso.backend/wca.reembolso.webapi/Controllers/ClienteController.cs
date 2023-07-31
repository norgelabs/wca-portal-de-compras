﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using wca.reembolso.application.Features.Clientes.Commands;
using wca.reembolso.application.Features.Clientes.Queries;

namespace wca.reembolso.webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ApiController
    {
        private readonly IMediator _mediator;

        public ClienteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetById([FromQuery] ClienteByIdQuerie command) 
        {
            var result = await _mediator.Send(command);
        
            if (result.IsError) { return Problem(result.Errors); }

            return Ok(result.Value);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ClienteCreateCommand cliente)
        {
            var result = await _mediator.Send(cliente);

            if (result.IsError) { return Problem(result.Errors); }

            return Ok(result);
        }

        [HttpGet("ToPaginate")]
        public async Task<IActionResult> ToPaginate([FromQuery] ClientePaginateQuery querie)
        {
            var result = await _mediator.Send(querie);

            if (result.IsError) { return Problem(result.Errors); }

            return Ok(result.Value);
        }
    }
}
