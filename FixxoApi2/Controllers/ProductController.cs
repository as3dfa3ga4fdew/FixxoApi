using Azure;
using FixxoApi2.Models.Dtos;
using FixxoApi2.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FixxoApi2.Controllers
{
    public class ProductController : ControllerBase
    {
        private readonly ProductRepository _repository;
        public ProductController(ProductRepository repository)
        {
            _repository = repository;
        }
        [HttpPost("api/product/tag")]
        public async Task<IActionResult> GetListsByTag([FromBody]ProductOptionRequest request)
        {
            if(ModelState.IsValid)
            {
                ProductOptionResponse response = new ProductOptionResponse();
                response.Result = new Dictionary<int, IEnumerable<ProductMinimalResponse>>();
                foreach(var option in request.Options) 
                {
                    var list = await _repository.GetByTagIdCountAsync(option.TagId, option.Count);
                    response.Result.Add(option.TagId, list);
                }

                return Ok(response);
            }


            return BadRequest();
        }

        [HttpGet("api/product/tag/name/{tag}")]
        public async Task<IActionResult> GetByTag(string tag)
        {
            if(ModelState.IsValid)
            {
                var products = await _repository.GetByTagAsync(tag);

                if(products == null)
                    return NotFound();

                if (products.Count() == 0)
                    return NotFound();

                return Ok(products);
            }

            return BadRequest();
        }

        [HttpGet("api/product/tag/id/{id}")]
        public async Task<IActionResult> GetByTagIdAsync(int id)
        {
            if (ModelState.IsValid)
            {
                var products = await _repository.GetByTagIdAsync(id);

                if (products == null)
                    return NotFound();

                if (products.Count() == 0)
                    return NotFound();

                return Ok(products);
            }

            return BadRequest();
        }

        [HttpGet("api/product/id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if(ModelState.IsValid)
            {
                var product = await _repository.GetByIdAsync(id);

                if (product != null)
                    return Ok(product);

                return NotFound();
            }

            return BadRequest();
        }

        [HttpPost("api/product")]
        public async Task<IActionResult> Create([FromBody]ProductRequest request)
        {
            if(ModelState.IsValid)
            {
                if (await _repository.CreateAsync(request) != null)
                    return Created("", "");
            }

            return BadRequest();
        }
    }
}
