using Crud.Back.Application.DTO;
using Crud.Back.Domain.Entities;

namespace Crud.Back.Application.Interface
{
    public interface IStyleService 
    {
        Task<IEnumerable<StyleResponseDto>> GetAllAsync();
        Task<StyleResponseDto> GetByIdAsync (Guid id);
    }
}

