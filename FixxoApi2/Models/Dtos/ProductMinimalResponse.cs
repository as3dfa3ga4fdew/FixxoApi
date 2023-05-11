namespace FixxoApi2.Models.Dtos
{
    public class ProductMinimalResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Rating { get; set; }
        public decimal Price { get; set; }
        public string ImagePath { get; set; } = null!;
    }
}
