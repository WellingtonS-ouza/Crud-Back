namespace Crud.Back.Domain.Entities
{
    public class Band
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime FormationDate { get; set; }

        public Guid IdStyle { get; set; }
        public Style Style { get; set; }

        public ICollection<BandMember> BandMembers { get; set; }
    }
}
