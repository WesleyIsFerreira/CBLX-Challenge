namespace APi_Products.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public int Quantity { get; set; }
        public Kind Kind { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

    }

    public enum Kind
    {
        organic,
        notOrganic
    }
}
