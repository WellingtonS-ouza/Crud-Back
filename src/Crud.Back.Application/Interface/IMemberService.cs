using Crud.Back.Application.DTO;

namespace Crud.Back.Application.Interface
{
    public interface IMemberService
    {
        Task<IEnumerable<MemberResponseDto>> GetAllAsync();
        Task<MemberResponseDto> GetByIdAsync(Guid id);
        Task<MemberResponseDto> InsertAsync(MemberRequestDto dto);
        Task<MemberResponseDto> UpdateAsync(Guid id, MemberRequestDto dto);
        Task DeleteAsync(Guid id);
    }
}
