using AutoMapper;
using Crud.Back.Application.DTO;
using Crud.Back.Application.Interface;
using Crud.Back.Domain.Interfaces.Repositories;

namespace Crud.Back.Application.Services
{
    public class StyleService : IStyleService
    {
        private readonly IStyleRepository _styleRepository;
        private readonly IMapper _mapper;

        public StyleService(IStyleRepository repository,
            IMapper mapper)
        {
            _styleRepository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<StyleResponseDto>> GetAllAsync()
        {
            var style = await _styleRepository.GetAllAsync();

            if (!style.Any())
                throw new KeyNotFoundException("Nenhum estilo encontrado");

            return _mapper.Map<IEnumerable<StyleResponseDto>>(style);

        }

        public async Task<StyleResponseDto> GetByIdAsync(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("ID do estilo é obrigatorio.");

            var style = await _styleRepository.GetByIdAsync(id);

            if (style == null)
                throw new KeyNotFoundException("Estilo não encontrado.");

            return _mapper.Map<StyleResponseDto>(style);
        }
    }
}
