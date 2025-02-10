using Crud.Back.Domain.Entities;
using Crud.Back.Domain.Interfaces.Repositories;
using Crud.Back.Infra.Data.Context;

namespace Crud.Back.Infra.Data.Repositories
{
    public class MemberRepository : BaseRepository<Member>, IMemberRepository
    {
        private readonly CrudBackContext _context;

        public MemberRepository(CrudBackContext context) : base(context)
        {
            _context = context;
        }
    }
}
