namespace APi_Products.Domain.Commands
{
    public class ProductCommandRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public int Quantity { get; set; }
        public string Kind { get; set; }
    }
}
