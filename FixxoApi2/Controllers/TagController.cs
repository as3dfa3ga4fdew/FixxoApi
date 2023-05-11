using FixxoApi2.Models.Dtos;
using FixxoApi2.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FixxoApi2.Controllers
{
    public class TagController : ControllerBase
    {
        private readonly TagRepository _repository;

        public TagController(TagRepository repository)
        {
            _repository = repository;
        }

        [HttpDelete("api/tag")]
        public async Task<IActionResult> DeleteAsync()
        {
            await _repository.DeleteAsync();

            return Ok();
        }

        [HttpPost("api/tag")]
        public async Task<IActionResult> CreateAsync([FromBody]TagRequest request)
        {
            if(ModelState.IsValid) 
            {
                 return Created("", await _repository.CreateAync(request));
            }

            return BadRequest();
        }

        [HttpGet("api/tag/id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if(ModelState.IsValid)
            {
                var result = await _repository.GetByIdAsync(id);

                if (result == null)
                    return NotFound();

                return Ok(result);
            }

            return BadRequest();
        }

        [HttpGet("api/tag")]
        public async Task<IActionResult> GetAll()
        {
            if(ModelState.IsValid)
            {
                var result = await _repository.GetAllAsync();

                if(result == null) return NoContent();
                if (result.Count() == 0) return NoContent();

                return Ok(result);
            }

            return BadRequest();
        }


    }
}
