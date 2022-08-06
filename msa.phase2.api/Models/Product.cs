namespace msa.phase2.api.Models
{
    public class Product
    {
        public long Id { get; set; }
        public string? Title { get; set; }
        public string? ImageUrl { get; set; }
        public string? Description { get; set; }
        public int? Price { get; set; }
    }
}
