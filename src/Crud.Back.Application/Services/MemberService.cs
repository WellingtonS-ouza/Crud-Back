using AutoMapper;
using Crud.Back.Application.DTO;
using Crud.Back.Application.Interface;
using Crud.Back.Domain.Entities;
using Crud.Back.Domain.Interfaces.Repositories;

namespace Crud.Back.Application.Services
{
    public class MemberService : IMemberService
    {
        private readonly IMapper _mapper;
        private readonly IMemberRepository _repository;

        public MemberService(IMapper mapper,
            IMemberRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<IEnumerable<MemberResponseDto>> GetAllAsync()
        {
            var members = await _repository.GetAllAsync();
            if (!members.Any())
                throw new KeyNotFoundException("Não foi encontrado nenhum membro.");

            return _mapper.Map<IEnumerable<MemberResponseDto>>(members);

        }

        public async Task<MemberResponseDto> GetByIdAsync(Guid id)
        {
            if (id == Guid.Empty)
                throw new KeyNotFoundException("ID do membro é obrigatorio.");

            var member = await _repository.GetByIdAsync(id);

            if (member == null)
                throw new KeyNotFoundException("Membro não encontrado.");

            return _mapper.Map<MemberResponseDto>(member);
        }

        public async Task<MemberResponseDto> InsertAsync(MemberRequestDto dto)
        {
            var member = _mapper.Map<Member>(dto);

            await _repository.InsertAsync(member);
            await _repository.CommitAsync();

            return _mapper.Map<MemberResponseDto>(member);
        }

        public async Task<MemberResponseDto> UpdateAsync(Guid id, MemberRequestDto dto)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("ID do membro da banda é obrigatorio");

            var member = await _repository.GetByIdAsync(id);

            if (member == null)
                throw new KeyNotFoundException("Membro não encontrado.");

            member.Name = dto.Name;
            member.Age = dto.Age;
            member.Gender = dto.Gender;
            member.IdInstrument = dto.IdInstrument;


            _repository.Update(member);
            await _repository.CommitAsync();

            return _mapper.Map<MemberResponseDto>(member);
        }

        public async Task DeleteAsync(Guid id)
        {

            var member = await _repository.GetByIdAsync(id);

            if (member == null)
                throw new KeyNotFoundException("Membro não encontrado.");

            _repository.Delete(member);
            await _repository.CommitAsync();
        }
    }
}
