using Crud.Back.Application.DTO;
using Crud.Back.Application.Interface;
using Crud.Back.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Crud.Back.API.Controllers
{
    [Route("api/members")]

    public class MemberController : Controller
    {
        private readonly IMemberService _memberService;

        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<MemberResponseDto>>> GetAll()
        {
            return Ok(await _memberService.GetAllAsync());
        }

        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<IEnumerable<MemberResponseDto>>> GetById(Guid id)
        {
            return Ok(await _memberService.GetByIdAsync(id));
        }

        [HttpPost("Create")]
        public async Task<ActionResult<MemberResponseDto>> Create(MemberRequestDto memberRequestDto)
        {
            var member = await _memberService.InsertAsync(memberRequestDto);

            return CreatedAtAction(nameof(Create), new { id = member.Id }, member);
        }

        [HttpPut("Update/{id}")]
        public async Task<ActionResult<MemberResponseDto>> Update(Guid id, MemberRequestDto memberRequestDto)
        {
            var member = await _memberService.UpdateAsync(id, memberRequestDto);

            return CreatedAtAction(nameof(Create), new { id = member.Id }, member);
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _memberService.DeleteAsync(id);

            return Ok();
        }


    }
}
