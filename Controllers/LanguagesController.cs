using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tabu.DTOs.Languages;
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
            await servise.CreateAsync(dto);
            return Ok();
        }
        [HttpGet("Read")]
        public async Task<IActionResult> Read()
        {
            return Ok(await servise.GetAllAsync());
        }    
          
        [HttpPut("Update")]
        public async Task<IActionResult> Update(LanguageUpdateDto dto)
        {
            await servise.UpdateAsync(dto);
            return Ok();
        }   
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(LanguageDeleteDto dto)
        {
            await servise.DeleteAsync(dto);
            return Ok();
        }     
    }
}
