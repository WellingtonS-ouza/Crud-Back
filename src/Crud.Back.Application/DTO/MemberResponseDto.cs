namespace Crud.Back.Application.DTO
{
    public class MemberResponseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }

        public Guid IdInstrument { get; set; }
    }
}
