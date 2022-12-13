using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Marvel.Application.Commands.Battle;
using Marvel.Domain.Battle;
using Marvel.Domain.Result;

namespace Marvel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BattleController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BattleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Starts a Battle between Heroes
        /// </summary>
        /// <param name="command"></param>
        /// <returns>All logs of that battle.</returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> Post([FromBody] BattleCommand command)
        {
            ResponseResult<List<Turn>> response = new();
            try
            {
                response = await _mediator.Send(command);
                if (response.InternalCode == Domain.Enums.InternalCode.HeroSameSide)
                {
                    return BadRequest(response.Message);
                }

                return Ok(response.Data);
            }
            catch (Exception ex)
            {             
                return BadRequest(response.CreateResponse(ex, Domain.Enums.InternalCode.InternalError)); 
            }
        }
    }
}
