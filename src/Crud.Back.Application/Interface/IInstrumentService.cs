using Crud.Back.Application.DTO;

namespace Crud.Back.Application.Interface
{
    public interface IInstrumentService 
    {
        Task<IEnumerable<InstrumentResponseDto>> GetAllAsync();
        Task<InstrumentResponseDto> GetByIdAsync(Guid id);

    }
}
