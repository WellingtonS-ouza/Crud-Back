using Crud.Back.Domain.Entities;
using Crud.Back.Domain.Interfaces.Repositories;
using Crud.Back.Domain.Interfaces.Service;

namespace Crud.Back.Application.Services
{
    public class BandMemberService : BaseService<BandMember>, IBandMemberService
    {
        public BandMemberService(IBaseRepository<BandMember> repository) : base(repository)
        {
        }
    }
}
