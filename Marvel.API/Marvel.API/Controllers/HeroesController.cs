using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Marvel.Application.Commands.Create;
using Marvel.Application.Commands.Delete;
using Marvel.Application.Commands.Update;
using Marvel.Application.Queries.GetAllHeroes;
using Marvel.Application.Queries.GetHeroById;
using Marvel.Application.Queries.PostInitialLoad;
using Marvel.Application.ViewModels;
using Marvel.Domain.Result;

namespace Marvel.API.Controllers
{
    [Route("api/Heroes")]
    [ApiController]
    public class HeroesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public HeroesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get a paginated list of all heroes.
        /// </summary>
        /// <param name="getAllHerosQuery"></param>
        /// <returns>List of Heroes</returns>
        [Route("GetAllHeroes")]
        [HttpGet]
        [ProducesResponseType(typeof(PaginationResult<HeroViewModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll([FromQuery] GetAllHeroesQuery getAllHerosQuery)
        {
            PaginationResult<HeroViewModel> Heroes;
            try
            {
                Heroes = await _mediator.Send(getAllHerosQuery);
            }
            catch (Exception ex)
            {
                ResponseResult<GetAllHeroesQuery> response = new();
                return BadRequest(response.CreateResponse(ex, Domain.Enums.InternalCode.InternalError));
            }


            return Ok(Heroes);
        }
        /// <summary>
        /// Get a Hero by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Hero</returns>
        [Route("{id}")]
        [HttpGet]
        [ProducesResponseType(typeof(HeroViewModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetById(int id)
        {            
            var query = new GetHeroByIdQuery(id);
            try
            {
                var Hero = await _mediator.Send(query);
                if (Hero == null)
                {
                    return NotFound();
                }
                return Ok(Hero);
            }
            catch (Exception ex)
            {
                ResponseResult<GetHeroByIdQuery> response = new();
                return BadRequest(response.CreateResponse(ex, Domain.Enums.InternalCode.InternalError));
            }
        }

        /// <summary>
        /// Create a Hero
        /// </summary>
        /// <param name="command"></param>      
        [Route("Create")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> Post([FromBody] CreateHeroCommand command)
        {
            try
            {
                var id = await _mediator.Send(command);

                return CreatedAtAction(nameof(Post), new { Id = id }, command);
            }
            catch (Exception ex)
            {
                ResponseResult<CreateHeroCommand> response = new();
                return BadRequest(response.CreateResponse(ex, Domain.Enums.InternalCode.InternalError));
            }
        }
        /// <summary>
        /// Initialize Database with some pre-selected Heroes.
        /// </summary>
        /// <returns></returns>
        [Route("InitialLoad")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> InitialLoad()
        {
            try
            {
                var query = new PostInitialLoadQuery();
                await _mediator.Send(query);
            }
            catch (Exception ex)
            {
                ResponseResult<PostInitialLoadQuery> response = new();
                return BadRequest(response.CreateResponse(ex, Domain.Enums.InternalCode.InternalError));
            }
         
            return Ok();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [Route("Update")]
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> Put([FromBody] UpdateHeroCommand command)
        {
            try
            {
                await _mediator.Send(command);
            }
            catch (NullReferenceException ex)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                ResponseResult<UpdateHeroCommand> response = new();
                return BadRequest(response.CreateResponse(ex, Domain.Enums.InternalCode.InternalError));
            }


            return Ok();
        }

        /// <summary>
        /// Deletes a Hero by Id
        /// </summary>
        /// <param name="id"></param>      
        [Route("Delete")]
        [HttpDelete()]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteHeroCommand(id);
            try
            {
                await _mediator.Send(command);
            }
            catch (Exception ex)
            {
                ResponseResult<DeleteHeroCommand> response = new();
                return BadRequest(response.CreateResponse(ex, Domain.Enums.InternalCode.InternalError));
            }

            return Ok();
        }
    }
}
