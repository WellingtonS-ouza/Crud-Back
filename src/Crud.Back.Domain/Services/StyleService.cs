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
    public class StyleService : IStyleService
    {
        private readonly IStyleRepository _styleRepository;

        public StyleService(IStyleRepository styleRepository)
        {
            _styleRepository = styleRepository;
        }

        public async Task<IEnumerable<Style>> GetAll()
        {
            return await _styleRepository.GetAll();
        }
        public async Task<Style> GetById(Guid id)
        {
            return await _styleRepository.GetById(id);

        }
        public void Insert(Style style)
        {
            _styleRepository.Insert(style);
            _styleRepository.Commit();
        }
        public void Update(Style style)
        {


            var existingMember = _styleRepository.GetById(style.Id);

            if (existingMember == null)
            {

                throw new KeyNotFoundException($"Estilo com ID {style.Id} não encontrado.");
            }
            _styleRepository.Update(style);
            _styleRepository.Commit();


        }
        public async Task Delete(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException("O ID do estilo da banda é inválido.");
            }

            var existingStyle = await _styleRepository.GetById(id);

            if (existingStyle == null)
            {
                throw new KeyNotFoundException($"O estilo da banda com ID {id} não encontrado.");
            }

            await _styleRepository.Delete(existingStyle);
            _styleRepository.Commit();
        }

    }
}


