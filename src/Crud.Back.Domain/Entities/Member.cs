namespace Crud.Back.Domain.Entities
{
    public class Member
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }

        public Guid IdInstrument { get; set; }
        public Instrument Instrument { get; set; }

        public ICollection<BandMember> BandMembers { get; set; }
    }
}
