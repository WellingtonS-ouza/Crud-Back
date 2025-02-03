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
        public async Task<Band> GetById(Guid id)
        {
            return await _bandRepository.GetById(id);

        }
        public void Insert(Band band)
        {
            _bandRepository.Insert(band);
            _bandRepository.Commit();
        }
        public void Update(Band band)
        {

            if (band == null)
            {
                throw new ArgumentNullException(nameof(band), "A banda não pode ser nula");
            }

            var existingBand = _bandRepository.GetById(band.Id);

            if (existingBand == null)
            {

                throw new KeyNotFoundException($"Banda com ID {band.Id} não encontrada.");
            }
            _bandRepository.Update(band);
            _bandRepository.Commit();


        }
        public async Task Delete(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException("O ID da banda é inválido.");
            }

            var existingBand = await _bandRepository.GetById(id);

            if (existingBand == null)
            {
                throw new KeyNotFoundException($"Banda com ID {id} não encontrada.");
            }

            await _bandRepository.Delete(existingBand);
            _bandRepository.Commit();
        }

    }
}
