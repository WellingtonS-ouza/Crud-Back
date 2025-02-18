using Crud.Back.Domain.Entities;
using Crud.Back.Domain.Interfaces.Repositories;
using Crud.Back.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Crud.Back.Infra.Data.Repositories
{
    public class BandRepository : BaseRepository<Band>, IBandRepository
    {
        private readonly CrudBackContext _context;

        public BandRepository(CrudBackContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Band>> GetAllAsync()
        {
            try
            {
                return await _context.Band
                    .Include(b => b.BandMembers)
                        .ThenInclude(bm => bm.Member)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Selecionar: " + ex.Message);
            }
        }
    }
}
