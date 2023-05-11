using System.ComponentModel.DataAnnotations;

namespace FixxoApi2.Models.Dtos
{
    public class ProductOptionRequest
    {
        [Required]
        public List<ProductOption> Options { get; set; } = null!;
    }
}
