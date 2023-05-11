using FixxoApi2.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace FixxoApi2.Models.Dtos
{
    public class TagRequest
    {
        [Required]
        public string Tag { get; set; } = null!;

        public static implicit operator TagEntity(TagRequest request) 
        {
            return new TagEntity
            {
                Tag = request.Tag
            };
        }
    }
}
