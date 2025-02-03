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
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _memberRepository;

        public MemberService(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public async Task<IEnumerable<Member>> GetAll()
        {
            return await _memberRepository.GetAll();
        }
        public async Task<Member> GetById(Guid id)
        {
            return await _memberRepository.GetById(id);

        }
        public void Insert(Member member)
        {
            _memberRepository.Insert(member);
            _memberRepository.Commit();
        }
        public void Update(Member member)
        {


            var existingMember = _memberRepository.GetById(member.Id);

            if (existingMember == null)
            {

                throw new KeyNotFoundException($"Membro com ID {member.Id} não encontrado.");
            }
            _memberRepository.Update(member);
            _memberRepository.Commit();


        }
        public async Task Delete(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException("O ID do membro da banda é inválido.");
            }

            var existingMember = await _memberRepository.GetById(id);

            if (existingMember == null)
            {
                throw new KeyNotFoundException($"O membro da banda com ID {id} não encontrado.");
            }

            await _memberRepository.Delete(existingMember);
            _memberRepository.Commit();
        }

    }
}


