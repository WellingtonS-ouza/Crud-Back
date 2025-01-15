namespace Crud.Back.Domain.Entities
{
    public class BandMember
    {
        public Guid Id { get; set; }

        public Guid IdBand { get; set; }
        public Band Band { get; set; }

        public Guid IdMember { get; set; }
        public Member Member { get; set; }
    }
}
