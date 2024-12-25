using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tabu.DTOs.BannedWords;
using Tabu.Exceptions;
using Tabu.Exceptions.BannedWords;
using Tabu.Exceptions.Words;
using Tabu.Services.Abstracts;

namespace Tabu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannedWordsController(IBannedWordServise servise) : ControllerBase
    {
        //[HttpPost("[action]")]
        //public async Task<IActionResult> Create(BannedWordCreateDto dto)
        //{
        //    try
        //    {
        //        await servise.CreateAsync(dto);
        //        return Ok();
        //    }
        //    catch (BannedWordExistException ex)
        //    {

        //        if (ex is IBaseException baseExc)
        //        {
        //            return StatusCode(baseExc.StatusCode, new
        //            {
        //                Mesagge = baseExc.ErrorMessage
        //            });
        //        }
        //        else
        //        {
        //            return BadRequest(new
        //            {
        //                Message = ex.Message,
        //            });
        //        }
        //    }
        //    catch (WordNotFoundException ex)
        //    {
        //        if (ex is IBaseException baseExc)
        //        {
        //            return StatusCode(baseExc.StatusCode, new
        //            {
        //                Message = baseExc.ErrorMessage
        //            });
        //        }
        //        else
        //        {
        //            return BadRequest(new
        //            {
        //                Message = ex.Message,
        //            });
        //        }

        //    }
        //}
        [HttpGet("[action]")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var BannedWords = await servise.GetAllAsync();
                return Ok(BannedWords);
            }
            catch (BannedWordNotFoundException ex)
            {

                if (ex is IBaseException baseExc)
                {
                    return StatusCode(baseExc.StatusCode, new
                    {
                        Mesagge = baseExc.ErrorMessage
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
        [HttpPut("[action]")]
        public async Task<IActionResult> Update(BannedWordUpdateDto dto, int id)
        {
            try
            {
                await servise.UpdateAsync(dto, id);
                return Ok();
            }
            catch (BannedWordNotFoundException ex)
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
                        Message = ex.Message,
                    });
                }

            }
        }
        [HttpDelete("[action]")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await servise.DeleteAsync(id);
                return Ok();
            }
            catch (BannedWordNotFoundException ex)
            {

                if (ex is IBaseException baseExc)
                {
                    return StatusCode(baseExc.StatusCode, new
                    {
                        Message = baseExc.ErrorMessage
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

    }
}
