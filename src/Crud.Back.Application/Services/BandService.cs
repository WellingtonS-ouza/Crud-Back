using Crud.Back.Domain.Entities;
using Crud.Back.Domain.Interfaces.Repositories;
using Crud.Back.Domain.Interfaces.Service;


namespace Crud.Back.Application.Services
{
    public class BandService : BaseService<Band>, IBandService
    {
        public BandService(IBandRepository repository) : base(repository)
        {
        }
    }
}
