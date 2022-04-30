namespace APi_Products.Domain.Entities
{
    public class ProductsQueryResponse
    {
        public List<Product> Products { get; set; }= new List<Product>();
        public int Pages { get; set; }
        public int CorrentPage { get; set; }
    }
}
