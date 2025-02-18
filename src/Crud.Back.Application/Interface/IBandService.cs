using Crud.Back.Application.DTO;

namespace Crud.Back.Application.Interface
{
    public interface IBandService 
    {
        Task<IEnumerable<BandResponseDto>> GetAllAsync();
        Task<BandResponseDto> GetByIdAsync(Guid id);
        Task<BandResponseDto> InsertAsync(BandRequestDto dto);
        Task<BandResponseDto> UpdateAsync(Guid id, BandRequestDto dto);
        Task DeleteAsync(Guid id);
    }
}
