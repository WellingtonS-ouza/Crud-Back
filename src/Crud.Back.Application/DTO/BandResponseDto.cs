using Crud.Back.Domain.Entities;

namespace Crud.Back.Application.DTO
{
    public class BandResponseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime FormationDate { get; set; }
        public Guid IdStyle { get; set; }
        public IEnumerable<Member> Members { get; set; }
    }
}
