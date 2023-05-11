using FixxoApi2.Models.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FixxoApi2.Models.Dtos
{
    public class ProductResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Sku { get; set; } = null!;
        public int Rating { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; } = null!;
        public string ImagePath { get; set; } = null!;

    }
}
