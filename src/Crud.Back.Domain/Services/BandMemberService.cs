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
    public class BandMemberService : IBandMemberService
    {
        private readonly IBandMemberRepository _bandMemberRepository;

        public BandMemberService(IBandMemberRepository bandMemberRepository)
        {
            _bandMemberRepository = bandMemberRepository;
        }

        public async Task<IEnumerable<BandMember>> GetAll()
        {
            return await _bandMemberRepository.GetAll();
        }
        public async Task<BandMember> GetById(Guid id)
        {
            return await _bandMemberRepository.GetById(id);

        }
        public void Insert(BandMember member)
        {
            _bandMemberRepository.Insert(member);
            _bandMemberRepository.Commit();
        }
        public void Update(BandMember member)
        {


            var existingMember = _bandMemberRepository.GetById(member.Id);

            if (existingMember == null)
            {

                throw new KeyNotFoundException($"Membro com ID {member.Id} não encontrado.");
            }
            _bandMemberRepository.Update(member);
            _bandMemberRepository.Commit();


        }
        public async Task Delete(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException("O ID do membro banda é inválido.");
            }

            var existingBandMember = await _bandMemberRepository.GetById(id);

            if (existingBandMember == null)
            {
                throw new KeyNotFoundException($"Membro com ID {id} não encontrado.");
            }

            await _bandMemberRepository.Delete(existingBandMember);
            _bandMemberRepository.Commit();
        }

    }
}


