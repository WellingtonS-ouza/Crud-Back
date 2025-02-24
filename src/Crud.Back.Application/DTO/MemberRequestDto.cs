using System.ComponentModel.DataAnnotations;

namespace Crud.Back.Application.DTO
{
    public class MemberRequestDto
    {
        [Required(ErrorMessage = "O membro da banda é obrigatório")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "A idade do membro da banda é obrigatória")]
        public int Age { get; set; }

        [Required(ErrorMessage = "O genêro do membro é obrigatório")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "O instrumento do membro da banda é obrigatório")]
        public Guid IdInstrument { get; set; }
    }
}
