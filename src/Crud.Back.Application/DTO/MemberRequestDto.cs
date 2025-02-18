using System.ComponentModel.DataAnnotations;

namespace Crud.Back.Application.DTO
{
    public class MemberRequestDto
    {
        [Required(ErrorMessage = "O membro da banda não pode ser nulo")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "A idade do membro da banda não pode ser nulo")]
        public int Age { get; set; }

        [Required(ErrorMessage = "A idade do membro da banda não pode")]
        public string Gender { get; set; }

        public Guid IdInstrument { get; set; }
    }
}
