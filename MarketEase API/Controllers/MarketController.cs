using AutoMapper;
using MarketEase_API.Entity;
using MarketEase_API.Mapper;
using MarketEase_API.Model;
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
        private readonly IMapper _mapper;

        public MarketController(ContextMarket context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult AllProducts()
        {
            var products = _context.products.Where(de => !de.IsDeleted).ToList();

            var viewModel = _mapper.Map<List<ProductViewModel>>(products);

            return Ok(viewModel);
        }

        [HttpGet("{id}")]
        public IActionResult Product(int id)
        {
            var product = _context.products.SingleOrDefault(de => de.Id == id);

            if(product == null)
            {
                return NotFound();
            }

            var viewModel = _mapper.Map<ProductViewModel>(product);

            return Ok(product);
        }

        [HttpPost]
        public IActionResult RegisterProducts(ProductInputModel product)
        {
            var inputModel = _mapper.Map<Product>(product);

            _context.products.Add(inputModel);
            _context.SaveChanges();

            return CreatedAtAction(nameof(Product), new { id = inputModel.Id }, inputModel);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, ProductInputModel input)
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
            var pack = _context.packaging.Where(de => !de.IsDeleted).ToList();

            var viewModel = _mapper.Map<List<PackViewModel>>(pack);
            return Ok(viewModel);
        }

        [HttpGet("api/Market-Systemy/Packaging/{id}")]
        public IActionResult GetPackagingById(int id)
        {
            var pack = _context.packaging.SingleOrDefault(de => de.Id == id);

            if (pack == null)
            {
                return NotFound();
            }
            var viewModel = _mapper.Map<PackViewModel>(pack);

            return Ok(viewModel);
        }

        [HttpPost("api/Market-Systemy/Packaging")]
        public IActionResult RegisterPackaging(PackInputModel packaging)
        {
            var viewInput = _mapper.Map<PackagingTypes>(packaging);

            _context.packaging.Add(viewInput);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetPackagingById), new { id = viewInput.Id }, viewInput); 
        }

        [HttpPut("api/Market-Systemy/Packaging/{id}")]
        public IActionResult UpdatePackaging(int id, PackInputModel input)
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
