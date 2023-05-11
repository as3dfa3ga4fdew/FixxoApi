using FixxoApi2.Models.Dtos;
using FixxoApi2.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace FixxoApi2.Controllers
{
    public class ContactController : ControllerBase
    {
        private readonly ContactRepository _repository;
        public ContactController(ContactRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("api/contact")]
        public async Task<IActionResult> CreateAsync([FromBody]ContactRequest request)
        {
            if(ModelState.IsValid)
            {
                await _repository.CreateAsync(request);
                return Created("", "");
            }

            List<ModelErrorCollection> modelErrorCollections = ModelState.Select(x => x.Value.Errors)
                                 .Where(y => y.Count > 0)
                                 .ToList();

            foreach (var modelErrorCollection in modelErrorCollections)
                foreach (var modelError in modelErrorCollection)
                    Console.WriteLine(modelError.ErrorMessage);

            return BadRequest();
        }
       
    }
}
