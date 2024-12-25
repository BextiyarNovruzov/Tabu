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
    public class GamesController(IGameServise servise,IMemoryCache chache) : ControllerBase
    {
        [HttpPost("[action]")]
        public async Task<IActionResult> Create(GameCreateDto dto)
        {
            try
            {
                var NewGame = await servise.CreateAsync(dto);
                return Ok(NewGame);
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
        public async Task<IActionResult> Get(string key)
        {
            var getingdata = chache.Get(key);
            return Ok(getingdata);
        }
        //[HttpGet("[action]")]
        //public async Task<IActionResult> Start(string key , string value)
        //{
        //    var setingdata = chache.Set<string>(key, value, DateTime.Now.AddSeconds(30));
        //    return Ok(setingdata);
        //}

        [HttpGet("[action]")]
        public Task<IActionResult>Set()
        {
        }

    }
}
