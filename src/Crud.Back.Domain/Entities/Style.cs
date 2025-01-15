namespace Crud.Back.Domain.Entities
{
    public class Style
    {
        public Guid Id { get; set; }
        public string Name { get; set; }    

        public ICollection<Band> Bands { get; set; }
    }
}
