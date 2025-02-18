using Crud.Back.Application.Interface;
using Crud.Back.Domain.Interfaces.Repositories;

namespace Crud.Back.Application.Services
{
    public class InstrumentService : IInstrumentService
    {

        public InstrumentService(IInstrumentRepository repository) 
        {
        }
    }
}
