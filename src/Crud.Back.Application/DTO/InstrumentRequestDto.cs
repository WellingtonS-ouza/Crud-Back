using System.ComponentModel.DataAnnotations;

namespace Crud.Back.Application.DTO
{
    public class InstrumentRequestDto
    {
        [Required(ErrorMessage = " O instrumento é obrigatório")]
        public string Name { get; set; }

    }
}
