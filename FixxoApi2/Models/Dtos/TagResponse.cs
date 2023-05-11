using System.ComponentModel.DataAnnotations;

namespace FixxoApi2.Models.Dtos
{
    public class TagResponse
    {
        public int Id { get; set; }
        public string Tag { get; set; } = null!;
    }
}
