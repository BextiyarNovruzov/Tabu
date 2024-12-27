using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Tabu.DTOs.Games;
using Tabu.Exceptions;
using Tabu.Exceptions.Languages;
using Tabu.Services.Abstracts;

namespace Tabu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController(IGameServise servise) : ControllerBase
    {
        [HttpPost("[action]")]
        public async Task<IActionResult> Create(GameCreateDto dto)
        {
            try
            {
                return Ok(await servise.CreateAsync(dto));
            }
            catch (LanguageNotFoundException ex)
            {
                if(ex is IBaseException baseException)
                {
                    return StatusCode(baseException.StatusCode, new
                    {
                        ErrorMessage = baseException.ErrorMessage,
                    });
                }
                else
                {
                    return BadRequest(new
                    {
                        Message = ex.Message,
                    });
                }
            }
        }
        [HttpGet("[action]")]
        public async Task<IActionResult>Start(Guid id)
        {
            return Ok(await servise.Start(id));
        }
        
        [HttpGet("[action]")]
        public async Task<IActionResult>Skip(Guid id)
        {
            return Ok(await servise.Skip(id));
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> Success(Guid id)
        {
            return Ok(await servise.Success(id));
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> Fail(Guid id)
        {
            return Ok(await servise.Fail(id));
        }
        [HttpGet("[action]")]
        public async Task End(Guid id)
        {
            servise.End(id);
        }

    }
}
    