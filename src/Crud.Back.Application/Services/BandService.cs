using AutoMapper;
using Crud.Back.Application.DTO;
using Crud.Back.Application.Interface;
using Crud.Back.Domain.Entities;
using Crud.Back.Domain.Interfaces.Repositories;

namespace Crud.Back.Application.Services
{
    public class BandService : IBandService
    {
        private readonly IMapper _mapper;
        private readonly IBandRepository _bandRepository;

        public BandService(IMapper mapper, 
            IBandRepository repository)
        {
            _mapper = mapper;
            _bandRepository = repository;
        }

        public async Task<IEnumerable<BandResponseDto>> GetAllAsync()
        {
            var bands = await _bandRepository.GetAllAsync();

            if (!bands.Any())
                throw new KeyNotFoundException("Não foi encontrada nenhuma banda");

            return _mapper.Map<IEnumerable<BandResponseDto>>(bands);
        }

        public async Task<BandResponseDto> GetByIdAsync(Guid id)
        {
            if (id == Guid.Empty)
                throw new KeyNotFoundException("ID da banda é obrigatorio");

            var band = await _bandRepository.GetByIdAsync(id);

            if (band == null)
                throw new KeyNotFoundException("Banda não encontrada.");

            return _mapper.Map<BandResponseDto>(band);
        }

        public async Task<BandResponseDto> InsertAsync(BandRequestDto dto)
        {
            var band = _mapper.Map<Band>(dto);

            await _bandRepository.InsertAsync(band);
            await _bandRepository.CommitAsync();

            return _mapper.Map<BandResponseDto>(band);
        }

        public async Task<BandResponseDto> UpdateAsync(Guid id, BandRequestDto dto)
        {
            if (id == Guid.Empty)
                throw new KeyNotFoundException("ID da banda é obrigatorio");

            var band = await _bandRepository.GetByIdAsync(id);

            if (band == null)
                throw new KeyNotFoundException("Banda não encontrada.");

            band.Name = dto.Name;
            band.FormationDate = dto.FormationDate;
            band.IdStyle = dto.IdStyle;

            _bandRepository.Update(band);
            await _bandRepository.CommitAsync();

            return _mapper.Map<BandResponseDto>(band);
        }

        public async Task DeleteAsync(Guid id)
        {
            if (id == Guid.Empty)
                throw new KeyNotFoundException("ID da banda é obrigatorio");

            var band = await _bandRepository.GetByIdAsync(id);

            if (band == null)
                throw new KeyNotFoundException("Banda não encontrada.");

            _bandRepository.Delete(band);
            await _bandRepository.CommitAsync();
        }
    }
}
