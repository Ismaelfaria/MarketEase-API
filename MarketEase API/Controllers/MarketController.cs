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

        [HttpGet("api/Market-Systemy/Products")]
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

            return Ok(product);
        }

        





    }
}
