using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using FixxoApi2.Models.Entities;

namespace FixxoApi2.Models.Dtos
{
    public class ProductRequest
    {
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public string Sku { get; set; } = null!;

        [Required]
        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        [Required]
        public string Description { get; set; } = null!;

        [Required]
        public string ImagePath { get; set; } = null!;

        [Required]
        public int TagId { get; set; }

        public static implicit operator ProductEntity(ProductRequest request)
        {
            return new ProductEntity
            {
                Name = request.Name,
                Sku = request.Sku,
                Price = request.Price,
                Description = request.Description,
                ImagePath = request.ImagePath,
                TagId = request.TagId,
                Rating = 5
            };
        }
    }
}
