using System.ComponentModel.DataAnnotations;

namespace Crud.Back.Application.DTO
{
    public class BandRequestDto
    {
        [Required(ErrorMessage = "O nome não pode ser nulo")]
        public string Name { get; set; }

        [Required(ErrorMessage = "A data não pode ser nula")]
        public DateTime FormationDate { get; set; }

        [Required(ErrorMessage = "O estilo não pode ser nulo")]
        public Guid IdStyle { get; set; }

        [Required(ErrorMessage = "O membro não pode ser nulo")]
        public IEnumerable<MemberRequestDto> Members { get; set; }
    }
}
