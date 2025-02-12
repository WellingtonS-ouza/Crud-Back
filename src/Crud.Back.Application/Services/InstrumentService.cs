using Crud.Back.Domain.Entities;
using Crud.Back.Domain.Interfaces.Repositories;
using Crud.Back.Domain.Interfaces.Service;

namespace Crud.Back.Application.Services
{
    public class InstrumentService : BaseService<Instrument>, IInstrumentService
    {
        public InstrumentService(IBaseRepository<Instrument> repository) : base(repository)
        {
        }
    }
}
