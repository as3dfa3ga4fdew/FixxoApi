using System.ComponentModel.DataAnnotations;

namespace FixxoApi2.Models.Dtos
{
    public class ProductOptionResponse
    {
        [Required]
        public Dictionary<int, IEnumerable<ProductMinimalResponse>> Result { get; set; } = null!;
    }
}
