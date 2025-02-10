using Crud.Back.Domain.Entities;
using Crud.Back.Domain.Interfaces.Repositories;
using Crud.Back.Infra.Data.Context;

namespace Crud.Back.Infra.Data.Repositories
{
    public class StyleRepository : BaseRepository<Style>, IStyleRepository
    {
        private readonly CrudBackContext _context;
        
        public StyleRepository(CrudBackContext context) : base(context)
        {
            _context = context;
        }
    }
}
