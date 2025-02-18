using Crud.Back.Application.Interface;
using Crud.Back.Domain.Interfaces.Repositories;

namespace Crud.Back.Application.Services
{
    public class StyleService : IStyleService
    {


        public StyleService(IStyleRepository repository)
        {
        }
    }
}
