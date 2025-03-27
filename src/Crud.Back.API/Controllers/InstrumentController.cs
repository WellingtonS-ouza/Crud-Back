using Crud.Back.Application.DTO;
using Crud.Back.Application.Interface;
using Crud.Back.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Crud.Back.API.Controllers
{
    [Route("api/instruments")]
    public class InstrumentController : Controller
    {
        private readonly IInstrumentService _instrumentService;

        public InstrumentController(IInstrumentService instrumentService)
        {
            _instrumentService = instrumentService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<InstrumentResponseDto>>> GetAll()
        {
            return Ok(await _instrumentService.GetAllAsync());
        }

        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<IEnumerable<InstrumentResponseDto>>> GetById(Guid id)
        {
            return Ok(await _instrumentService.GetByIdAsync(id));
        }


    }
}
