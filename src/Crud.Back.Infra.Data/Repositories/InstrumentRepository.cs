using Crud.Back.Domain.Entities;
using Crud.Back.Domain.Interfaces.Repositories;
using Crud.Back.Infra.Data.Context;

namespace Crud.Back.Infra.Data.Repositories
{
    public class InstrumentRepository : BaseRepository<Instrument>, IInstrumentRepository
    {
        private readonly CrudBackContext _context;
        
        public InstrumentRepository(CrudBackContext context) : base(context)
        {
            _context = context;
        }
    }
}
