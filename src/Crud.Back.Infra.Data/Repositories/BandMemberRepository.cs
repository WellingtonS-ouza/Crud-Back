using Crud.Back.Domain.Entities;
using Crud.Back.Domain.Interfaces.Repositories;
using Crud.Back.Infra.Data.Context;

namespace Crud.Back.Infra.Data.Repositories
{
    public class BandMemberRepository : BaseRepository<BandMember>, IBandMemberRepository
    {
        private readonly CrudBackContext _context;
        
        public BandMemberRepository(CrudBackContext context) : base(context)
        {
            _context = context;
        }
    }
}
