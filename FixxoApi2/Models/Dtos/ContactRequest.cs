using FixxoApi2.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace FixxoApi2.Models.Dtos
{
    public class ContactRequest
    {
        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public string Email { get; set; } = null!;

        [Required]
        public string Message { get; set; } = null!;

        public static implicit operator ContactEntity(ContactRequest request)
        {
            return new ContactEntity()
            {
                Name = request.Name,
                Email = request.Email,
                Message = request.Message
            };
        }
    }
}
