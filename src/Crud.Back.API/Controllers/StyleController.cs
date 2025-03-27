using Crud.Back.Application.DTO;
using Crud.Back.Application.Interface;
using Crud.Back.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Crud.Back.API.Controllers
{
    [Route("api/styles")]
    public class StyleController : Controller
    {
        private readonly IStyleService _styleService;

        public StyleController(IStyleService styleService)
        {
            _styleService = styleService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<MemberResponseDto>>> GetAll()
        {
            return Ok(await _styleService.GetAllAsync());
        }

        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<IEnumerable<MemberResponseDto>>> GetById(Guid id)
        {
            return Ok(await _styleService.GetByIdAsync(id));
        }

    }
}
