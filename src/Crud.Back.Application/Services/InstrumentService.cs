using AutoMapper;
using Crud.Back.Application.DTO;
using Crud.Back.Application.Interface;
using Crud.Back.Domain.Interfaces.Repositories;

namespace Crud.Back.Application.Services
{
    public class InstrumentService : IInstrumentService
    {
        private readonly IMapper _mapper;
        private readonly IInstrumentRepository _instrumentRepository;
        public InstrumentService(IMapper mapper,
            IInstrumentRepository instrumentRepository)
        {
            _mapper = mapper;
            _instrumentRepository = instrumentRepository;
        }

        public async Task<IEnumerable<InstrumentResponseDto>> GetAllAsync()
        {
            var instrument = await _instrumentRepository.GetAllAsync();

            if (!instrument.Any())
                throw new KeyNotFoundException("Nenhum instrumento encontrado");

            return _mapper.Map<IEnumerable<InstrumentResponseDto>>(instrument);
        }

        public async Task<InstrumentResponseDto> GetByIdAsync(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("ID do instrumento é obrigatorio.");

            var instrument = await _instrumentRepository.GetByIdAsync(id);

            if (instrument == null)
                throw new KeyNotFoundException("Instrumento não encontrado.");

            return _mapper.Map<InstrumentResponseDto>(instrument);
        }
    }
}
