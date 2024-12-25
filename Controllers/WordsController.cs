using Microsoft.AspNetCore.Mvc;
using Tabu.DTOs.Words;
using Tabu.Exceptions;
using Tabu.Exceptions.Languages;
using Tabu.Exceptions.Words;
using Tabu.Services.Abstracts;

namespace Tabu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordsController(IWordsServise servise) : ControllerBase
    {
        [HttpPost("Create")]
        public async Task<IActionResult> Create(WordCreateDto dto)
        {
            try
            {
                await servise.CreateAsync(dto);
                return Ok();
            }
            catch (WordExistException ex)
            {
                if (ex is IBaseException baseException)
                {
                    return StatusCode(baseException.StatusCode, new
                    {
                        Message = baseException.ErrorMessage,
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
            catch (LanguageNotFoundException ex)
            {
                if (ex is IBaseException baseExc)
                {
                    return StatusCode(baseExc.StatusCode, new
                    {
                        Message = baseExc.ErrorMessage,
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
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateMany(List<WordCreateDto> dto)
        {
            try
            {
                foreach (var item in dto)
                {
                    await servise.CreateAsync(item);
                }
                return Ok();
            }
            catch (WordExistException ex)
            {
                if (ex is IBaseException baseException)
                {
                    return StatusCode(baseException.StatusCode, new
                    {
                        Message = baseException.ErrorMessage,
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
            catch (LanguageNotFoundException ex)
            {
                if (ex is IBaseException baseExc)
                {
                    return StatusCode(baseExc.StatusCode, new
                    {
                        Message = baseExc.ErrorMessage,
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

        [HttpGet("Read")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var datas = await servise.GetAllAsync();
                return Ok(datas);
            }
            catch (WordNotFoundException ex)
            {
                if (ex is IBaseException baseException)
                {
                    return StatusCode(baseException.StatusCode, new
                    {
                        Message = baseException.ErrorMessage,
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
        [HttpPut("Update")]
        public async Task<IActionResult> Update(WordUpdateDto dto, int id)
        {
            try
            {
                await servise.UpdateAsync(dto, id);
                return Ok();
            }
            catch (WordNotFoundException ex)
            {

                if (ex is IBaseException baseException)
                {
                    return StatusCode(baseException.StatusCode, new
                    {
                        Message = baseException.ErrorMessage,
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
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await servise.DeleteAsync(id);
                return Ok();
            }
            catch (WordNotFoundException ex)
            {
                if (ex is IBaseException baseException)
                {
                    return StatusCode(baseException.StatusCode, new
                    {
                        Message = baseException.ErrorMessage,
                    });
                }
                else
                {
                    return BadRequest(new
                    {
                        StatusCode = ex.StatusCode,
                        Message = ex.Message,
                    });
                }
            }
        }
    }
}
