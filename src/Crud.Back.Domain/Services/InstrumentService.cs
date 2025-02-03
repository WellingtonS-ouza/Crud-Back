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
    public class InstrumentService : IInstrumentService
    {
        private readonly IInstrumentRepository _instrumentRepository;

        public InstrumentService(IInstrumentRepository instrumentRepository)
        {
            _instrumentRepository = instrumentRepository;
        }

        public async Task<IEnumerable<Instrument>> GetAll()
        {
            return await _instrumentRepository.GetAll();
        }
        public async Task<Instrument> GetById(Guid id)
        {
            return await _instrumentRepository.GetById(id);

        }
        public void Insert(Instrument instrument)
        {
            _instrumentRepository.Insert(instrument);
            _instrumentRepository.Commit();
        }
        public void Update(Instrument instrument)
        {


            var existingMember = _instrumentRepository.GetById(instrument.Id);

            if (existingMember == null)
            {

                throw new KeyNotFoundException($"Instrumento com ID {instrument.Id} não encontrado.");
            }
            _instrumentRepository.Update(instrument);
            _instrumentRepository.Commit();


        }
        public async Task Delete(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException("O ID do instrumento é inválido.");
            }

            var existingInstrument = await _instrumentRepository.GetById(id);

            if (existingInstrument == null)
            {
                throw new KeyNotFoundException($"O instrumento com ID {id} não encontrado.");
            }

            await _instrumentRepository.Delete(existingInstrument);
            _instrumentRepository.Commit();
        }

    }
}


