using MarketEase_API.Entity;

namespace MarketEase_API.Model
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Value { get; set; }
        public int Quantity { get; set; }
        public int PackagingTypesId { get; set; }
        public DateTime Validity { get; set; }
    }
    public class PackViewModel()
    {
        public int Id { get; set; }
        public int Size { get; set; }
        public int Fragility { get; set; }
    }
}
