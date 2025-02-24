using System.ComponentModel.DataAnnotations;

namespace Crud.Back.Application.DTO
{
    public class StyleRequestDto
    {
        [Required(ErrorMessage = " O estilo da banda é obrigatório")]
        public string Name { get; set; }

    }
}
