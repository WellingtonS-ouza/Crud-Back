using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Crud.Back.Domain.Entities;
using Crud.Back.Domain.Interfaces.Repositories;
using Crud.Back.Domain.Interfaces.Services;

namespace Crud.Back.Domain.Services
{
    public class BandService : IBandService
    {
        private readonly IBandRepository _bandRepository;

        public BandService(IBandRepository bandRepository)
        {
            _bandRepository = bandRepository;
        }

        public async Task<IEnumerable<Band>> GetAll()
        {
            return await _bandRepository.GetAll();
        }
    }
}
