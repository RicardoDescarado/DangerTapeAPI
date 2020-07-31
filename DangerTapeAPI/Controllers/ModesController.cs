using DangerTapeAPI.Mediators.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DangerTapeAPI.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ModesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ModesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<string>>> GetAllModes()
        {
            var result = await _mediator.Send(new GetAllModesRequest());

            return Ok(result);
        }
    }
}