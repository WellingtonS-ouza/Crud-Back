namespace Crud.Back.Domain.Entities
{
    public class Instrument
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public ICollection<Member> Members { get; set; }
    }
}
