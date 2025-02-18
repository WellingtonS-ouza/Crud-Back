using AutoMapper;
using Crud.Back.Application.Interface;
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
    }
}
