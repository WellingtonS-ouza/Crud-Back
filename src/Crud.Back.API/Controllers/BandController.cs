using Crud.Back.Application.DTO;
using Crud.Back.Application.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Crud.Back.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BandController : ControllerBase
    {
        private readonly IBandService _bandService;

        public BandController(IBandService bandService)
        {
            _bandService = bandService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<BandResponseDto>>> GetAll() 
        {
            return Ok(await _bandService.GetAllAsync());
        }

        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<BandResponseDto>> GetById(Guid id)
        {
            return Ok(await _bandService.GetByIdAsync(id));
        }

        [HttpPost("Create")]
        public async Task<ActionResult<BandResponseDto>> Create(BandRequestDto bandRequestDto)
        {
            var band = await _bandService.InsertAsync(bandRequestDto);

            return CreatedAtAction(nameof(Create), new { id = band.Id }, band);
        }

        [HttpPut("Update/{id}")]
        public async Task<ActionResult<BandResponseDto>> Update(Guid id, BandRequestDto bandRequestDto)
        {
            var band = await _bandService.UpdateAsync(id, bandRequestDto);

            return CreatedAtAction(nameof(Create), new { id = band.Id }, band);
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult> Delete(Guid id)
        {
             await _bandService.DeleteAsync(id);

            return Ok();
        }

    }
}
