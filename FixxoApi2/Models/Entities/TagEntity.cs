using FixxoApi2.Models.Dtos;
using System.ComponentModel.DataAnnotations;

namespace FixxoApi2.Models.Entities
{
    public class TagEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Tag { get; set; } = null!;

        public static implicit operator TagResponse(TagEntity entity)
        {
            if (entity == null)
                return null;

            return new TagResponse
            {
                Id = entity.Id,
                Tag = entity.Tag
            };
        }
    }
}
