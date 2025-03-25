using System.ComponentModel.DataAnnotations;

namespace Crud.Back.Application.DTO
{
    public class BandRequestDto
    {
        [Required(ErrorMessage = "O nome é obrigatório")]
        public string Name { get; set; }

        [Required(ErrorMessage = "A data é obrigatória")]
        public DateTime FormationDate { get; set; }

        [Required(ErrorMessage = "O estilo é obrigatório")]
        public Guid IdStyle { get; set; }

        public IEnumerable<MemberRequestDto> Members { get; set; }
    }
}
