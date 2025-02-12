using Crud.Back.Domain.Entities;
using Crud.Back.Domain.Interfaces.Repositories;
using Crud.Back.Domain.Interfaces.Service;

namespace Crud.Back.Application.Services
{
    public class MemberService : BaseService<Member>, IMemberService
    {
        public MemberService(IBaseRepository<Member> repository) : base(repository)
        {
        }
    }
}
