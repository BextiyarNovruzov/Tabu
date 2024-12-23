using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tabu.DTOs.Languages;
using Tabu.Entites;
using Tabu.Exceptions;
using Tabu.Exceptions.Language;
using Tabu.Exceptions.Languages;
using Tabu.Services.Implements;

namespace Tabu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguagesController(ILanguagesServise servise) : ControllerBase
    {

        [HttpPost("Create")]
        public async Task<IActionResult> Create(LanguageCreateDto dto)
        {
            try
            {
                await servise.CreateAsync(dto);
                return Ok();
            }
            catch (LanguageExistException ex)
            {
                if (ex is IBaseException baseException)
                {
                    return StatusCode(baseException.StatusCode, new
                    {
                        Message = baseException.ErrorMessage,
                        StatusCode = baseException.StatusCode,
                    });
                }
                else
                {
                    return BadRequest(new
                    {
                        StatusCode = ex.StatusCode,
                        Message = ex.ErrorMessage,
                    });
                }
            }

        }
        [HttpGet("Read")]
        public async Task<IActionResult> Read()
        {
            try
            {
                return Ok(await servise.GetAllAsync());
            }
            catch (LanguageNotFoundException ex)
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
                        Message = ex.Message
                    });
                }
            }

        }
        

        [HttpPut("Update")]
        public async Task<IActionResult> Update(LanguageUpdateDto dto, string Code)
        {
            try
            {
                await servise.UpdateAsync(dto, Code);
                return Ok();
            }
            catch (LanguageNotFoundException ex)
            {
                if (ex is IBaseException baseException)
                {
                    return StatusCode(baseException.StatusCode, new
                    {
                        Message = baseException.ErrorMessage
                    });
                }
                else
                {
                    return BadRequest(new
                    {
                        Message = ex.Message
                    });
                }
            }
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(string Code)
        {
            try
            {
                await servise.DeleteAsync(Code);
                return Ok();
            }

            catch (LanguageNotFoundException ex)
            {
                if (ex is IBaseException baseExcepton)
                {
                    return StatusCode(baseExcepton.StatusCode, new
                    {
                        Message = baseExcepton.ErrorMessage
                    });
                }
                else
                {
                    return BadRequest(new
                    {
                        Message = ex.Message
                    });
                }
            }
        }
    }
}
