using FixxoApi2.Models.Dtos;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FixxoApi2.Models.Entities
{
    public class ProductEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public string Sku { get; set; } = null!;

        [Required]
        public int Rating { get; set; }

        [Required]
        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        [Required]
        public string Description { get; set; } = null!;

        [Required]
        public string ImagePath { get; set; } = null!;

        [ForeignKey(nameof(TagEntity))]
        [Required]
        public int TagId { get; set; }
        public TagEntity? Tag { get; set; }


        public static implicit operator ProductResponse(ProductEntity entity)
        {
            if (entity == null)
                return null;

            return new ProductResponse()
            {
                Id = entity.Id,
                Name = entity.Name,
                Sku = entity.Sku,
                Rating = entity.Rating,
                Price = entity.Price,
                Description = entity.Description,
                ImagePath = entity.ImagePath
            };
        }

        public static implicit operator ProductMinimalResponse(ProductEntity entity)
        {
            if (entity == null)
                return null;

            return new ProductMinimalResponse()
            {
                Id = entity.Id,
                Name = entity.Name,
                Rating = entity.Rating,
                Price = entity.Price,
                ImagePath = entity.ImagePath
            };
        }

    }
}
