using Crud.Back.Domain.Entities;
using Crud.Back.Domain.Interfaces.Repositories;
using Crud.Back.Domain.Interfaces.Service;

namespace Crud.Back.Application.Services
{
    public class StyleService : BaseService<Style>, IStyleService
    {
        public StyleService(IBaseRepository<Style> repository) : base(repository)
        {
        }
    }
}
