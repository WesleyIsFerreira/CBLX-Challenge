using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APi_Products.DataContext;
using APi_Products.Domain.Entities;

namespace Products_API.Controllers
{
    [Route("api")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly MyContext _context;
        public HomeController()
        {
            var options = new DbContextOptionsBuilder<MyContext>()
               .UseInMemoryDatabase(databaseName: "Test")
               .Options;

            _context = new MyContext(options);
            var primeiro = _context.Products.FirstOrDefault();
            if(primeiro == null)
            {
                createFakeData();
            }
            
        }


        [HttpGet("getProducts/{page}")]
        public async Task<IActionResult> getProducts(int page = 1)
        {
            var pageCount = Math.Ceiling(_context.Products.Count() / 5f);

            var products = await _context.Products
                .Skip((page - 1) * 5)
                .Take(5)
                .ToListAsync();

            var response = new ProductsQueryResponse
            {
                Products = products,
                CorrentPage = page,
                Pages = (int)pageCount
            };

            return Ok(response);
        }

        private void createFakeData()
        {

            _context.Products.Add(new Product
            {
                Name = "Esponja",
                Price = 20.5m,
                Description = "Esponja de aço tramombril",
                Quantity = 5,
                Kind = Kind.notOrganic
            });

            _context.Products.Add(new Product
            {
                Name = "Batata",
                Price = 6.5m,
                Description = "Batata da terra",
                Quantity = 200,
                Kind = Kind.organic
            });

            _context.Products.Add(new Product
            {
                Name = "Filé de frango",
                Price = 12.5m,
                Description = "Filé de frango sem temperado a maionese",
                Quantity = 15,
                Kind = Kind.organic
            });

            _context.Products.Add(new Product
            {
                Name = "Feijão",
                Price = 7.8m,
                Description = "Rico em ferro e vitaminas pra ficar forte",
                Quantity = 125,
                Kind = Kind.organic
            });

            _context.Products.Add(new Product
            {
                Name = "Pano de prato",
                Price = 3,
                Description = "Panos brancos de prato para pratos",
                Quantity = 500,
                Kind = Kind.notOrganic
            });

            _context.Products.Add(new Product
            {
                Name = "Xbox One",
                Price = 3800,
                Description = "Videogame 0km",
                Quantity = 1,
                Kind = Kind.notOrganic
            });

            _context.Products.Add(new Product
            {
                Name = "Computador",
                Price = 4200,
                Description = "Configuração é um mistério",
                Quantity = 2,
                Kind = Kind.notOrganic
            });

            _context.Products.Add(new Product
            {
                Name = "Mesa",
                Price = 500,
                Description = "Mesa redonda para centro",
                Quantity = 2,
                Kind = Kind.notOrganic
            });
            _context.SaveChanges();
        }
    }
}
