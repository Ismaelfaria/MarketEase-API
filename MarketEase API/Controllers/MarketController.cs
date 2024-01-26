using MarketEase_API.Entity;
using MarketEase_API.Pesistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarketEase_API.Controllers
{
    [Route("api/Market-Systemy")]
    [ApiController]
    public class MarketController : ControllerBase
    {
        private readonly ContextMarket _context;

        public MarketController(ContextMarket context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult AllProducts()
        {
            var products = _context.products.Where(de => !de.IsDeleted).ToList();

            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult Product(int id)
        {
            var product = _context.products.SingleOrDefault(de => de.Id == id);

            if(product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        public IActionResult RegisterProducts(Product product)
        {
            _context.products.Add(product);
            _context.SaveChanges();

            return CreatedAtAction(nameof(Product), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, Product input)
        {
            var product = _context.products.SingleOrDefault(de => de.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            product.Update(input.Name, input.Value, input.Quantity, input.Validity);

            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = _context.products.SingleOrDefault(de => de.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            product.Delete();
            _context.SaveChanges();
            return Ok(product);
        }

        [HttpGet("api/Market-Systemy/Packaging")]
        public IActionResult GetAllPackaging()
        {
            var products = _context.packaging.Where(de => !de.IsDeleted).ToList();
            return Ok(products);
        }

        [HttpGet("api/Market-Systemy/Packaging/{id}")]
        public IActionResult GetPackagingById(int id)
        {
            var pack = _context.packaging.SingleOrDefault(de => de.Id == id);

            if (pack == null)
            {
                return NotFound();
            }

            return Ok(pack);
        }

        [HttpPost("api/Market-Systemy/Packaging")]
        public IActionResult RegisterPackaging(PackagingTypes packaging)
        {
            _context.packaging.Add(packaging);
            _context.SaveChanges();
            return Created(); // Se possível, retorne a URI do novo recurso criado.
        }

        [HttpPut("api/Market-Systemy/Packaging/{id}")]
        public IActionResult UpdatePackaging(int id, [FromBody] PackagingTypes input)
        {
            var pack = _context.packaging.SingleOrDefault(de => de.Id == id);

            if (pack == null)
            {
                return NotFound();
            }

            pack.Update(input.Size, input.Fragility);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("api/Market-Systemy/Packaging/{id}")]
        public IActionResult DeletePackaging(int id)
        {
            var product = _context.packaging.SingleOrDefault(de => de.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            product.Delete();
            _context.SaveChanges();

            return NoContent();
        }
    }
}
